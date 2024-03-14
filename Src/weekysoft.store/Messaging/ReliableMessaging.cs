// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.ReliableMessaging
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;

#nullable disable
namespace weekysoft.store.Messaging
{
  public class ReliableMessaging : UdpMessaging
  {
    protected readonly int _RepeatCount = 1;
    protected int _SendBuffer;
    protected int _ReceiveBuffer;
    protected int _LostBuffer;
    protected int _ConfirmedBuffer;
    protected int _DeliveryTimeoutMilSec;
    protected int _MessageDelay;
    protected bool _BackgroundRunning;
    protected bool _FindingLostMessages;
    protected bool _ProcessMessages;
    protected bool _Reconfirm;
    protected int _ResentQueueSize = 10;
    private int receivedCount;
    private int receivedMilsecCount;

    protected Queue<KeyValuePair<ChatMessage, DateTime>> SentMessages { get; private set; }

    protected Queue<KeyValuePair<ChatMessage, DateTime>> ReceivedMessages { get; private set; }

    protected Queue<string> ReceivedMessageIds { get; private set; }

    protected Queue<KeyValuePair<ChatMessage, DateTime>> ConfirmMessages { get; private set; }

    private Timer _SentTimer { get; set; }

    private Timer _LostTimer { get; set; }

    private Timer _ReceivedTimer { get; set; }

    public ReliableMessaging(
      string sendingPort,
      string[] receivingPorts,
      string broadcastAddress = "255.255.255.255",
      bool ignoreSelf = true,
      int repeatCount = 1,
      int sendBuffer = 60,
      int receiveBuffer = 60,
      int deliveryTimeoutMilSec = 1000,
      int messageDelay = 15,
      bool reconfirm = false)
      : base(sendingPort, receivingPorts, broadcastAddress, ignoreSelf)
    {
      this._SendBuffer = sendBuffer;
      this._ReceiveBuffer = receiveBuffer;
      this._LostBuffer = sendBuffer * 2;
      this._ConfirmedBuffer = receiveBuffer * 2;
      this._RepeatCount = repeatCount;
      this._Reconfirm = reconfirm;
      this.SentMessages = new Queue<KeyValuePair<ChatMessage, DateTime>>();
      this.ReceivedMessages = new Queue<KeyValuePair<ChatMessage, DateTime>>();
      this.ConfirmMessages = new Queue<KeyValuePair<ChatMessage, DateTime>>();
      this._FindingLostMessages = false;
      this._DeliveryTimeoutMilSec = deliveryTimeoutMilSec;
      this._MessageDelay = messageDelay;
      this._ResentQueueSize = this._DeliveryTimeoutMilSec / 8 / this._MessageDelay;
      this._SentTimer = new Timer(new TimerCallback(this.SentMessageElapsedHandler), (object) null, this._DeliveryTimeoutMilSec * 30, this._DeliveryTimeoutMilSec * 30);
      this._LostTimer = new Timer(new TimerCallback(this.LostMessageElapsedHandler), (object) null, this._DeliveryTimeoutMilSec / 2, this._DeliveryTimeoutMilSec / 2);
      this.ReceivingMessageConfirm = this.ReceivingMessageConfirm + new EventHandler<MessageEventArgs>(this.HandleReceivingMessageConfirm);
      this.ReceivingMessageText = this.ReceivingMessageText + new EventHandler<MessageEventArgs>(this.HandleReceivingMessageText);
      this.ReceivingMessageReconfirm = this.ReceivingMessageReconfirm + new EventHandler<MessageEventArgs>(this.HandleReceivingMessageReconfirm);
      this.ReceivingMessageRequest = this.ReceivingMessageRequest + new EventHandler<MessageEventArgs>(this.HandleReceivingMessageRequest);
      this.MessageValidating = this.MessageValidating + new EventHandler<MessageEventArgs>(this.HandleMessageValidating);
    }

    private async void LostMessageElapsedHandler(object state)
    {
      if (this._FindingLostMessages)
        return;
      try
      {
        this._FindingLostMessages = true;
        Task.Run((Func<Task>) (async () => this.FindLostMsgWorker()));
      }
      catch (Exception ex)
      {
      }
      finally
      {
        this._FindingLostMessages = false;
      }
    }

    private async void SentMessageElapsedHandler(object state)
    {
      if (this._BackgroundRunning)
        return;
      this._BackgroundRunning = true;
      await Task.Run((Func<Task>) (async () => await this.TrimQueuesWorker()));
      this._BackgroundRunning = false;
    }

    private async Task FindLostMsgWorker()
    {
      DateTime now1 = DateTime.Now;
      try
      {
        this.ProcessAgingMessages();
      }
      catch (Exception ex)
      {
      }
      DateTime now2 = DateTime.Now;
    }

    private async Task TrimQueuesWorker()
    {
      if (this.ReceivedMessages.Count<KeyValuePair<ChatMessage, DateTime>>() <= this._ReceiveBuffer * 5)
        return;
      try
      {
        this.TrimMessageQueues();
      }
      catch (Exception ex)
      {
      }
    }

    private async void HandleMessageValidating(object sender, MessageEventArgs e)
    {
      bool flag = false;
      if (!e.Message.IsSystemMessage())
      {
        lock (this.ReceivedMessages)
        {
          flag = this.ReceivedMessages.Any<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageId == e.Message.Header.MessageId));
          if (!flag)
            this.ReceivedMessages.Enqueue(new KeyValuePair<ChatMessage, DateTime>(e.Message, DateTime.Now));
        }
      }
      e.IsAlreadyReceived = flag;
    }

    private async void HandleReceivingMessageRequest(object sender, MessageEventArgs e)
    {
      KeyValuePair<ChatMessage, DateTime> keyValuePair = this.SentMessages.FirstOrDefault<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageId == e.Message.Header.RequestMessageId));
      if (keyValuePair.Key == null)
        return;
      base.SendMessage(keyValuePair.Key);
    }

    private async void HandleReceivingMessageReconfirm(object sender, MessageEventArgs e)
    {
      string omsgId = e.Message.Header.OriginalMessageId;
      KeyValuePair<ChatMessage, DateTime> keyValuePair;
      lock (this.ConfirmMessages)
        keyValuePair = this.ConfirmMessages.FirstOrDefault<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageId == omsgId));
      ChatMessage key = keyValuePair.Key;
      if (key == null)
        return;
      key.MarkReconfirmed();
      MessageEventArgs e1 = new MessageEventArgs();
      e1.Sender = e.Sender;
      e1.DisplayName = e.DisplayName;
      e1.Message = e.Message;
      this.OnMessageReconfirmed(e1);
    }

    private async void HandleReceivingMessageText(object sender, MessageEventArgs e)
    {
      ChatMessage confirmMessage = ChatMessage.CreateConfirmMessage(e.Message, this.UserName, this.Host);
      lock (this.ConfirmMessages)
        this.ConfirmMessages.Enqueue(new KeyValuePair<ChatMessage, DateTime>(confirmMessage, DateTime.Now));
      this.SendMessage(confirmMessage);
    }

    private async void HandleReceivingMessageConfirm(object sender, MessageEventArgs e)
    {
      ChatMessage content = new ChatMessage(e.Message.Body);
      if (content.Header.SenderIP != this.Host)
      {
        this.HandlePeerConfirmMessage(content);
      }
      else
      {
        string omsgId = e.Message.Header.OriginalMessageId;
        KeyValuePair<ChatMessage, DateTime> keyValuePair;
        lock (this.SentMessages)
          keyValuePair = this.SentMessages.FirstOrDefault<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageId == omsgId));
        ChatMessage key = keyValuePair.Key;
        if (key == null)
          return;
        key.MarkConfirmed();
        MessageEventArgs messageEventArgs = new MessageEventArgs();
        messageEventArgs.Sender = e.Sender;
        messageEventArgs.DisplayName = e.DisplayName;
        messageEventArgs.Message = e.Message;
        MessageEventArgs e1 = messageEventArgs;
        this.OnMessageConfirmed(e1);
        if (this._Reconfirm)
          this.SendMessage(ChatMessage.CreateReconfirmMessage(e.Message, this.UserName, this.Host));
        if (key.Confirmations < key.Header.ExpectedRecipients)
          return;
        this.OnMessageFullyConfirmed(e1);
      }
    }

    public int GetUnconfirmedMessageCount()
    {
      return this.SentMessages.Where<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageType == MessageType.Text && s.Key.Confirmations == 0 && s.Key.Losts == 0)).Count<KeyValuePair<ChatMessage, DateTime>>();
    }

    private void HandlePreviousMessages()
    {
      lock (this.ReceivedMessages)
      {
        foreach (KeyValuePair<ChatMessage, DateTime> receivedMessage in this.ReceivedMessages)
          this.HandlePreviousMessage(receivedMessage.Key);
      }
    }

    private async Task TrimMessageQueues()
    {
      lock (this.ReceivedMessages)
      {
        if (this.ReceivedMessages.Count<KeyValuePair<ChatMessage, DateTime>>() > this._ReceiveBuffer)
        {
          if (this.ReceivedMessages.Peek().Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec * 2)) < DateTime.Now)
          {
            for (int index = 0; (double) index < (double) this._ReceiveBuffer * 0.2; ++index)
              this.ReceivedMessages.Dequeue();
          }
        }
      }
      lock (this.SentMessages)
      {
        if (this.SentMessages.Count<KeyValuePair<ChatMessage, DateTime>>() > this._SendBuffer)
        {
          if (this.SentMessages.Peek().Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec * 2)) < DateTime.Now)
          {
            for (int index = 0; (double) index < (double) this._SendBuffer * 0.1; ++index)
              this.SentMessages.Dequeue();
          }
        }
      }
      lock (this.ConfirmMessages)
      {
        if (this.ConfirmMessages.Count<KeyValuePair<ChatMessage, DateTime>>() <= this._ConfirmedBuffer || !(this.ConfirmMessages.Peek().Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec * 2)) < DateTime.Now))
          return;
        for (int index = 0; (double) index < (double) this._ConfirmedBuffer * 0.1; ++index)
          this.ConfirmMessages.Dequeue();
      }
    }

    protected override async Task BroadCast(string message)
    {
      for (int index = 0; index < this._RepeatCount; ++index)
        base.BroadCast(message);
    }

    public override async Task SendMessage(ChatMessage content)
    {
      if (content.Header.MessageType == MessageType.Text)
      {
        lock (this.SentMessages)
          this.SentMessages.Enqueue(new KeyValuePair<ChatMessage, DateTime>(content, DateTime.Now));
      }
      base.SendMessage(content);
    }

    private void FindLostMessages2()
    {
      if (this.SentMessages.Count <= 0)
        return;
      KeyValuePair<ChatMessage, DateTime> keyValuePair = this.SentMessages.FirstOrDefault<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageType == MessageType.Text));
      if (keyValuePair.Key != null && keyValuePair.Value.AddMilliseconds((double) this._DeliveryTimeoutMilSec) < DateTime.Now)
      {
        ChatMessage key = keyValuePair.Key;
        this.BroadCast(keyValuePair.Key.BuildSendString());
        key.MarkLost();
        MessageEventArgs e = new MessageEventArgs();
        e.Sender = this.Host;
        e.DisplayName = this.UserName;
        e.Message = key;
        this.OnMessageLost(e);
        this.FindLostMessages2();
      }
      else
      {
        if (!(keyValuePair.Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec / 2)) < DateTime.Now))
          return;
        this.BroadCast(keyValuePair.Key.BuildSendString());
      }
    }

    private async Task ProcessAgingMessages()
    {
      IEnumerable<KeyValuePair<ChatMessage, DateTime>> list1;
      IEnumerable<KeyValuePair<ChatMessage, DateTime>> list2;
      lock (this.SentMessages)
      {
        list1 = (IEnumerable<KeyValuePair<ChatMessage, DateTime>>) this.SentMessages.Where<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageType == MessageType.Text && s.Key.Confirmations == 0 && s.Key.Losts == 0 && s.Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec / 2)) < DateTime.Now)).Take<KeyValuePair<ChatMessage, DateTime>>(Math.Min(this.SentMessages.Count<KeyValuePair<ChatMessage, DateTime>>() / 5 + 1, this._ResentQueueSize)).ToList<KeyValuePair<ChatMessage, DateTime>>();
        list2 = (IEnumerable<KeyValuePair<ChatMessage, DateTime>>) this.SentMessages.Where<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageType == MessageType.Text && s.Key.Confirmations > 0 && s.Key.Confirmations < s.Key.Header.ExpectedRecipients)).Take<KeyValuePair<ChatMessage, DateTime>>(Math.Min(this.SentMessages.Count<KeyValuePair<ChatMessage, DateTime>>() / 5 + 1, this._ResentQueueSize)).ToList<KeyValuePair<ChatMessage, DateTime>>();
      }
      IEnumerable<KeyValuePair<ChatMessage, DateTime>> list3;
      lock (this.ConfirmMessages)
        list3 = (IEnumerable<KeyValuePair<ChatMessage, DateTime>>) this.ConfirmMessages.Where<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageType == MessageType.Confirm && s.Key.Reconfirmations == 0 && s.Key.Losts == 0 && s.Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec / 2)) < DateTime.Now)).Take<KeyValuePair<ChatMessage, DateTime>>(Math.Min(this.ConfirmMessages.Count<KeyValuePair<ChatMessage, DateTime>>() / 5 + 1, this._ResentQueueSize)).ToList<KeyValuePair<ChatMessage, DateTime>>();
      foreach (KeyValuePair<ChatMessage, DateTime> keyValuePair in list1)
      {
        ChatMessage key = keyValuePair.Key;
        if (keyValuePair.Value.AddMilliseconds((double) this._DeliveryTimeoutMilSec) < DateTime.Now)
        {
          base.SendMessage(key);
          key.MarkLost();
          MessageEventArgs e = new MessageEventArgs();
          e.Sender = this.Host;
          e.DisplayName = this.UserName;
          e.Message = key;
          this.OnMessageLost(e);
        }
        else if (keyValuePair.Value.AddMilliseconds((double) this._DeliveryTimeoutMilSec / 2.0) < DateTime.Now)
          base.SendMessage(key);
      }
      foreach (KeyValuePair<ChatMessage, DateTime> keyValuePair in list2)
      {
        ChatMessage key = keyValuePair.Key;
        if (keyValuePair.Value.AddMilliseconds((double) (this._DeliveryTimeoutMilSec * 2)) > DateTime.Now)
          base.SendMessage(key);
      }
      foreach (KeyValuePair<ChatMessage, DateTime> keyValuePair in list3)
      {
        ChatMessage key = keyValuePair.Key;
        if (keyValuePair.Value.AddMilliseconds((double) this._DeliveryTimeoutMilSec) < DateTime.Now)
        {
          base.SendMessage(key);
          key.MarkLost();
          MessageEventArgs e = new MessageEventArgs();
          e.Sender = this.Host;
          e.DisplayName = this.UserName;
          e.Message = key;
          this.OnConfirmMessageLost(e);
        }
        else if (keyValuePair.Value.AddMilliseconds((double) this._DeliveryTimeoutMilSec / 2.0) < DateTime.Now)
          base.SendMessage(key);
      }
    }

    protected override async Task OnMessageReceived(MessageEventArgs e)
    {
      ++this.receivedCount;
      DateTime now = DateTime.Now;
      try
      {
        this.ProcessMessage(e);
      }
      catch (Exception ex)
      {
        Exception innerException = ex.InnerException;
        this.OnMessageReceivedError(new ErrorEventArgs(ErrorType.Unknown, ex));
      }
      this.receivedMilsecCount += DateTime.Now.Subtract(now).Milliseconds;
    }

    public string GetReceivedStats()
    {
      return string.Format("%%--\t{0}\tReceived: {1}, total duration: {2}, rate: {3}", (object) DateTime.Now.ToString("hh:mm:ss:fff"), (object) this.receivedCount, (object) this.receivedMilsecCount, (object) (this.receivedMilsecCount / this.receivedCount));
    }

    protected async Task ProcessMessage(MessageEventArgs e)
    {
      ChatMessage content = e.Message;
      await this.OnMessageValidating(e);
      if (e.IsValid)
      {
        if (e.IsSuperChannel && e.Message.Header.RoomId != SuperChannel.Lobby.GetKey())
        {
          if (e.Message.Header.RoomId == SuperChannel.Site.GetKey())
            this.OnSiteMessageReceived(e);
        }
        else if (e.IsValidChannel)
        {
          if (content.Header.MessageType == MessageType.Confirm)
            this.OnReceivingMessageConfirm(e);
          else if (content.Header.MessageType == MessageType.Text)
            this.OnReceivingMessageText(e);
          else if (content.Header.MessageType == MessageType.Reconfirm)
            this.OnReceivingMessageReconfirm(e);
          else if (content.Header.MessageType == MessageType.RequestMessage)
            this.OnReceivingMessageRequest(e);
        }
        await base.OnMessageReceived(e);
      }
      else if (e.IsNewerProtocol)
      {
        this.OnMessageReceivedError(new ErrorEventArgs(ErrorType.ProtocolMismatch, new Exception("Protocol mismatch. Your app may be outdated. Plesae uninstall and reinstall or wait a few days for the app to be updated in the store.")));
      }
      else
      {
        int num = e.IsAlreadyReceived ? 1 : 0;
      }
    }

    private async void HandlePreviousMessage(ChatMessage content)
    {
      string previousMessageId = content.Header.PreviousMessageId;
      if (string.IsNullOrEmpty(previousMessageId) || this.ReceivedMessages.FirstOrDefault<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageId == previousMessageId)).Key != null || !this.ContainsPreceedingMessageId(this.ReceivedMessages, previousMessageId))
        return;
      this.SendMessage(ChatMessage.CreateRequestMessage(content, this.UserName, this.Host, previousMessageId));
    }

    public bool ContainsPreceedingMessageId(
      Queue<KeyValuePair<ChatMessage, DateTime>> receivedMessages,
      string previousMessageId)
    {
      return receivedMessages.Any<KeyValuePair<ChatMessage, DateTime>>((Func<KeyValuePair<ChatMessage, DateTime>, bool>) (s => s.Key.Header.MessageType == MessageType.Text && s.Key.Header.MessageId.Substring(0, 3) == previousMessageId.Substring(0, 3) && this.ConvertMessageIdToUInt(s.Key.Header.MessageId) < this.ConvertMessageIdToUInt(previousMessageId)));
    }

    public long ConvertMessageIdToUInt(string base64str)
    {
      return (long) BitConverter.ToUInt32(((IEnumerable<byte>) Convert.FromBase64String(base64str)).Skip<byte>(2).Take<byte>(4).ToArray<byte>(), 0);
    }

    protected virtual async Task HandlePeerConfirmMessage(ChatMessage content)
    {
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.UdpMessaging
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Sockets.Plugin;
using Sockets.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;
using weekysoft.store.Interfaces;


namespace weekysoft.store.Messaging
{
  public class UdpMessaging : IMessaging
  {
    protected string _SendingPort;
    protected string[] _ReceivingPorts;
    private List<UdpSocketReceiver> Listeners;
    protected static readonly char _StringTerminator = '\a';
    private UdpSocketClient _Broadcaster;
    protected string _BroadcastAddress;
    protected object _LockListener = new object();
    protected object _LockBroadcaster = new object();
    protected bool _IgnoreSelf;
    private string _Username;
    private IEnumerable<string> _HostNames;
    private string _Host;
    private Version _ProtocolVersion;

    public EventHandler<MessageEventArgs> MessageReceived { get; set; }

    public bool IsListening { get; protected set; }

    public bool IsBroadcastSetup { get; protected set; }

    public string Channel { get; set; }

    public EventHandler<MessageEventArgs> MessageValidating { get; set; }

    public EventHandler<MessageEventArgs> MessageValidated { get; set; }

    public EventHandler<MessageEventArgs> MessageConfirmed { get; set; }

    public EventHandler<MessageEventArgs> MessageFullyConfirmed { get; set; }

    public EventHandler<MessageEventArgs> MessageReconfirmed { get; set; }

    public EventHandler<MessageEventArgs> MessageLost { get; set; }

    public EventHandler<MessageEventArgs> ConfirmMessageLost { get; set; }

    public EventHandler<ErrorEventArgs> MessageReceivedError { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageAck { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageNak { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageSync { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageConfirm { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageText { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageReconfirm { get; set; }

    public EventHandler<MessageEventArgs> ReceivedMessageRequest { get; set; }

    public EventHandler<MessageEventArgs> ReceivingMessageConfirm { get; set; }

    public EventHandler<MessageEventArgs> ReceivingMessageText { get; set; }

    public EventHandler<MessageEventArgs> ReceivingMessageReconfirm { get; set; }

    public EventHandler<MessageEventArgs> ReceivingMessageRequest { get; set; }

    public EventHandler<MessageEventArgs> SiteMessageReceived { get; set; }

    public UdpMessaging(
      string sendingPort,
      string[] receivingPorts,
      string broadcastAddress = "255.255.255.255",
      bool ignoreSelf = true)
    {
      this._IgnoreSelf = ignoreSelf;
      this.IsListening = false;
      this.IsBroadcastSetup = false;
      this._SendingPort = sendingPort;
      this._ReceivingPorts = receivingPorts;
      this._BroadcastAddress = broadcastAddress;
      this.Listeners = new List<UdpSocketReceiver>();
      this.ReceivedMessageSync += new EventHandler<MessageEventArgs>(this.HandleReceivedMessageSync);
      this.Channel = "0";
      this.MessageValidating += new EventHandler<MessageEventArgs>(this.HandleMessageValidating);
    }

    private async void HandleMessageValidating(object sender, MessageEventArgs e)
    {
      e.IsValidProtocol = e.Message.Header.ProtocolVersion.CompareTo(this.ProtocolVersion) == 0;
      e.IsNewerProtocol = e.Message.Header.ProtocolVersion.CompareTo(this.ProtocolVersion) > 0;
      e.IsValidChannel = e.Message.Header.RoomId == this.Channel;
      e.IsSuperChannel = EnumHelper.GetByKey<SuperChannel>(e.Message.Header.RoomId) != 0;
    }

    private async void HandleReceivedMessageSync(object sender, MessageEventArgs e)
    {
      this.Ack(e.Message.Header.RoomId);
    }

    public virtual async void AdvertiseChannel(string channelObj)
    {
      this.SendMessage(new ChatMessage(this.ProtocolVersion, SuperChannel.Site.GetKey(), MessageType.ChannelAdvertise, this.Host, this.UserName, DateTime.Now, channelObj));
    }

    public virtual async Task Initialize(IIPAddressManager ipaddress)
    {
      if (!this.DetectNetworkChanges(ipaddress))
        return;
      this.HostNames = ipaddress.GetIPAddresses();
      IEnumerable<string> hostNames = this.HostNames;
      if ((hostNames != null ? (hostNames.Count<string>() > 0 ? 1 : 0) : 0) != 0)
      {
        this.Username();
        this.SetupBroadcaster();
        this.StartListen(true);
      }
      else
      {
        this._HostNames = (IEnumerable<string>) new List<string>()
        {
          "172.0.0.1"
        };
        this._Username = "localhost";
        this.RaiseError(new ErrorEventArgs(ErrorType.System, new Exception("No Network Available!!")));
      }
    }

    protected virtual async Task SetupBroadcaster()
    {
      if (this.IsBroadcastSetup)
        return;
      this._Broadcaster = new UdpSocketClient();
      this.IsBroadcastSetup = true;
    }

    protected virtual async Task StartListen(bool allAdapters = false)
    {
      if (this.IsListening)
        return;
      string[] strArray = this._ReceivingPorts;
      for (int index = 0; index < strArray.Length; ++index)
      {
        string str = strArray[index];
        UdpSocketReceiver _Listener = new UdpSocketReceiver();
        _Listener.MessageReceived += new EventHandler<UdpSocketMessageReceivedEventArgs>(this._Listener_MessageReceived);
        await _Listener.StartListeningAsync(Convert.ToInt32(str));
        this.Listeners.Add(_Listener);
        _Listener = (UdpSocketReceiver) null;
      }
      strArray = (string[]) null;
      this.IsListening = true;
    }

    public virtual void CleanUp()
    {
      foreach (UdpSocketReceiver listener in this.Listeners)
        listener.StopListeningAsync();
      this.IsListening = false;
    }

    public virtual bool DetectNetworkChanges(IIPAddressManager ipaddress)
    {
      bool flag = this.HostNames == null;
      if (this.HostNames != null)
      {
        foreach (string ipAddress in ipaddress.GetIPAddresses())
        {
          if (!this.HostNames.Contains<string>(ipAddress))
          {
            flag = true;
            break;
          }
        }
      }
      if (flag)
      {
        this.IsBroadcastSetup = false;
        this.IsListening = false;
      }
      return flag;
    }

    protected async void _Listener_MessageReceived(
      object sender,
      UdpSocketMessageReceivedEventArgs args)
    {
      try
      {
        await this.ProcessMessageReceived(args.RemoteAddress, Encoding.UTF8.GetString(args.ByteData, 0, args.ByteData.Length));
      }
      catch (Exception ex)
      {
        this.OnMessageReceivedError(new ErrorEventArgs(ErrorType.Unknown, ex));
      }
    }

    protected async Task ProcessMessageReceived(string ip, string text)
    {
      if (this._IgnoreSelf && this.IPAddresses.Contains<string>(ip))
        return;
      string[] strArray1 = text.Split(UdpMessaging._StringTerminator);
      if (strArray1.Length < 1)
        return;
      string[] strArray = strArray1;
      for (int index = 0; index < strArray.Length; ++index)
      {
        string content = strArray[index];
        if (!string.IsNullOrEmpty(content))
        {
          MessageEventArgs e = new MessageEventArgs();
          e.Sender = ip;
          e.Data = content;
          e.Message = new ChatMessage(content);
          e.DisplayName = ip;
          await this.OnMessageReceived(e);
        }
      }
      strArray = (string[]) null;
    }

    protected async Task<string> Username()
    {
      if (string.IsNullOrEmpty(this._Username))
        this._Username = this.Host;
      return this._Username;
    }

    public string UserName
    {
      get => this._Username;
      set => this._Username = value;
    }

    protected async void OnSiteMessageReceived(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> siteMessageReceived = this.SiteMessageReceived;
      if (siteMessageReceived == null)
        return;
      siteMessageReceived((object) this, e);
    }

    protected async void OnMessageLost(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageLost = this.MessageLost;
      if (messageLost == null)
        return;
      messageLost((object) this, e);
    }

    protected async void OnConfirmMessageLost(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> confirmMessageLost = this.ConfirmMessageLost;
      if (confirmMessageLost == null)
        return;
      confirmMessageLost((object) this, e);
    }

    protected async void OnMessageReceivedError(ErrorEventArgs e)
    {
      EventHandler<ErrorEventArgs> messageReceivedError = this.MessageReceivedError;
      if (messageReceivedError == null)
        return;
      messageReceivedError((object) this, e);
    }

    protected async Task OnMessageConfirmed(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageConfirmed = this.MessageConfirmed;
      if (messageConfirmed == null)
        return;
      messageConfirmed((object) this, e);
    }

    protected async Task OnMessageFullyConfirmed(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageFullyConfirmed = this.MessageFullyConfirmed;
      if (messageFullyConfirmed == null)
        return;
      messageFullyConfirmed((object) this, e);
    }

    protected async Task OnMessageReconfirmed(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageReconfirmed = this.MessageReconfirmed;
      if (messageReconfirmed == null)
        return;
      messageReconfirmed((object) this, e);
    }

    protected virtual async void OnReceivedMessageAck(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivedMessageAck = this.ReceivedMessageAck;
      if (receivedMessageAck == null)
        return;
      receivedMessageAck((object) this, e);
    }

    protected virtual async void OnReceivedMessageNak(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivedMessageNak = this.ReceivedMessageNak;
      if (receivedMessageNak == null)
        return;
      receivedMessageNak((object) this, e);
    }

    protected virtual async void OnReceivedMessageSync(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivedMessageSync = this.ReceivedMessageSync;
      if (receivedMessageSync == null)
        return;
      receivedMessageSync((object) this, e);
    }

    protected virtual async void OnReceivedMessageConfirm(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivedMessageConfirm = this.ReceivedMessageConfirm;
      if (receivedMessageConfirm == null)
        return;
      receivedMessageConfirm((object) this, e);
    }

    protected virtual async void OnReceivedMessageText(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivedMessageText = this.ReceivedMessageText;
      if (receivedMessageText == null)
        return;
      receivedMessageText((object) this, e);
    }

    protected virtual async void OnReceivedMessageReconfirm(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageReconfirm = this.ReceivedMessageReconfirm;
      if (messageReconfirm == null)
        return;
      messageReconfirm((object) this, e);
    }

    protected virtual async void OnReceivedMessageRequest(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivedMessageRequest = this.ReceivedMessageRequest;
      if (receivedMessageRequest == null)
        return;
      receivedMessageRequest((object) this, e);
    }

    protected virtual async void OnReceivingMessageConfirm(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivingMessageConfirm = this.ReceivingMessageConfirm;
      if (receivingMessageConfirm != null)
        receivingMessageConfirm((object) this, e);
      this.OnReceivedMessageConfirm(e);
    }

    protected virtual async void OnReceivingMessageText(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivingMessageText = this.ReceivingMessageText;
      if (receivingMessageText != null)
        receivingMessageText((object) this, e);
      this.OnReceivedMessageText(e);
    }

    protected virtual async void OnReceivingMessageReconfirm(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageReconfirm = this.ReceivingMessageReconfirm;
      if (messageReconfirm != null)
        messageReconfirm((object) this, e);
      this.OnReceivedMessageReconfirm(e);
    }

    protected virtual async void OnReceivingMessageRequest(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> receivingMessageRequest = this.ReceivingMessageRequest;
      if (receivingMessageRequest != null)
        receivingMessageRequest((object) this, e);
      this.OnReceivedMessageRequest(e);
    }

    protected virtual async Task OnMessageReceived(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageReceived = this.MessageReceived;
      if (messageReceived != null)
        messageReceived((object) this, e);
      if (!e.IsValidChannel)
        return;
      if (e.Message.Header.MessageType == MessageType.ACK)
        this.OnReceivedMessageAck(e);
      else if (e.Message.Header.MessageType == MessageType.NAK)
      {
        this.OnReceivedMessageNak(e);
      }
      else
      {
        if (e.Message.Header.MessageType != MessageType.SYN)
          return;
        this.OnReceivedMessageSync(e);
      }
    }

    public virtual async Task RaiseError(ErrorEventArgs e) => this.OnMessageReceivedError(e);

    protected virtual async Task BroadCast(string message)
    {
      if (!this.IsBroadcastSetup)
        return;
      byte[] bytes = Encoding.UTF8.GetBytes(message);
      foreach (string receivingPort in this._ReceivingPorts)
        this._Broadcaster.SendToAsync(bytes, this._BroadcastAddress, Convert.ToInt32(receivingPort));
    }

    public virtual async Task SendMessage(ChatMessage content)
    {
      await this.BroadCast(content.BuildSendString());
    }

    public async Task Ack(string roomName)
    {
      this.BroadCast(new ChatMessage(this.ProtocolVersion, roomName, MessageType.ACK, this.Host, this._Username, DateTime.Now, "").BuildSendString());
    }

    public async Task Syn(string roomName)
    {
      this.BroadCast(new ChatMessage(this.ProtocolVersion, roomName, MessageType.SYN, this.Host, this._Username, DateTime.Now, "").BuildSendString());
    }

    public async Task Nak(string roomName)
    {
      this.BroadCast(new ChatMessage(this.ProtocolVersion, roomName, MessageType.NAK, this.Host, this._Username, DateTime.Now, "").BuildSendString());
    }

    public MessageType GetMessageType(string msg)
    {
      ChatMessage chatMessage = new ChatMessage(msg);
      return chatMessage.Header.MessageId != null ? chatMessage.Header.MessageType : MessageType.Unknown;
    }

    public IEnumerable<string> IPAddresses => this.HostNames;

    public IEnumerable<string> HostNames
    {
      get => this._HostNames;
      private set => this._HostNames = value;
    }

    public string Host
    {
      get
      {
        if (this._Host == null)
          this._Host = this.HostNames.FirstOrDefault<string>();
        return this._Host;
      }
    }

    protected virtual async Task OnMessageValidating(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageValidating = this.MessageValidating;
      if (messageValidating != null)
        messageValidating((object) this, e);
      this.OnMessageValidated(e);
    }

    protected virtual async void OnMessageValidated(MessageEventArgs e)
    {
      EventHandler<MessageEventArgs> messageValidated = this.MessageValidated;
      if (messageValidated == null)
        return;
      messageValidated((object) this, e);
    }

    public virtual Version ProtocolVersion
    {
      get
      {
        if (this._ProtocolVersion == (Version) null)
          this._ProtocolVersion = new Version("1.3");
        return this._ProtocolVersion;
      }
    }
  }
}

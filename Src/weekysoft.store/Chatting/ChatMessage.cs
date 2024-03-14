// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Chatting.ChatMessage
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using weekysoft.store.Messaging;

#nullable disable
namespace weekysoft.store.Chatting
{
  public class ChatMessage : IChatElement, INotifyPropertyChanged
  {
    private static readonly char _ElementSeparator = char.MinValue;
    public bool _IsMyMessage;
    private bool _IsConfirmed;
    private bool _IsFullyConfirmed;
    private bool _IsLost;
    private bool _IsBanner;
    private static char[] _ElementSeparators = new char[1]
    {
      ChatMessage._ElementSeparator
    };

    public string Body { get; private set; }

    public int Confirmations { get; private set; }

    public int Reconfirmations { get; private set; }

    public int Losts { get; private set; }

    public ChatHeader Header { get; private set; }

    private ChatMessage()
    {
      this.Confirmations = 0;
      this.Reconfirmations = 0;
      this.Losts = 0;
    }

    public ChatMessage(
      Version version,
      string channel,
      MessageType messageType,
      string senderIP,
      string sender,
      DateTime datetime,
      string message,
      string originalMessageId = "",
      string requestMessageId = "",
      int expectedRecipients = 1)
      : this()
    {
      this.Header = new ChatHeader(version, channel, messageType, senderIP, sender, datetime, originalMessageId, requestMessageId, expectedRecipients);
      this.Body = message;
    }

    public ChatMessage(string content)
      : this()
    {
      this.Parse(content);
    }

    public string BuildSendString()
    {
      char elementSeparator = ChatMessage._ElementSeparator;
      string str1 = string.Join(elementSeparator.ToString(), new string[2]
      {
        this.Header.BuildSendString(),
        this.Body
      });
      elementSeparator = ChatMessage._ElementSeparator;
      string str2 = elementSeparator.ToString();
      return str1 + str2;
    }

    public bool IsMyMessage
    {
      get => this._IsMyMessage && !this.IsBanner;
      set => this._IsMyMessage = value;
    }

    public bool IsConfirmed
    {
      get => this._IsConfirmed;
      set
      {
        this._IsConfirmed = value;
        this.NotifyPropertyChanged("BackgroundColor");
      }
    }

    public bool IsFullyConfirmed
    {
      get => this._IsFullyConfirmed;
      set
      {
        this._IsFullyConfirmed = value;
        this.NotifyPropertyChanged("BackgroundColor");
      }
    }

    public bool IsLost
    {
      get => this._IsLost;
      set
      {
        this._IsLost = value;
        this.NotifyPropertyChanged("BackgroundColor");
      }
    }

    public string Horizontal => this.IsMyMessage ? "End" : "Start";

    public bool IsBanner
    {
      get => this._IsBanner;
      set
      {
        this._IsBanner = value;
        this.NotifyPropertyChanged("IsMyMessage");
        this.NotifyPropertyChanged("IsPeerMessage");
        this.NotifyPropertyChanged("BackgroundColor");
      }
    }

    public bool IsSending { get; set; }

    public bool IsErrorMessage { get; set; }

    public bool IsPeerMessage => !this.IsMyMessage & !this.IsBanner;

    public string BackgroundColor
    {
      get
      {
        if (this.IsErrorMessage)
          return "#FFFFE0";
        if (this.IsBanner)
          return "#262626";
        if (!this.IsMyMessage)
          return "#FFFFE0";
        if (this.IsFullyConfirmed)
          return "#FFFFFF";
        if (this.IsConfirmed)
          return "#F0FFFF";
        if (this.IsLost)
          return "#808080";
        return this.IsSending ? "#ADD8E6" : "White";
      }
    }

    public string ForegroundColor
    {
      get
      {
        if (this.IsErrorMessage)
          return "Red";
        if (this.IsBanner)
          return "#C3C3C3";
        int num = this.IsMyMessage ? 1 : 0;
        return "Black";
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      if (!(propertyName != ""))
        return;
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    public void Parse(string content)
    {
      string[] strArray = content.Split(ChatMessage._ElementSeparators, 2);
      if (strArray.Length != 2)
        return;
      this.Header = new ChatHeader(strArray[0]);
      this.Body = strArray[1];
    }

    public bool IsSystemMessage()
    {
      return this.Header.MessageType == MessageType.ACK || this.Header.MessageType == MessageType.NAK || this.Header.MessageType == MessageType.SYN || this.Header.MessageType == MessageType.ChannelAdvertise || this.Header.MessageType == MessageType.ChannelUpdate;
    }

    public static ChatMessage CreateConfirmMessage(ChatMessage msg, string sender, string senderIP)
    {
      return new ChatMessage(msg.Header.ProtocolVersion, msg.Header.RoomId, MessageType.Confirm, senderIP, sender, msg.Header.DateTime, msg.BuildSendString(), msg.Header.MessageId);
    }

    public string Value => this.BuildSendString();

    public override bool Equals(object obj)
    {
      return obj is ChatMessage ? ((ChatMessage) obj).Header.MessageId == this.Header.MessageId : base.Equals(obj);
    }

    public static ChatMessage CreateReconfirmMessage(
      ChatMessage msg,
      string sender,
      string senderIP)
    {
      return new ChatMessage(msg.Header.ProtocolVersion, msg.Header.RoomId, MessageType.Reconfirm, senderIP, sender, msg.Header.DateTime, string.Empty, msg.Header.MessageId);
    }

    public static ChatMessage CreateRequestMessage(
      ChatMessage msg,
      string sender,
      string senderIP,
      string previousMessageId)
    {
      return new ChatMessage(msg.Header.ProtocolVersion, msg.Header.RoomId, MessageType.RequestMessage, senderIP, sender, DateTime.Now, string.Empty, string.Empty, previousMessageId);
    }

    internal void MarkLost() => ++this.Losts;

    internal void MarkConfirmed() => ++this.Confirmations;

    internal void MarkReconfirmed() => ++this.Reconfirmations;
  }
}

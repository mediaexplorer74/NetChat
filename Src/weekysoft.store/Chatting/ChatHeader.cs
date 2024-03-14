// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Chatting.ChatHeader
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Linq;
using weekysoft.store.Enums;
using weekysoft.store.Messaging;
using weekysoft.store.Util;


namespace weekysoft.store.Chatting
{
  public class ChatHeader : IChatElement
  {
    private static int _HeaderCount = 0;
    private static char _HeaderElementSeparator = '\v';
    private static char[] _HeaderElementSeparators = new char[1]
    {
      ChatHeader._HeaderElementSeparator
    };
    private static Version _DefaultVersion = new Version("0.0");

    private static int HeaderCount
    {
      get
      {
        if (ChatHeader._HeaderCount > 9999)
          ChatHeader._HeaderCount = 0;
        return ChatHeader._HeaderCount;
      }
      set => ChatHeader._HeaderCount = value;
    }

    public string RoomId { get; private set; }

    public MessageType MessageType { get; private set; }

    public string SenderGender { get; set; }

    public string Sender { get; private set; }

    public string SenderIP { get; private set; }

    public DateTime DateTime { get; private set; }

    public string MessageId { get; private set; }

    public string OriginalMessageId { get; private set; }

    public static string _PreviousMessageId { get; private set; }

    public string PreviousMessageId { get; private set; }

    public string RequestMessageId { get; private set; }

    public Version ProtocolVersion { get; private set; }

    public bool Relay { get; private set; }

    public int ExpectedRecipients { get; private set; }

    public ChatHeader(
      Version version,
      string roomId,
      MessageType messageType,
      string senderIP,
      string sender,
      DateTime dateTime,
      string originalMessageId = "",
      string requestMessageId = "",
      int expectedRecipients = 1)
    {
      ++ChatHeader.HeaderCount;
      this.ProtocolVersion = version;
      this.RoomId = roomId;
      this.MessageType = messageType;
      this.Sender = sender;
      this.SenderIP = senderIP;
      this.DateTime = dateTime;
      this.OriginalMessageId = originalMessageId;
      this.RequestMessageId = requestMessageId;
      this.MessageId = Base64Util.GenerateUniqueId(senderIP);
      this.ExpectedRecipients = expectedRecipients;
      if (messageType == MessageType.Text)
      {
        this.PreviousMessageId = ChatHeader._PreviousMessageId;
        ChatHeader._PreviousMessageId = this.MessageId;
      }
      this.SenderGender = Gender.Unknown.GetKey();
    }

    public string ConvertToBase64(DateTime dt)
    {
      return Convert.ToBase64String(BitConverter.GetBytes(dt.Ticks));
    }

    public void AssignErrorMessageId() => this.MessageId = Base64Util.GenerateErrorUniqueId();

    public DateTime ConvertToDateTime(string base64Str)
    {
      byte[] numArray = Convert.FromBase64String(base64Str);
      return numArray != null ? new DateTime(BitConverter.ToInt64(numArray, 0)) : DateTime.Now;
    }

    public string GenerateMessageId()
    {
      string[] strArray = this.SenderIP.Split('.');
      int num = Convert.ToInt32(strArray[2]) * 256 + Convert.ToInt32(strArray[3]);
      DateTime dateTime = DateTime.Now;
      long ticks1 = dateTime.Ticks;
      dateTime = DateTime.Today;
      long ticks2 = dateTime.Ticks;
      int int32 = Convert.ToInt32((ticks1 - ticks2) / 10000000L);
      int day = DateTime.Now.Day;
      return Convert.ToBase64String(((IEnumerable<byte>) BitConverter.GetBytes(Convert.ToUInt16(num))).AsEnumerable<byte>().Concat<byte>(((IEnumerable<byte>) BitConverter.GetBytes(Convert.ToUInt32((uint) (day * 100000000)) + Convert.ToUInt32(int32 * 10000 + ChatHeader.HeaderCount))).AsEnumerable<byte>()).ToArray<byte>());
    }

    public ChatHeader(string headString) => this.Parse(headString);

    public string BuildSendString()
    {
      return string.Format(string.Join(ChatHeader._HeaderElementSeparator.ToString(), new List<IChatElement>()
      {
        (IChatElement) new ChatElement(ElementType.ProtocolVersion, this.ProtocolVersion.ToString()),
        (IChatElement) new ChatElement(ElementType.MessageId, this.MessageId),
        (IChatElement) new ChatElement(ElementType.RoomId, this.RoomId),
        (IChatElement) new ChatElement(ElementType.MessageType, this.MessageType.GetKey()),
        (IChatElement) new ChatElement(ElementType.Sender, this.Sender),
        (IChatElement) new ChatElement(ElementType.SenderIP, this.SenderIP),
        (IChatElement) new ChatElement(ElementType.DateTime, this.ConvertToBase64(this.DateTime)),
        (IChatElement) new ChatElement(ElementType.PreviousMessageId, this.PreviousMessageId),
        (IChatElement) new ChatElement(ElementType.OriginalMessageId, this.OriginalMessageId),
        (IChatElement) new ChatElement(ElementType.RequestMessageId, this.RequestMessageId),
        (IChatElement) new ChatElement(ElementType.Relay, this.Relay ? "1" : "0"),
        (IChatElement) new ChatElement(ElementType.ExpectedRecipients, this.ExpectedRecipients.ToString())
      }.Select<IChatElement, string>((Func<IChatElement, string>) (s => s.BuildSendString()))));
    }

    public void Parse(string hdstring)
    {
      string[] messageParts = hdstring.Split(ChatHeader._HeaderElementSeparators);
      this.MessageId = ChatElement.Extract(ElementType.MessageId, messageParts).Value;
      this.RoomId = ChatElement.Extract(ElementType.RoomId, messageParts).Value;
      this.MessageType = EnumHelper.GetByKey<MessageType>(ChatElement.Extract(ElementType.MessageType, messageParts).Value);
      this.Sender = ChatElement.Extract(ElementType.Sender, messageParts).Value;
      this.SenderIP = ChatElement.Extract(ElementType.SenderIP, messageParts).Value;
      this.DateTime = this.ConvertToDateTime(ChatElement.Extract(ElementType.DateTime, messageParts).Value);
      this.PreviousMessageId = ChatElement.Extract(ElementType.PreviousMessageId, messageParts).Value;
      this.OriginalMessageId = ChatElement.Extract(ElementType.OriginalMessageId, messageParts).Value;
      this.RequestMessageId = ChatElement.Extract(ElementType.RequestMessageId, messageParts).Value;
      string version = ChatElement.Extract(ElementType.ProtocolVersion, messageParts).Value;
      this.ProtocolVersion = string.IsNullOrEmpty(version) ? ChatHeader._DefaultVersion : new Version(version);
      this.Relay = ChatElement.Extract(ElementType.Relay, messageParts).Value == "1";
      int result = 1;
      int.TryParse(ChatElement.Extract(ElementType.ExpectedRecipients, messageParts).Value, out result);
      this.ExpectedRecipients = result;
    }

    public string Value => this.BuildSendString();

    internal void MarkRelay() => this.Relay = true;
  }
}

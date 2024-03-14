// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Chatting.ElementType
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Attributes;

#nullable disable
namespace weekysoft.store.Chatting
{
  public enum ElementType
  {
    [EntityKey("M")] Message = 1,
    [EntityKey("R")] RoomId = 2,
    [EntityKey("T")] MessageType = 3,
    [EntityKey("SI")] SenderIP = 4,
    [EntityKey("S")] Sender = 5,
    [EntityKey("D")] DateTime = 6,
    [EntityKey("I")] MessageId = 7,
    [EntityKey("O")] OriginalMessageId = 8,
    [EntityKey("V")] ProtocolVersion = 9,
    [EntityKey("L")] Relay = 10, // 0x0000000A
    [EntityKey("E")] ExpectedRecipients = 11, // 0x0000000B
    [EntityKey("PP")] ProfilePicture = 12, // 0x0000000C
    [EntityKey("P")] PreviousMessageId = 13, // 0x0000000D
    [EntityKey("Q")] RequestMessageId = 14, // 0x0000000E
  }
}

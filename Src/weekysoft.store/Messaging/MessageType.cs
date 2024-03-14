// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.MessageType
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Attributes;

#nullable disable
namespace weekysoft.store.Messaging
{
  public enum MessageType
  {
    [EntityKey("U")] Unknown,
    [EntityKey("T")] Text,
    [EntityKey("A")] ACK,
    [EntityKey("S")] SYN,
    [EntityKey("N")] NAK,
    [EntityKey("C")] Confirm,
    [EntityKey("R")] Reconfirm,
    [EntityKey("L")] Lost,
    [EntityKey("I")] Image,
    [EntityKey("P")] ProfileImage,
    [EntityKey("Q")] RequestMessage,
    [EntityKey("CA")] ChannelAdvertise,
    [EntityKey("CU")] ChannelUpdate,
  }
}

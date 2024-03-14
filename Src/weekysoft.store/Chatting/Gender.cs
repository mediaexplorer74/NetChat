// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Chatting.Gender
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Attributes;

#nullable disable
namespace weekysoft.store.Chatting
{
  public enum Gender
  {
    [EntityKey("M")] Male = 1,
    [EntityKey("F")] Female = 2,
    [EntityKey("U")] Unknown = 3,
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.ErrorType
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Attributes;


namespace weekysoft.store.Messaging
{
  public enum ErrorType
  {
    [EntityKey("P")] ProtocolMismatch,
    [EntityKey("S")] System,
    [EntityKey("U")] Unknown,
  }
}
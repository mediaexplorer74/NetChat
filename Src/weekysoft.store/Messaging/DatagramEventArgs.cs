﻿// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.DatagramEventArgs
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;

#nullable disable
namespace weekysoft.store.Messaging
{
  public class DatagramEventArgs : EventArgs
  {
    public string Sender { get; set; }

    public string Data { get; set; }

    public string DisplayName { get; set; }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.MessageStatus
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;


namespace weekysoft.store.Messaging
{
  public class MessageStatus
  {
    public MessageStatus()
    {
      this.ReceivedDateTime = DateTime.Now;
      this.HasPreceedingMessage = false;
    }

    public DateTime ReceivedDateTime { get; set; }

    public bool HasPreceedingMessage { get; set; }
  }
}

// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.ErrorEventArgs
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using weekysoft.store.Util;


namespace weekysoft.store.Messaging
{
  public class ErrorEventArgs : EventArgs
  {
    public string ErrorId { get; private set; }

    public ErrorType ErrorType { get; private set; }

    public Exception Exception { get; private set; }

    public ErrorEventArgs(ErrorType type, Exception ex, string errorIdSubfix = "")
    {
      this.ErrorType = type;
      this.Exception = ex;
      this.ErrorId = Base64Util.GenerateErrorUniqueId() + errorIdSubfix;
    }
  }
}

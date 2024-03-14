// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.PopUpEventArgs`2
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;


namespace Coding4Fun.Toolkit.Controls
{
  public class PopUpEventArgs<T, TPopUpResult> : EventArgs
  {
    public TPopUpResult PopUpResult { get; set; }

    public Exception Error { get; set; }

    public T Result { get; set; }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.PropertyChangedEventArgs`1
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class PropertyChangedEventArgs<T> : EventArgs
  {
    public PropertyChangedEventArgs(T oldValue, T newValue)
    {
      this.OldValue = oldValue;
      this.NewValue = newValue;
    }

    public T OldValue { get; set; }

    public T NewValue { get; set; }
  }
}

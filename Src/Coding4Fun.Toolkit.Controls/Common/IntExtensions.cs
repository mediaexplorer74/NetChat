// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.IntExtensions
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Common
{
  [Obsolete("Moved to Coding4Fun.Toolkit.dll now, Namespace is System, ")]
  public static class IntExtensions
  {
    public static double CheckBound(this int value, int maximum)
    {
      return System.IntExtensions.CheckBound(value, maximum);
    }

    public static double CheckBound(this int value, int minimum, int maximum)
    {
      return System.IntExtensions.CheckBound(value, minimum, maximum);
    }
  }
}

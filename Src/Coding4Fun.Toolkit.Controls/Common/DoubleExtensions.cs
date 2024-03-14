// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.DoubleExtensions
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;


namespace Coding4Fun.Toolkit.Controls.Common
{
  [Obsolete("Moved to Coding4Fun.Toolkit.dll now, Namespace is System, ")]
  public static class DoubleExtensions
  {
    public static double CheckBound(this double value, double maximum)
    {
      return System.DoubleExtensions.CheckBound(value, maximum);
    }

    public static double CheckBound(this double value, double minimum, double maximum)
    {
      return System.DoubleExtensions.CheckBound(value, minimum, maximum);
    }

    public static bool AlmostEquals(this double a, double b, double precision = 4.94065645841247E-324)
    {
      return System.DoubleExtensions.AlmostEquals(a, b, precision);
    }
  }
}

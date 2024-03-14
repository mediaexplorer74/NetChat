// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.FloatExtensions
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;


namespace Coding4Fun.Toolkit.Controls.Common
{
  [Obsolete("Moved to Coding4Fun.Toolkit.dll now, Namespace is System")]
  public static class FloatExtensions
  {
    public static double CheckBound(this float value, float maximum)
    {
      return System.FloatExtensions.CheckBound(value, maximum);
    }

    public static double CheckBound(this float value, float minimum, float maximum)
    {
      return System.FloatExtensions.CheckBound(value, minimum, maximum);
    }

    public static bool AlmostEquals(this float a, float b, double precision = 1.4012984643248171E-45)
    {
      return System.FloatExtensions.AlmostEquals(a, b, precision);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: System.DoubleExtensions
// Assembly: Coding4Fun.Toolkit, Version=2.0.8.0, Culture=neutral, PublicKeyToken=c5fd7b72b1a17ce4
// MVID: 3554EA1B-1C3D-465C-8F26-35FED8224A72
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.dll


namespace System
{
  public static class DoubleExtensions
  {
    public static double CheckBound(this double value, double maximum)
    {
      return value.CheckBound(0.0, maximum);
    }

    public static double CheckBound(this double value, double minimum, double maximum)
    {
      if (value <= minimum)
        value = minimum;
      else if (value >= maximum)
        value = maximum;
      return value;
    }

    public static bool AlmostEquals(this double a, double b, double precision = 4.94065645841247E-324)
    {
      return Math.Abs(a - b) <= precision;
    }
  }
}

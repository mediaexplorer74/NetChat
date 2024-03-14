// Decompiled with JetBrains decompiler
// Type: System.IntExtensions
// Assembly: Coding4Fun.Toolkit, Version=2.0.8.0, Culture=neutral, PublicKeyToken=c5fd7b72b1a17ce4
// MVID: 3554EA1B-1C3D-465C-8F26-35FED8224A72
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.dll

#nullable disable
namespace System
{
  public static class IntExtensions
  {
    public static double CheckBound(this int value, int maximum) => value.CheckBound(0, maximum);

    public static double CheckBound(this int value, int minimum, int maximum)
    {
      if (value <= minimum)
        value = minimum;
      else if (value >= maximum)
        value = maximum;
      return (double) value;
    }
  }
}

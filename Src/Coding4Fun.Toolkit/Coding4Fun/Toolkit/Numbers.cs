// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Numbers
// Assembly: Coding4Fun.Toolkit, Version=2.0.8.0, Culture=neutral, PublicKeyToken=c5fd7b72b1a17ce4
// MVID: 3554EA1B-1C3D-465C-8F26-35FED8224A72
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.dll

using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Coding4Fun.Toolkit
{
  public static class Numbers
  {
    public static float Max(params int[] numbers) => (float) ((IEnumerable<int>) numbers).Max();

    public static float Min(params int[] numbers) => (float) ((IEnumerable<int>) numbers).Min();

    public static float Max(params float[] numbers) => ((IEnumerable<float>) numbers).Max();

    public static float Min(params float[] numbers) => ((IEnumerable<float>) numbers).Min();

    public static double Max(params double[] numbers) => ((IEnumerable<double>) numbers).Max();

    public static double Min(params double[] numbers) => ((IEnumerable<double>) numbers).Min();
  }
}

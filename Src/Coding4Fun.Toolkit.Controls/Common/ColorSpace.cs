// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.ColorSpace
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Common
{
  public class ColorSpace
  {
    private const byte MinValue = 0;
    private const byte MaxValue = 255;
    private const byte DefaultAlphaValue = 255;
    private static readonly Color[] ColorGradients = new Color[6]
    {
      Color.FromArgb(byte.MaxValue, byte.MaxValue, (byte) 0, (byte) 0),
      Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 0),
      Color.FromArgb(byte.MaxValue, (byte) 0, byte.MaxValue, (byte) 0),
      Color.FromArgb(byte.MaxValue, (byte) 0, byte.MaxValue, byte.MaxValue),
      Color.FromArgb(byte.MaxValue, (byte) 0, (byte) 0, byte.MaxValue),
      Color.FromArgb(byte.MaxValue, byte.MaxValue, (byte) 0, byte.MaxValue)
    };
    private static readonly Color[] BlackAndWhiteGradients = new Color[6]
    {
      Color.FromArgb(byte.MaxValue, (byte) 76, (byte) 76, (byte) 76),
      Color.FromArgb(byte.MaxValue, (byte) 225, (byte) 225, (byte) 225),
      Color.FromArgb(byte.MaxValue, (byte) 149, (byte) 149, (byte) 149),
      Color.FromArgb(byte.MaxValue, (byte) 178, (byte) 178, (byte) 178),
      Color.FromArgb(byte.MaxValue, (byte) 29, (byte) 29, (byte) 29),
      Color.FromArgb(byte.MaxValue, (byte) 105, (byte) 105, (byte) 105)
    };

    public static LinearGradientBrush GetColorGradientBrush(Orientation orientation)
    {
      return ColorSpace.CreateGradientBrush(orientation, ColorSpace.ColorGradients);
    }

    public static LinearGradientBrush GetBlackAndWhiteGradientBrush(Orientation orientation)
    {
      return ColorSpace.CreateGradientBrush(orientation, ColorSpace.BlackAndWhiteGradients);
    }

    private static LinearGradientBrush CreateGradientBrush(
      Orientation orientation,
      params Color[] colors)
    {
      LinearGradientBrush gradientBrush = new LinearGradientBrush();
      float num = 1f / (float) colors.Length;
      for (int index = 0; index < colors.Length; ++index)
      {
        GradientStopCollection gradientStops = ((GradientBrush) gradientBrush).GradientStops;
        GradientStop gradientStop = new GradientStop();
        gradientStop.put_Offset((double) num * (double) index);
        gradientStop.put_Color(colors[index]);
        ((ICollection<GradientStop>) gradientStops).Add(gradientStop);
      }
      GradientStopCollection gradientStops1 = ((GradientBrush) gradientBrush).GradientStops;
      GradientStop gradientStop1 = new GradientStop();
      gradientStop1.put_Offset((double) num * (double) colors.Length);
      gradientStop1.put_Color(colors[0]);
      ((ICollection<GradientStop>) gradientStops1).Add(gradientStop1);
      if (orientation == null)
      {
        gradientBrush.put_StartPoint(new Point(0.0, 1.0));
        gradientBrush.put_EndPoint(new Point());
      }
      else
        gradientBrush.put_EndPoint(new Point(1.0, 0.0));
      return gradientBrush;
    }

    public static Color GetColorFromHueValue(float position)
    {
      position /= 360f;
      position *= (float) (ColorSpace.ColorGradients.Length * (int) byte.MaxValue);
      byte num1 = (byte) ((double) position % (double) byte.MaxValue);
      byte num2 = (byte) ((uint) byte.MaxValue - (uint) num1);
      switch ((int) position / (int) byte.MaxValue)
      {
        case 0:
          return Color.FromArgb(byte.MaxValue, byte.MaxValue, num1, (byte) 0);
        case 1:
          return Color.FromArgb(byte.MaxValue, num2, byte.MaxValue, (byte) 0);
        case 2:
          return Color.FromArgb(byte.MaxValue, (byte) 0, byte.MaxValue, num1);
        case 3:
          return Color.FromArgb(byte.MaxValue, (byte) 0, num2, byte.MaxValue);
        case 4:
          return Color.FromArgb(byte.MaxValue, num1, (byte) 0, byte.MaxValue);
        case 5:
          return Color.FromArgb(byte.MaxValue, byte.MaxValue, (byte) 0, num2);
        default:
          return Colors.Black;
      }
    }

    public static string GetHexCode(Color c)
    {
      return string.Format("#{0}{1}{2}", (object) c.R.ToString("X2"), (object) c.G.ToString("X2"), (object) c.B.ToString("X2"));
    }

    public static Color ConvertHsvToRgb(float hue, float saturation, float value)
    {
      hue /= 360f;
      if ((double) saturation > 0.0)
      {
        if ((double) hue >= 1.0)
          hue = 0.0f;
        hue = 6f * hue;
        int num1 = (int) Math.Floor((double) hue);
        byte num2 = (byte) Math.Round((double) byte.MaxValue * (double) value * (1.0 - (double) saturation));
        byte num3 = (byte) Math.Round((double) byte.MaxValue * (double) value * (1.0 - (double) saturation * ((double) hue - (double) num1)));
        byte num4 = (byte) Math.Round((double) byte.MaxValue * (double) value * (1.0 - (double) saturation * (1.0 - ((double) hue - (double) num1))));
        byte num5 = (byte) Math.Round((double) byte.MaxValue * (double) value);
        switch (num1)
        {
          case 0:
            return Color.FromArgb(byte.MaxValue, num5, num4, num2);
          case 1:
            return Color.FromArgb(byte.MaxValue, num3, num5, num2);
          case 2:
            return Color.FromArgb(byte.MaxValue, num2, num5, num4);
          case 3:
            return Color.FromArgb(byte.MaxValue, num2, num3, num5);
          case 4:
            return Color.FromArgb(byte.MaxValue, num4, num2, num5);
          case 5:
            return Color.FromArgb(byte.MaxValue, num5, num2, num3);
          default:
            return Color.FromArgb((byte) 0, (byte) 0, (byte) 0, (byte) 0);
        }
      }
      else
      {
        byte num = (byte) ((double) value * (double) byte.MaxValue);
        return Color.FromArgb(byte.MaxValue, num, num, num);
      }
    }
  }
}

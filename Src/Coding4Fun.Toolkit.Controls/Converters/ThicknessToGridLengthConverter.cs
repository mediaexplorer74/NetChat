// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.ThicknessToGridLengthConverter
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Globalization;
using Windows.UI.Xaml;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Converters
{
  public class ThicknessToGridLengthConverter : ValueConverter
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      if (value == null || parameter == null)
        return (object) new GridLength();
      object obj = Enum.Parse(typeof (ThicknessProperties), parameter.ToString(), true);
      Thickness thickness = (Thickness) value;
      if (obj == null)
        return (object) new GridLength();
      double pixels;
      switch ((ThicknessProperties) obj)
      {
        case ThicknessProperties.Left:
          pixels = thickness.Left;
          break;
        case ThicknessProperties.Right:
          pixels = thickness.Right;
          break;
        case ThicknessProperties.Bottom:
          pixels = thickness.Bottom;
          break;
        default:
          pixels = thickness.Top;
          break;
      }
      return (object) new GridLength(pixels);
    }

    public override object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      return (object) null;
    }
  }
}

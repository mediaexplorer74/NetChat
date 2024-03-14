// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.SolidColorBrushToColorConverter
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls.Converters
{
  public class SolidColorBrushToColorConverter : ValueConverter
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      SolidColorBrush solidColorBrush = value as SolidColorBrush;
      Color color = Colors.Transparent;
      if (solidColorBrush != null)
        color = solidColorBrush.Color;
      byte result;
      if (parameter != null && byte.TryParse((string) parameter, out result))
        color.A = result;
      return (object) color;
    }

    public override object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      throw new NotImplementedException();
    }
  }
}

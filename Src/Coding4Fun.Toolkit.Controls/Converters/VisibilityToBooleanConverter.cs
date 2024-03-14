// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.VisibilityToBooleanConverter
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Globalization;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Converters
{
  public class VisibilityToBooleanConverter : ValueConverter
  {
    private static readonly BooleanToVisibilityConverter BoolToVis = new BooleanToVisibilityConverter();

    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      return VisibilityToBooleanConverter.BoolToVis.ConvertBack(value, targetType, parameter, culture);
    }

    public override object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      return VisibilityToBooleanConverter.BoolToVis.Convert(value, targetType, parameter, culture);
    }
  }
}

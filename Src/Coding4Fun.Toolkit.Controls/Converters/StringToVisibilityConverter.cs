// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.StringToVisibilityConverter
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Globalization;
using Windows.UI.Xaml;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Converters
{
  public class StringToVisibilityConverter : ValueConverter
  {
    public bool Inverted { get; set; }

    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      return this.Inverted ? (object) (Visibility) (string.IsNullOrEmpty(value as string) ? 0 : 1) : (object) (Visibility) (string.IsNullOrEmpty(value as string) ? 1 : 0);
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

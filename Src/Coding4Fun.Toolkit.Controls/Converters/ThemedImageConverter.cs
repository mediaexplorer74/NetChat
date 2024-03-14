// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.ThemedImageConverter
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Globalization;


namespace Coding4Fun.Toolkit.Controls.Converters
{
  public class ThemedImageConverter : ValueConverter
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      string path = parameter as string;
      if (string.IsNullOrEmpty(path))
        path = value as string;
      return (object) ThemedImageConverterHelper.GetImage(path);
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

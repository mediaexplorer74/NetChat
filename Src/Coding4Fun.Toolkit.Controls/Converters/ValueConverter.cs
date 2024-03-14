// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.ValueConverter
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Globalization;
using Windows.UI.Xaml.Data;


namespace Coding4Fun.Toolkit.Controls.Converters
{
  public abstract class ValueConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return this.Convert(value, targetType, parameter, culture, (string) null);
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      return this.ConvertBack(value, targetType, parameter, culture, (string) null);
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
      return this.Convert(value, targetType, parameter, (CultureInfo) null, language);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      return this.ConvertBack(value, targetType, parameter, (CultureInfo) null, language);
    }

    public virtual object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture,
      string language)
    {
      throw new NotImplementedException();
    }

    public virtual object ConvertBack(
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

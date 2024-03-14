// Decompiled with JetBrains decompiler
// Type: IGM.UI.StringFormatConverter
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using Windows.UI.Xaml.Data;

namespace IGM.UI
{
  public sealed partial class StringFormatConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (parameter == null)
        return value;
      return (object) string.Format((string) parameter, value ?? (object) string.Empty);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}

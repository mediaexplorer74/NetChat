// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Converters.ThemedImageConverterHelper
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Converters
{
  public static class ThemedImageConverterHelper
  {
    private static readonly Dictionary<string, BitmapImage> ImageCache = new Dictionary<string, BitmapImage>();

    public static BitmapImage GetImage(string path, bool negateResult = false)
    {
      if (string.IsNullOrEmpty(path))
        return (BitmapImage) null;
      bool flag = Application.Current.RequestedTheme == 1;
      if (negateResult)
        flag = !flag;
      path = string.Format(path, flag ? (object) "dark" : (object) "light");
      BitmapImage image;
      if (!ThemedImageConverterHelper.ImageCache.TryGetValue(path, out image))
      {
        image = new BitmapImage(new Uri(path, UriKind.Relative));
        ThemedImageConverterHelper.ImageCache.Add(path, image);
      }
      return image;
    }
  }
}

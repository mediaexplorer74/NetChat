// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.ImageSourceExtensions
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


namespace Coding4Fun.Toolkit.Controls.Common
{
  public static class ImageSourceExtensions
  {
    private const string IsoStoreScheme = "isostore:/";
    private const string MsAppXScheme = "ms-appx:///";

    public static ImageSource ToBitmapImage(this ImageSource imageSource)
    {
      if (imageSource == null)
        return (ImageSource) null;
      return !(imageSource is BitmapImage bitmapImage) ? imageSource : (ImageSource) bitmapImage;
    }
  }
}

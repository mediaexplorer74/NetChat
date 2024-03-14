// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.IAppBarButton
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public interface IAppBarButton
  {
    double ButtonWidth { get; set; }

    double ButtonHeight { get; set; }

    Orientation Orientation { get; set; }
  }
}

// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.ApplicationSpace
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Common
{
  public static class ApplicationSpace
  {
    private const int DefaultLogicalppi = 96;
    private const int Percent = 100;

    public static int ScaleFactor()
    {
      return (int) (DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel * 100.0);
    }

    public static Frame RootFrame => Window.Current.Content as Frame;

    public static bool IsDesignMode => DesignMode.DesignModeEnabled;

    public static CoreDispatcher CurrentDispatcher
    {
      get => CoreApplication.MainView.CoreWindow.Dispatcher;
    }
  }
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using weekysoft.store.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.System;


namespace IGM.UI
{
  public partial class Util
  {
    public static async Task LaunchRateAppUri()
    {
      Setting.Current.Rated = await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid="
          + (object) CurrentApp.AppId));
    }

    public static string AppVersion
    {
      get
      {
        PackageVersion version = Package.Current.Id.Version;
        return string.Format("Netchat {0}.{1}.{2}.{3}", (object) version.Major, (object) version.Minor, (object) version.Build, (object) version.Revision);
      }
    }

    internal static void ShowShareUI()
    {
      Util.LogEvent(nameof (ShowShareUI));
      DataTransferManager forCurrentView = DataTransferManager.GetForCurrentView();
      
      forCurrentView.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(DataTransferManager_DataRequested);
      DataTransferManager.ShowShareUI();
    }

    private static void DataTransferManager_DataRequested(
      DataTransferManager sender,
      DataRequestedEventArgs args)
    {
      args.Request.Data.SetWebLink(new Uri("https://www.facebook.com/netchatapp/"));
      args.Request.Data.Properties.Title = "Netchat";
      args.Request.Data.Properties.Description = "Group Chat In 10 Seconds";
      args.Request.Data.SetText("I am using Netchat for offline chatting.");
    }

    public static async void LogEvent([CallerMemberName] string eventName = "")
    {
    }

    public static async void LogEvent(Exception ex)
    {
    }

    public static bool IsFeedBackSupported() => false;

    public static async void LaunchFeedbackHub()
    {
    }
  }
}

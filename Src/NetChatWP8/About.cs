// Decompiled with JetBrains decompiler
// Type: IGM.UI.About
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using weekysoft.store.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace IGM.UI
{
  public sealed class About : UserControl, IComponentConnector
  {
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBlock tbHow;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBlock tbVersion;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private Button feedbackButton;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private Button btnShare;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBlock tbShare;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBlock tbFeedback;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;

    public About()
    {
      this.InitializeComponent();
      this.tbVersion.put_Text(Util.AppVersion);
      this.tbShare.put_Text(ClientData.Current.ChatLabel.ShareLabel);
      this.tbFeedback.put_Text(ClientData.Current.ChatLabel.FeedbackLabel);
      this.tbHow.put_Text(ClientData.Current.ChatLabel.AppInstructoinLabel);
      if (!Util.IsFeedBackSupported())
        return;
      ((UIElement) this.feedbackButton).put_Visibility((Visibility) 0);
    }

    private async void feedbackButton_Click(object sender, RoutedEventArgs e)
    {
      Util.LaunchFeedbackHub();
    }

    private async void btnShare_Click(object sender, RoutedEventArgs e) => Util.ShowShareUI();

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///About.xaml"), (ComponentResourceLocation) 0);
      this.tbHow = (TextBlock) ((FrameworkElement) this).FindName("tbHow");
      this.tbVersion = (TextBlock) ((FrameworkElement) this).FindName("tbVersion");
      this.feedbackButton = (Button) ((FrameworkElement) this).FindName("feedbackButton");
      this.btnShare = (Button) ((FrameworkElement) this).FindName("btnShare");
      this.tbShare = (TextBlock) ((FrameworkElement) this).FindName("tbShare");
      this.tbFeedback = (TextBlock) ((FrameworkElement) this).FindName("tbFeedback");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ButtonBase buttonBase1 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase1.add_Click), new Action<EventRegistrationToken>(buttonBase1.remove_Click), new RoutedEventHandler(this.feedbackButton_Click));
          break;
        case 2:
          ButtonBase buttonBase2 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase2.add_Click), new Action<EventRegistrationToken>(buttonBase2.remove_Click), new RoutedEventHandler(this.btnShare_Click));
          break;
      }
      this._contentLoaded = true;
    }
  }
}

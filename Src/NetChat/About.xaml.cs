using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.CodeDom.Compiler;
using System.Diagnostics;
using weekysoft.store.Storage;
using Windows.UI.Xaml.Markup;

namespace IGM.UI
{
    public sealed partial class About : UserControl
    {
        /*
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
        */

        public About()
        {
            this.InitializeComponent();
            this.tbVersion.put_Text(Util.AppVersion);
            this.tbShare.put_Text(ClientData.Current.ChatLabel.ShareLabel);
            this.tbFeedback.put_Text(ClientData.Current.ChatLabel.FeedbackLabel);
            this.tbHow.put_Text(ClientData.Current.ChatLabel.AppInstructoinLabel);
            if (!Util.IsFeedBackSupported())
                return;
            ((UIElement)this.feedbackButton).put_Visibility((Visibility)0);
        }

        private async void feedbackButton_Click(object sender, RoutedEventArgs e)
        {
            Util.LaunchFeedbackHub();
        }

        private async void btnShare_Click(object sender, RoutedEventArgs e) => Util.ShowShareUI();

        /*
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (this._contentLoaded)
                return;
            this._contentLoaded = true;
            Application.LoadComponent((object)this, new Uri("ms-appx:///About.xaml"), (ComponentResourceLocation)0);
            this.tbHow = (TextBlock)((FrameworkElement)this).FindName("tbHow");
            this.tbVersion = (TextBlock)((FrameworkElement)this).FindName("tbVersion");
            this.feedbackButton = (Button)((FrameworkElement)this).FindName("feedbackButton");
            this.btnShare = (Button)((FrameworkElement)this).FindName("btnShare");
            this.tbShare = (TextBlock)((FrameworkElement)this).FindName("tbShare");
            this.tbFeedback = (TextBlock)((FrameworkElement)this).FindName("tbFeedback");
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        [DebuggerNonUserCode]
        public void Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    ButtonBase buttonBase1 = (ButtonBase)target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase1.add_Click), new Action<EventRegistrationToken>(buttonBase1.remove_Click), new RoutedEventHandler(this.feedbackButton_Click));
                    break;
                case 2:
                    ButtonBase buttonBase2 = (ButtonBase)target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase2.add_Click), new Action<EventRegistrationToken>(buttonBase2.remove_Click), new RoutedEventHandler(this.btnShare_Click));
                    break;
            }
            this._contentLoaded = true;
        }
        */
    }
}


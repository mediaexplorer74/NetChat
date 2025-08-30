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
        

        public About()
        {
            this.InitializeComponent();
            this.tbVersion.Text = Util.AppVersion;

            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                this.tbShare.Text = ClientData.Current.ChatLabel.ShareLabel;
                this.tbFeedback.Text = ClientData.Current.ChatLabel.FeedbackLabel;
                this.tbHow.Text = ClientData.Current.ChatLabel.AppInstructoinLabel;
            }
            else
            {
                this.tbShare.Text = "";
                this.tbFeedback.Text = "";
                this.tbHow.Text = "";
            }

            if (!Util.IsFeedBackSupported())
                return;
            
            this.feedbackButton.Visibility = Visibility.Visible;
        }

        private async void feedbackButton_Click(object sender, RoutedEventArgs e)
        {
            Util.LaunchFeedbackHub();
        }

        private async void btnShare_Click(object sender, RoutedEventArgs e) => Util.ShowShareUI();

    
    }
}
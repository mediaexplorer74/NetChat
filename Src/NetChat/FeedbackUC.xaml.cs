// Decompiled with JetBrains decompiler
// Type: IGM.UI.FeedbackUC
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

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
using weekysoft.store.Enums;
using weekysoft.store.Storage;
using Windows.System;
using Windows.UI.Xaml.Markup;

namespace IGM.UI
{
    public sealed partial class FeedbackUC : UserControl
    {
       
        private string _SendToName { get; set; }

        private string _SendToAddress { get; set; }

        public FeedbackUC()
        {
            this.InitializeComponent();

            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                this.cbCommentType.ItemsSource = (object)ClientData.Current.CommentTypes;
            }
            else
            {
                this.cbCommentType.ItemsSource = default;
            }
            this._SendToName = "ME";
            this._SendToAddress = "ME@me_mail.commmm";
        }

        private async void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            int num = await Launcher.LaunchUriAsync(
                new Uri(string.Format("mailto:{0}?subject=Netchat-{1}&body={2}", (object)this._SendToAddress,
                ((Selector)this.cbCommentType).SelectedValue, (object)this.tbComment.Text))) ? 1 : 0;
        }

        private async void btnReview_Click(object sender, RoutedEventArgs e)
        {
            await Util.LaunchRateAppUri();
        }

        private void cbCommentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Selector)this.cbCommentType).SelectedValue.ToString()
                == CommentType.LoveIt.GetDisplayName() && !Setting.Current.Rated)
            {
                ((UIElement)this.btnReview).Visibility = (Visibility)0;
                ((UIElement)this.btnEmail).Visibility = (Visibility)1;
                ((Control)this.tbComment).IsEnabled = false;
            }
            else
            {
                ((UIElement)this.btnReview).Visibility = (Visibility)1;
                ((UIElement)this.btnEmail).Visibility = (Visibility)0;
                ((Control)this.tbComment).IsEnabled = true;
            }
        }

       
    }
}

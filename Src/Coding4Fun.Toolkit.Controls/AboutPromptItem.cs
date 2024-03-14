// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.AboutPromptItem
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace Coding4Fun.Toolkit.Controls
{
  public class AboutPromptItem : Control
  {
    private TextBlock _emailAddress;
    private TextBlock _website;
    private TextBlock _author;
    private const string EmailAddressName = "emailAddress";
    private const string WebsiteName = "website";
    private const string AuthorTxtBlockName = "author";
    private const string Http = "http://";
    private const string Https = "https://";
    private const string Twitter = "www.twitter.com";
    private string _webSiteUrl;
    public static readonly DependencyProperty WebSiteDisplayProperty = DependencyProperty.Register(nameof (WebSiteDisplay), typeof (string), typeof (AboutPromptItem), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty RoleProperty = DependencyProperty.Register(nameof (Role), typeof (string), typeof (AboutPromptItem), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty EmailAddressProperty = DependencyProperty.Register(nameof (EmailAddress), typeof (string), typeof (AboutPromptItem), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty AuthorNameProperty = DependencyProperty.Register(nameof (AuthorName), typeof (string), typeof (AboutPromptItem), new PropertyMetadata((object) ""));

    public AboutPromptItem() => this.put_DefaultStyleKey((object) typeof (AboutPromptItem));

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      if (this._website != null)
        WindowsRuntimeMarshal.RemoveEventHandler<ManipulationCompletedEventHandler>(new Action<EventRegistrationToken>(((UIElement) this._website).remove_ManipulationCompleted), new ManipulationCompletedEventHandler(this.websiteClick_ManipulationCompleted));
      if (this._emailAddress != null)
        WindowsRuntimeMarshal.RemoveEventHandler<ManipulationCompletedEventHandler>(new Action<EventRegistrationToken>(((UIElement) this._emailAddress).remove_ManipulationCompleted), new ManipulationCompletedEventHandler(this.email_ManipulationCompleted));
      this._emailAddress = this.GetTemplateChild("emailAddress") as TextBlock;
      this._website = this.GetTemplateChild("website") as TextBlock;
      this._author = this.GetTemplateChild("author") as TextBlock;
      AboutPromptItem.SetVisibility(this._emailAddress);
      AboutPromptItem.SetVisibility(this._website);
      AboutPromptItem.SetVisibility(this._author);
      if (this._emailAddress != null)
      {
        TextBlock emailAddress = this._emailAddress;
        WindowsRuntimeMarshal.AddEventHandler<ManipulationCompletedEventHandler>(new Func<ManipulationCompletedEventHandler, EventRegistrationToken>(((UIElement) emailAddress).add_ManipulationCompleted), new Action<EventRegistrationToken>(((UIElement) emailAddress).remove_ManipulationCompleted), new ManipulationCompletedEventHandler(this.email_ManipulationCompleted));
      }
      if (this._website == null)
        return;
      TextBlock website = this._website;
      WindowsRuntimeMarshal.AddEventHandler<ManipulationCompletedEventHandler>(new Func<ManipulationCompletedEventHandler, EventRegistrationToken>(((UIElement) website).add_ManipulationCompleted), new Action<EventRegistrationToken>(((UIElement) website).remove_ManipulationCompleted), new ManipulationCompletedEventHandler(this.websiteClick_ManipulationCompleted));
    }

    private async void email_ManipulationCompleted(
      object sender,
      ManipulationCompletedRoutedEventArgs e)
    {
      int num = await Launcher.LaunchUriAsync(new Uri(string.Format("mailto:?to={0}&subject={1} Feedback", (object) this.EmailAddress, (object) ManifestHelper.GetDisplayName()))) ? 1 : 0;
    }

    private async void websiteClick_ManipulationCompleted(
      object sender,
      ManipulationCompletedRoutedEventArgs e)
    {
      int num = await Launcher.LaunchUriAsync(new Uri(this.WebSiteUrl)) ? 1 : 0;
    }

    private static void SetVisibility(TextBlock control)
    {
      ((UIElement) control)?.put_Visibility(string.IsNullOrEmpty(control.Text) ? (Visibility) 1 : (Visibility) 0);
    }

    public string WebSiteUrl
    {
      get => this._webSiteUrl;
      set
      {
        this._webSiteUrl = value;
        this.WebSiteDisplay = value;
        AboutPromptItem.SetVisibility(this._website);
      }
    }

    protected internal string WebSiteDisplay
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPromptItem.WebSiteDisplayProperty);
      set
      {
        if (value != null)
        {
          value = value.ToLowerInvariant().TrimEnd('/');
          if (value.StartsWith("https://"))
            value = value.Remove(0, "https://".Length);
          if (value.StartsWith("http://"))
            value = value.Remove(0, "http://".Length);
          if (!string.IsNullOrEmpty(value) && value.StartsWith("www.twitter.com"))
            value = "@" + value.Remove(0, "www.twitter.com".Length).TrimStart('/');
        }
        ((DependencyObject) this).SetValue(AboutPromptItem.WebSiteDisplayProperty, (object) value);
      }
    }

    public string Role
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPromptItem.RoleProperty);
      set
      {
        if (value != null)
          value = value.ToLowerInvariant();
        ((DependencyObject) this).SetValue(AboutPromptItem.RoleProperty, (object) value);
      }
    }

    public string EmailAddress
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPromptItem.EmailAddressProperty);
      set
      {
        if (value != null)
          value = value.ToLowerInvariant();
        ((DependencyObject) this).SetValue(AboutPromptItem.EmailAddressProperty, (object) value);
        AboutPromptItem.SetVisibility(this._emailAddress);
      }
    }

    public string AuthorName
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPromptItem.AuthorNameProperty);
      set
      {
        if (value != null)
          value = value.ToLowerInvariant();
        ((DependencyObject) this).SetValue(AboutPromptItem.AuthorNameProperty, (object) value);
        AboutPromptItem.SetVisibility(this._author);
      }
    }
  }
}

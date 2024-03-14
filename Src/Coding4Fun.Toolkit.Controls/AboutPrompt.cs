// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.AboutPrompt
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;


namespace Coding4Fun.Toolkit.Controls
{
  public class AboutPrompt : ActionPopUp<object, PopUpResult>
  {
    public static readonly DependencyProperty IsPromptModeProperty = DependencyProperty.Register(nameof (IsPromptMode), typeof (bool), typeof (AboutPrompt), new PropertyMetadata((object) true, new PropertyChangedCallback(AboutPrompt.OnIsPromptModeChanged)));
    public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.Register(nameof (WaterMark), typeof (object), typeof (AboutPrompt), new PropertyMetadata((object) null));
    public static readonly DependencyProperty VersionNumberProperty = DependencyProperty.Register(nameof (VersionNumber), typeof (object), typeof (AboutPrompt), new PropertyMetadata((object) ("v" + ManifestHelper.GetVersion())));
    public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(nameof (Body), typeof (object), typeof (AboutPrompt), new PropertyMetadata((object) null));
    public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(nameof (Footer), typeof (object), typeof (AboutPrompt), new PropertyMetadata((object) null));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (AboutPrompt), new PropertyMetadata((object) ManifestHelper.GetDisplayName()));

    public AboutPrompt()
    {
      this.put_DefaultStyleKey((object) typeof (AboutPrompt));
      RoundButton roundButton1 = new RoundButton();
      RoundButton roundButton2 = roundButton1;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) roundButton2).add_Click), new Action<EventRegistrationToken>(((ButtonBase) roundButton2).remove_Click), new RoutedEventHandler(this.ok_Click));
      this.ActionPopUpButtons.Add((Button) roundButton1);
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.SetIsPromptMode(this.IsPromptMode);
    }

    public void Show(
      string authorName,
      string twitterName = null,
      string emailAddress = null,
      string websiteUrl = null)
    {
      List<AboutPromptItem> aboutPromptItemList = new List<AboutPromptItem>()
      {
        new AboutPromptItem()
        {
          Role = "me",
          AuthorName = authorName
        }
      };
      if (!string.IsNullOrEmpty(twitterName))
        aboutPromptItemList.Add(new AboutPromptItem()
        {
          Role = "twitter",
          WebSiteUrl = "http://www.twitter.com/" + twitterName.TrimStart('@')
        });
      if (!string.IsNullOrEmpty(websiteUrl))
        aboutPromptItemList.Add(new AboutPromptItem()
        {
          Role = "web",
          WebSiteUrl = websiteUrl
        });
      if (!string.IsNullOrEmpty(emailAddress))
        aboutPromptItemList.Add(new AboutPromptItem()
        {
          Role = "email",
          EmailAddress = emailAddress
        });
      this.Show(aboutPromptItemList.ToArray());
    }

    public void Show(params AboutPromptItem[] people)
    {
      if (people != null && people.Length != 0)
      {
        StackPanel stackPanel1 = new StackPanel();
        ((FrameworkElement) stackPanel1).put_HorizontalAlignment((HorizontalAlignment) 3);
        ((FrameworkElement) stackPanel1).put_VerticalAlignment((VerticalAlignment) 3);
        StackPanel stackPanel2 = stackPanel1;
        for (int index = people.Length - 1; index >= 0; --index)
          ((IList<UIElement>) ((Panel) stackPanel2).Children).Insert(0, (UIElement) people[index]);
        this.Body = (object) stackPanel2;
      }
      this.Show();
    }

    private void ok_Click(object sender, RoutedEventArgs e)
    {
      this.OnCompleted(new PopUpEventArgs<object, PopUpResult>()
      {
        PopUpResult = PopUpResult.Ok
      });
    }

    private void SetIsPromptMode(bool value)
    {
      if (this.ActionButtonArea == null)
        return;
      ((UIElement) this.ActionButtonArea).put_Visibility(value ? (Visibility) 0 : (Visibility) 1);
    }

    private static void OnIsPromptModeChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      AboutPrompt aboutPrompt = (AboutPrompt) o;
      if (aboutPrompt == null || aboutPrompt.ActionButtonArea == null || e.NewValue == e.OldValue)
        return;
      aboutPrompt.SetIsPromptMode((bool) e.NewValue);
    }

    public bool IsPromptMode
    {
      get => (bool) ((DependencyObject) this).GetValue(AboutPrompt.IsPromptModeProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.IsPromptModeProperty, (object) value);
    }

    public object WaterMark
    {
      get => ((DependencyObject) this).GetValue(AboutPrompt.WaterMarkProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.WaterMarkProperty, value);
    }

    public string VersionNumber
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPrompt.VersionNumberProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.VersionNumberProperty, (object) value);
    }

    public object Body
    {
      get => ((DependencyObject) this).GetValue(AboutPrompt.BodyProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.BodyProperty, value);
    }

    public object Footer
    {
      get => ((DependencyObject) this).GetValue(AboutPrompt.FooterProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.FooterProperty, value);
    }

    public string Title
    {
      get => (string) ((DependencyObject) this).GetValue(AboutPrompt.TitleProperty);
      set => ((DependencyObject) this).SetValue(AboutPrompt.TitleProperty, (object) value);
    }
  }
}

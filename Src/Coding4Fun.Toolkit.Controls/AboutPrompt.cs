using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Coding4Fun.Toolkit.Controls
{
  public class AboutPrompt : ActionPopUp<object, PopUpResult>
  {
    public static readonly DependencyProperty IsPromptModeProperty = DependencyProperty.Register(nameof(IsPromptMode), typeof(bool), typeof(AboutPrompt), new PropertyMetadata(true, OnIsPromptModeChanged));
    public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.Register(nameof(WaterMark), typeof(object), typeof(AboutPrompt), new PropertyMetadata(null));
    public static readonly DependencyProperty VersionNumberProperty = DependencyProperty.Register(nameof(VersionNumber), typeof(object), typeof(AboutPrompt), new PropertyMetadata("v" + ManifestHelper.GetVersion()));
    public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(nameof(Body), typeof(object), typeof(AboutPrompt), new PropertyMetadata(null));
    public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(nameof(Footer), typeof(object), typeof(AboutPrompt), new PropertyMetadata(null));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(AboutPrompt), new PropertyMetadata(ManifestHelper.GetDisplayName()));

    public AboutPrompt()
    {
      DefaultStyleKey = typeof(AboutPrompt);
      var roundButton = new RoundButton();
      roundButton.Click += ok_Click;
      ActionPopUpButtons.Add(roundButton);
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      SetIsPromptMode(IsPromptMode);
    }

    public void Show(
      string authorName,
      string twitterName = null,
      string emailAddress = null,
      string websiteUrl = null)
    {
      var aboutPromptItemList = new List<AboutPromptItem>()
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
        
      Show(aboutPromptItemList.ToArray());
    }

    public void Show(params AboutPromptItem[] people)
    {
      if (people != null && people.Length != 0)
      {
        var stackPanel = new StackPanel()
        {
          HorizontalAlignment = HorizontalAlignment.Stretch,
          VerticalAlignment = VerticalAlignment.Stretch
        };
        
        for (int index = people.Length - 1; index >= 0; --index)
          stackPanel.Children.Insert(0, people[index]);
          
        Body = stackPanel;
      }
      Show();
    }

    private void ok_Click(object sender, RoutedEventArgs e)
    {
      OnCompleted(new PopUpEventArgs<object, PopUpResult>()
      {
        PopUpResult = PopUpResult.Ok
      });
    }

    private void SetIsPromptMode(bool value)
    {
      if (ActionButtonArea != null)
        ActionButtonArea.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
    }

    private static void OnIsPromptModeChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      if (o is AboutPrompt aboutPrompt && aboutPrompt.ActionButtonArea != null && e.NewValue != e.OldValue)
        aboutPrompt.SetIsPromptMode((bool)e.NewValue);
    }

    public bool IsPromptMode
    {
      get => (bool)GetValue(IsPromptModeProperty);
      set => SetValue(IsPromptModeProperty, value);
    }

    public object WaterMark
    {
      get => GetValue(WaterMarkProperty);
      set => SetValue(WaterMarkProperty, value);
    }

    public string VersionNumber
    {
      get => (string)GetValue(VersionNumberProperty);
      set => SetValue(VersionNumberProperty, value);
    }

    public object Body
    {
      get => GetValue(BodyProperty);
      set => SetValue(BodyProperty, value);
    }

    public object Footer
    {
      get => GetValue(FooterProperty);
      set => SetValue(FooterProperty, value);
    }

    public string Title
    {
      get => (string)GetValue(TitleProperty);
      set => SetValue(TitleProperty, value);
    }
  }
}

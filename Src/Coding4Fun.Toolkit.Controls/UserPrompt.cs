// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.UserPrompt
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public abstract class UserPrompt : ActionPopUp<string, PopUpResult>
  {
    private readonly RoundButton _cancelButton;
    protected internal Action MessageChanged;
    public readonly DependencyProperty IsCancelVisibileProperty = DependencyProperty.Register(nameof (IsCancelVisible), typeof (bool), typeof (UserPrompt), new PropertyMetadata((object) false, new PropertyChangedCallback(UserPrompt.OnCancelButtonVisibilityChanged)));
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof (Value), typeof (string), typeof (UserPrompt), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (UserPrompt), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof (Message), typeof (string), typeof (UserPrompt), new PropertyMetadata((object) "", new PropertyChangedCallback(UserPrompt.OnMesageContentChanged)));

    protected UserPrompt()
    {
      RoundButton roundButton1 = new RoundButton();
      this._cancelButton = new RoundButton();
      RoundButton roundButton2 = roundButton1;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) roundButton2).add_Click), new Action<EventRegistrationToken>(((ButtonBase) roundButton2).remove_Click), new RoutedEventHandler(this.OkClick));
      RoundButton cancelButton = this._cancelButton;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) cancelButton).add_Click), new Action<EventRegistrationToken>(((ButtonBase) cancelButton).remove_Click), new RoutedEventHandler(this.CancelledClick));
      this.ActionPopUpButtons.Add((Button) roundButton1);
      this.ActionPopUpButtons.Add((Button) this._cancelButton);
      this.SetCancelButtonVisibility(this.IsCancelVisible);
    }

    protected override void OnApplyTemplate()
    {
      ((ContentControl) this._cancelButton).put_Content((object) ButtonBaseHelper.CreateXamlCancel((FrameworkElement) this._cancelButton));
      base.OnApplyTemplate();
    }

    private void OkClick(object sender, RoutedEventArgs e)
    {
      this.OnCompleted(new PopUpEventArgs<string, PopUpResult>()
      {
        Result = this.Value,
        PopUpResult = PopUpResult.Ok
      });
    }

    private void CancelledClick(object sender, RoutedEventArgs e)
    {
      this.OnCompleted(new PopUpEventArgs<string, PopUpResult>()
      {
        PopUpResult = PopUpResult.Cancelled
      });
    }

    private void SetCancelButtonVisibility(bool value)
    {
      ((UIElement) this._cancelButton).put_Visibility(value ? (Visibility) 0 : (Visibility) 1);
    }

    private static void OnMesageContentChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      UserPrompt userPrompt = (UserPrompt) o;
      if (userPrompt == null || e.NewValue == e.OldValue || userPrompt.MessageChanged == null)
        return;
      userPrompt.MessageChanged();
    }

    private static void OnCancelButtonVisibilityChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      UserPrompt userPrompt = (UserPrompt) o;
      if (userPrompt == null || e.NewValue == e.OldValue)
        return;
      userPrompt.SetCancelButtonVisibility((bool) e.NewValue);
    }

    public bool IsCancelVisible
    {
      get => (bool) ((DependencyObject) this).GetValue(this.IsCancelVisibileProperty);
      set => ((DependencyObject) this).SetValue(this.IsCancelVisibileProperty, (object) value);
    }

    public string Value
    {
      get => (string) ((DependencyObject) this).GetValue(UserPrompt.ValueProperty);
      set => ((DependencyObject) this).SetValue(UserPrompt.ValueProperty, (object) value);
    }

    public string Title
    {
      get => (string) ((DependencyObject) this).GetValue(UserPrompt.TitleProperty);
      set => ((DependencyObject) this).SetValue(UserPrompt.TitleProperty, (object) value);
    }

    public string Message
    {
      get => (string) ((DependencyObject) this).GetValue(UserPrompt.MessageProperty);
      set => ((DependencyObject) this).SetValue(UserPrompt.MessageProperty, (object) value);
    }
  }
}

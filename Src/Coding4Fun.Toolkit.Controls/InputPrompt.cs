// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.InputPrompt
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Binding;
using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class InputPrompt : UserPrompt
  {
    protected TextBox InputBox;
    private const string InputBoxName = "inputBox";
    public static readonly DependencyProperty IsSubmitOnEnterKeyProperty = DependencyProperty.Register(nameof (IsSubmitOnEnterKey), typeof (bool), typeof (InputPrompt), new PropertyMetadata((object) true, new PropertyChangedCallback(InputPrompt.OnIsSubmitOnEnterKeyPropertyChanged)));
    public static readonly DependencyProperty MessageTextWrappingProperty = DependencyProperty.Register(nameof (MessageTextWrapping), typeof (TextWrapping), typeof (InputPrompt), new PropertyMetadata((object) (TextWrapping) 1));
    public static readonly DependencyProperty InputScopeProperty = DependencyProperty.Register(nameof (InputScope), typeof (InputScope), typeof (InputPrompt), (PropertyMetadata) null);

    public InputPrompt() => this.put_DefaultStyleKey((object) typeof (InputPrompt));

    protected override async void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.InputBox = this.GetTemplateChild("inputBox") as TextBox;
      if (this.InputBox == null)
        return;
      Windows.UI.Xaml.Data.Binding binding = new Windows.UI.Xaml.Data.Binding();
      binding.put_Source((object) this.InputBox);
      binding.put_Path(new PropertyPath("Text"));
      ((FrameworkElement) this).SetBinding(UserPrompt.ValueProperty, (BindingBase) binding);
      TextBinding.SetUpdateSourceOnChange((DependencyObject) this.InputBox, true);
      this.HookUpEventForIsSubmitOnEnterKey();
      if (ApplicationSpace.IsDesignMode)
        return;
      await this.DelayInputSelect();
    }

    private async Task DelayInputSelect()
    {
      await Task.Delay(250);
      // ISSUE: method pointer
      await ApplicationSpace.CurrentDispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) this, __methodptr(\u003CDelayInputSelect\u003Eb__4_0)));
    }

    private void HookUpEventForIsSubmitOnEnterKey()
    {
      this.InputBox = this.GetTemplateChild("inputBox") as TextBox;
      if (this.InputBox == null)
        return;
      WindowsRuntimeMarshal.RemoveEventHandler<KeyEventHandler>(new Action<EventRegistrationToken>(((UIElement) this.InputBox).remove_KeyDown), new KeyEventHandler(this.InputBoxKeyDown));
      if (!this.IsSubmitOnEnterKey)
        return;
      TextBox inputBox = this.InputBox;
      WindowsRuntimeMarshal.AddEventHandler<KeyEventHandler>(new Func<KeyEventHandler, EventRegistrationToken>(((UIElement) inputBox).add_KeyDown), new Action<EventRegistrationToken>(((UIElement) inputBox).remove_KeyDown), new KeyEventHandler(this.InputBoxKeyDown));
    }

    private void InputBoxKeyDown(object sender, KeyRoutedEventArgs e)
    {
      if (e.Key != 13)
        return;
      this.OnCompleted(new PopUpEventArgs<string, PopUpResult>()
      {
        Result = this.Value,
        PopUpResult = PopUpResult.Ok
      });
    }

    private static void OnIsSubmitOnEnterKeyPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is InputPrompt inputPrompt))
        return;
      inputPrompt.HookUpEventForIsSubmitOnEnterKey();
    }

    public bool IsSubmitOnEnterKey
    {
      get => (bool) ((DependencyObject) this).GetValue(InputPrompt.IsSubmitOnEnterKeyProperty);
      set
      {
        ((DependencyObject) this).SetValue(InputPrompt.IsSubmitOnEnterKeyProperty, (object) value);
      }
    }

    public TextWrapping MessageTextWrapping
    {
      get
      {
        return (TextWrapping) ((DependencyObject) this).GetValue(InputPrompt.MessageTextWrappingProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(InputPrompt.MessageTextWrappingProperty, (object) value);
      }
    }

    public InputScope InputScope
    {
      get => (InputScope) ((DependencyObject) this).GetValue(InputPrompt.InputScopeProperty);
      set => ((DependencyObject) this).SetValue(InputPrompt.InputScopeProperty, (object) value);
    }
  }
}

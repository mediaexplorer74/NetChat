// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.PasswordInputPrompt
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Binding;
using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;


namespace Coding4Fun.Toolkit.Controls
{
  public class PasswordInputPrompt : InputPrompt
  {
    private readonly StringBuilder _inputText = new StringBuilder();
    private DateTime _lastUpdated = DateTime.Now;
    public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register(nameof (PasswordChar), typeof (char), typeof (PasswordInputPrompt), new PropertyMetadata((object) '●'));

    public PasswordInputPrompt() => this.put_DefaultStyleKey((object) typeof (PasswordInputPrompt));

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      if (this.InputBox == null)
        return;
      Windows.UI.Xaml.Data.Binding binding = new Windows.UI.Xaml.Data.Binding();
      binding.put_Source((object) this.InputBox);
      binding.put_Path(new PropertyPath("Text"));
      ((FrameworkElement) this).SetBinding(UserPrompt.ValueProperty, (BindingBase) binding);
      TextBinding.SetUpdateSourceOnChange((DependencyObject) this.InputBox, true);
      WindowsRuntimeMarshal.RemoveEventHandler<TextChangedEventHandler>(new Action<EventRegistrationToken>(this.InputBox.remove_TextChanged), new TextChangedEventHandler(this.InputBoxTextChanged));
      WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(this.InputBox.remove_SelectionChanged), new RoutedEventHandler(this.InputBoxSelectionChanged));
      TextBox inputBox1 = this.InputBox;
      WindowsRuntimeMarshal.AddEventHandler<TextChangedEventHandler>(new Func<TextChangedEventHandler, EventRegistrationToken>(inputBox1.add_TextChanged), new Action<EventRegistrationToken>(inputBox1.remove_TextChanged), new TextChangedEventHandler(this.InputBoxTextChanged));
      TextBox inputBox2 = this.InputBox;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(inputBox2.add_SelectionChanged), new Action<EventRegistrationToken>(inputBox2.remove_SelectionChanged), new RoutedEventHandler(this.InputBoxSelectionChanged));
    }

    private void InputBoxSelectionChanged(object sender, RoutedEventArgs e)
    {
      if (this.InputBox.SelectionLength <= 0)
        return;
      this.InputBox.put_SelectionLength(0);
    }

    private async void InputBoxTextChanged(object sender, TextChangedEventArgs e)
    {
      int length1 = this.InputBox.Text.Length - this._inputText.Length;
      if (length1 < 0)
      {
        int length2 = length1 * -1;
        int startIndex = this.InputBox.SelectionStart + 1 - length2;
        if (startIndex < 0)
          startIndex = 0;
        this._inputText.Remove(startIndex, length2);
        this.Value = this._inputText.ToString();
      }
      else
      {
        if (length1 <= 0)
          return;
        int selectionStart = this.InputBox.SelectionStart;
        int num = selectionStart - length1;
        string str = this.InputBox.Text.Substring(num, length1);
        this._inputText.Insert(num, str);
        this.Value = this._inputText.ToString();
        if (length1 > 1)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Insert(0, this.PasswordChar.ToString(), this.InputBox.Text.Length);
          this.InputBox.put_Text(stringBuilder.ToString());
        }
        else
        {
          if (this.InputBox.Text.Length >= 2)
          {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Insert(0, this.PasswordChar.ToString(), this.InputBox.Text.Length - length1);
            stringBuilder.Insert(num, str);
            this.InputBox.put_Text(stringBuilder.ToString());
          }
          await this.ExecuteDelayedOverwrite();
          this._lastUpdated = DateTime.Now;
        }
        this.InputBox.put_SelectionStart(selectionStart);
      }
    }

    private async Task ExecuteDelayedOverwrite()
    {
      await Task.Run((Func<Task>) (async () =>
      {
        await Task.Delay(TimeSpan.FromMilliseconds(500.0));
        if (DateTime.Now - this._lastUpdated < TimeSpan.FromMilliseconds(500.0))
          return;
        // ISSUE: method pointer
        await ApplicationSpace.CurrentDispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) this, __methodptr(\u003CExecuteDelayedOverwrite\u003Eb__6_1)));
      }));
    }

    public char PasswordChar
    {
      get => (char) ((DependencyObject) this).GetValue(PasswordInputPrompt.PasswordCharProperty);
      set
      {
        ((DependencyObject) this).SetValue(PasswordInputPrompt.PasswordCharProperty, (object) value);
      }
    }
  }
}

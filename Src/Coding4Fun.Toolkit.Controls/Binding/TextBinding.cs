// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Binding.TextBinding
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Binding
{
  public class TextBinding
  {
    public static readonly DependencyProperty UpdateSourceOnChangeProperty = DependencyProperty.RegisterAttached("UpdateSourceOnChange", typeof (bool), typeof (TextBinding), new PropertyMetadata((object) false, new PropertyChangedCallback(TextBinding.OnUpdateSourceOnChangePropertyChanged)));

    public static bool GetUpdateSourceOnChange(DependencyObject obj)
    {
      return (bool) obj.GetValue(TextBinding.UpdateSourceOnChangeProperty);
    }

    public static void SetUpdateSourceOnChange(DependencyObject obj, bool value)
    {
      obj.SetValue(TextBinding.UpdateSourceOnChangeProperty, (object) value);
    }

    private static void OnUpdateSourceOnChangePropertyChanged(
      DependencyObject obj,
      DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == e.OldValue)
        return;
      TextBinding.HandleUpdateSourceOnChangeEventAppend((object) obj, (bool) e.NewValue);
    }

    private static void HandleUpdateSourceOnChangeEventAppend(object sender, bool value)
    {
      switch (sender)
      {
        case TextBox _:
          TextBinding.HandleUpdateSourceOnChangeEventAppendTextBox(sender, value);
          break;
        case PasswordBox _:
          TextBinding.HandleUpdateSourceOnChangeEventAppendPassword(sender, value);
          break;
      }
    }

    private static void HandleUpdateSourceOnChangeEventAppendTextBox(object sender, bool value)
    {
      if (!(sender is TextBox textBox1))
        return;
      if (value)
      {
        TextBox textBox2 = textBox1;
        WindowsRuntimeMarshal.AddEventHandler<TextChangedEventHandler>(new Func<TextChangedEventHandler, EventRegistrationToken>(textBox2.add_TextChanged), new Action<EventRegistrationToken>(textBox2.remove_TextChanged), new TextChangedEventHandler(TextBinding.UpdateSourceOnChangePropertyChanged));
      }
      else
        WindowsRuntimeMarshal.RemoveEventHandler<TextChangedEventHandler>(new Action<EventRegistrationToken>(textBox1.remove_TextChanged), new TextChangedEventHandler(TextBinding.UpdateSourceOnChangePropertyChanged));
    }

    private static void HandleUpdateSourceOnChangeEventAppendPassword(object sender, bool value)
    {
      if (!(sender is PasswordBox passwordBox1))
        return;
      if (value)
      {
        PasswordBox passwordBox2 = passwordBox1;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(passwordBox2.add_PasswordChanged), new Action<EventRegistrationToken>(passwordBox2.remove_PasswordChanged), new RoutedEventHandler(TextBinding.UpdateSourceOnChangePropertyChanged));
      }
      else
        WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(passwordBox1.remove_PasswordChanged), new RoutedEventHandler(TextBinding.UpdateSourceOnChangePropertyChanged));
    }

    private static void UpdateSourceOnChangePropertyChanged(object sender, RoutedEventArgs e)
    {
      DependencyProperty dependancyPropertyForText = TextBinding.GetDependancyPropertyForText(sender);
      if (dependancyPropertyForText == null)
        return;
      ((FrameworkElement) sender).GetBindingExpression(dependancyPropertyForText)?.UpdateSource();
    }

    private static DependencyProperty GetDependancyPropertyForText(object sender)
    {
      DependencyProperty dependancyPropertyForText = (DependencyProperty) null;
      switch (sender)
      {
        case TextBox _:
          dependancyPropertyForText = TextBox.TextProperty;
          break;
        case PasswordBox _:
          dependancyPropertyForText = PasswordBox.PasswordProperty;
          break;
      }
      return dependancyPropertyForText;
    }
  }
}

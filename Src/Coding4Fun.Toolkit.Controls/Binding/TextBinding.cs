using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Coding4Fun.Toolkit.Controls.Binding
{
  public class TextBinding
  {
    public static readonly DependencyProperty UpdateSourceOnChangeProperty = DependencyProperty.RegisterAttached("UpdateSourceOnChange", typeof(bool), typeof(TextBinding), new PropertyMetadata(false, OnUpdateSourceOnChangePropertyChanged));

    public static bool GetUpdateSourceOnChange(DependencyObject obj)
    {
      return (bool)obj.GetValue(UpdateSourceOnChangeProperty);
    }

    public static void SetUpdateSourceOnChange(DependencyObject obj, bool value)
    {
      obj.SetValue(UpdateSourceOnChangeProperty, value);
    }

    private static void OnUpdateSourceOnChangePropertyChanged(
      DependencyObject obj,
      DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == e.OldValue)
        return;
      HandleUpdateSourceOnChangeEventAppend(obj, (bool)e.NewValue);
    }

    private static void HandleUpdateSourceOnChangeEventAppend(object sender, bool value)
    {
      if (sender is TextBox)
      {
        HandleUpdateSourceOnChangeEventAppendTextBox(sender, value);
      }
      else if (sender is PasswordBox)
      {
        HandleUpdateSourceOnChangeEventAppendPassword(sender, value);
      }
    }

    private static void HandleUpdateSourceOnChangeEventAppendTextBox(object sender, bool value)
    {
      if (!(sender is TextBox textBox))
        return;
        
      if (value)
      {
        textBox.TextChanged += UpdateSourceOnChangePropertyChanged;
      }
      else
      {
        textBox.TextChanged -= UpdateSourceOnChangePropertyChanged;
      }
    }

    private static void HandleUpdateSourceOnChangeEventAppendPassword(object sender, bool value)
    {
      if (!(sender is PasswordBox passwordBox))
        return;
        
      if (value)
      {
        passwordBox.PasswordChanged += UpdateSourceOnChangePropertyChanged;
      }
      else
      {
        passwordBox.PasswordChanged -= UpdateSourceOnChangePropertyChanged;
      }
    }

    private static void UpdateSourceOnChangePropertyChanged(object sender, RoutedEventArgs e)
    {
      DependencyProperty dependencyPropertyForText = GetDependencyPropertyForText(sender);
      if (dependencyPropertyForText == null)
        return;
        
      if (sender is FrameworkElement frameworkElement)
        frameworkElement.GetBindingExpression(dependencyPropertyForText)?.UpdateSource();
    }

    private static DependencyProperty GetDependencyPropertyForText(object sender)
    {
      if (sender is TextBox)
        return TextBox.TextProperty;
      else if (sender is PasswordBox)
        return PasswordBox.PasswordProperty;
      else
        return null;
    }
  }
}
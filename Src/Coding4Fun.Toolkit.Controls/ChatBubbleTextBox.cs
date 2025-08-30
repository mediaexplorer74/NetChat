using Coding4Fun.Toolkit.Controls.Common;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Coding4Fun.Toolkit.Controls
{
  public class ChatBubbleTextBox : TextBox
  {
    protected ContentControl HintContentElement;
    private const string HintContentElementName = "HintContentElement";
    private bool _hasFocus;
    public static readonly DependencyProperty ChatBubbleDirectionProperty = DependencyProperty.Register(nameof(ChatBubbleDirection), typeof(ChatBubbleDirection), typeof(ChatBubbleTextBox), new PropertyMetadata(ChatBubbleDirection.UpperRight, OnChatBubbleDirectionChanged));
    public static readonly DependencyProperty HintProperty = DependencyProperty.Register(nameof(Hint), typeof(string), typeof(ChatBubbleTextBox), new PropertyMetadata(""));
    public static readonly DependencyProperty HintStyleProperty = DependencyProperty.Register(nameof(HintStyle), typeof(Style), typeof(ChatBubbleTextBox), new PropertyMetadata(null));
    public static readonly DependencyProperty IsEquallySpacedProperty = DependencyProperty.Register(nameof(IsEquallySpaced), typeof(bool), typeof(ChatBubbleTextBox), new PropertyMetadata(true, OnIsEquallySpacedChanged));
    private static bool _triggered = false;

    public ChatBubbleTextBox()
    {
      DefaultStyleKey = typeof(ChatBubbleTextBox);
      TextChanged += ChatBubbleTextBoxTextChanged;
    }

    public ChatBubbleDirection ChatBubbleDirection
    {
      get => (ChatBubbleDirection)GetValue(ChatBubbleDirectionProperty);
      set => SetValue(ChatBubbleDirectionProperty, value);
    }

    public string Hint
    {
      get => (string)GetValue(HintProperty);
      set => SetValue(HintProperty, value);
    }

    public Style HintStyle
    {
      get => (Style)GetValue(HintStyleProperty);
      set => SetValue(HintStyleProperty, value);
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      HintContentElement = GetTemplateChild(HintContentElementName) as ContentControl;
      UpdateHintVisibility();
      UpdateChatBubbleDirection();
      UpdateIsEquallySpaced();
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
      _hasFocus = true;
      SetHintVisibility(Visibility.Collapsed);
      base.OnGotFocus(e);
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
      _hasFocus = false;
      UpdateHintVisibility();
      base.OnLostFocus(e);
    }

    private void UpdateHintVisibility()
    {
      if (_hasFocus)
        return;
      SetHintVisibility(string.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Collapsed);
    }

    private void SetHintVisibility(Visibility value)
    {
      if (HintContentElement != null)
        HintContentElement.Visibility = value;
    }

    private static void OnChatBubbleDirectionChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (d is ChatBubbleTextBox chatBubbleTextBox)
        chatBubbleTextBox.UpdateChatBubbleDirection();
    }

    private void UpdateChatBubbleDirection()
    {
      VisualStateManager.GoToState(this, ChatBubbleDirection.ToString(), true);
    }

    private void ChatBubbleTextBoxTextChanged(object sender, TextChangedEventArgs e)
    {
      UpdateHintVisibility();
    }

    public bool IsEquallySpaced
    {
      get => (bool)GetValue(IsEquallySpacedProperty);
      set => SetValue(IsEquallySpacedProperty, value);
    }

    private static void OnIsEquallySpacedChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (d is ChatBubbleTextBox chatBubbleTextBox)
      {
        _triggered = true;
        chatBubbleTextBox.UpdateIsEquallySpaced();
      }
    }

    private void UpdateIsEquallySpaced()
    {
      int num = IsEquallySpaced ? ControlHelper.MagicSpacingNumber : (_triggered ? -1 * ControlHelper.MagicSpacingNumber : 0);
      Thickness margin = Margin;
      switch (ChatBubbleDirection)
      {
        case ChatBubbleDirection.UpperRight:
        case ChatBubbleDirection.UpperLeft:
          margin.Bottom += num;
          break;
        case ChatBubbleDirection.LowerRight:
        case ChatBubbleDirection.LowerLeft:
          margin.Top += num;
          break;
      }
      Margin = margin;
    }
  }
}

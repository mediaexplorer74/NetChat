using Coding4Fun.Toolkit.Controls.Common;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Coding4Fun.Toolkit.Controls
{
  public class ChatBubble : ContentControl
  {
    public static readonly DependencyProperty ChatBubbleDirectionProperty = DependencyProperty.Register(nameof(ChatBubbleDirection), typeof(ChatBubbleDirection), typeof(ChatBubble), new PropertyMetadata(ChatBubbleDirection.UpperRight, OnChatBubbleDirectionChanged));
    public static readonly DependencyProperty IsEquallySpacedProperty = DependencyProperty.Register(nameof(IsEquallySpaced), typeof(bool), typeof(ChatBubble), new PropertyMetadata(true, OnIsEquallySpacedChanged));
    private static bool _triggered = false;

    public ChatBubble()
    {
      DefaultStyleKey = typeof(ChatBubble);
      IsEnabledChanged += ChatBubbleIsEnabledChanged;
    }

    private void ChatBubbleIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      UpdateIsEnabledVisualState();
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      UpdateChatBubbleDirection();
      UpdateIsEnabledVisualState();
      UpdateIsEquallySpaced();
    }

    public ChatBubbleDirection ChatBubbleDirection
    {
      get => (ChatBubbleDirection)GetValue(ChatBubbleDirectionProperty);
      set => SetValue(ChatBubbleDirectionProperty, value);
    }

    private static void OnChatBubbleDirectionChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (d is ChatBubble chatBubble)
        chatBubble.UpdateChatBubbleDirection();
    }

    private void UpdateChatBubbleDirection()
    {
      VisualStateManager.GoToState(this, ChatBubbleDirection.ToString(), true);
    }

    private void UpdateIsEnabledVisualState()
    {
      VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled", true);
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
      if (d is ChatBubble chatBubble)
      {
        _triggered = true;
        chatBubble.UpdateIsEquallySpaced();
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

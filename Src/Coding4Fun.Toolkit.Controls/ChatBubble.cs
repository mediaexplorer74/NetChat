// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ChatBubble
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class ChatBubble : ContentControl
  {
    public static readonly DependencyProperty ChatBubbleDirectionProperty = DependencyProperty.Register(nameof (ChatBubbleDirection), typeof (ChatBubbleDirection), typeof (ChatBubble), new PropertyMetadata((object) ChatBubbleDirection.UpperRight, new PropertyChangedCallback(ChatBubble.OnChatBubbleDirectionChanged)));
    public static readonly DependencyProperty IsEquallySpacedProperty = DependencyProperty.Register(nameof (IsEquallySpaced), typeof (bool), typeof (ChatBubble), new PropertyMetadata((object) true, new PropertyChangedCallback(ChatBubble.OnIsEquallySpacedChanged)));
    private static bool _triggered = false;

    public ChatBubble()
    {
      ((Control) this).put_DefaultStyleKey((object) typeof (ChatBubble));
      WindowsRuntimeMarshal.AddEventHandler<DependencyPropertyChangedEventHandler>(new Func<DependencyPropertyChangedEventHandler, EventRegistrationToken>(((Control) this).add_IsEnabledChanged), new Action<EventRegistrationToken>(((Control) this).remove_IsEnabledChanged), new DependencyPropertyChangedEventHandler(this.ChatBubbleIsEnabledChanged));
    }

    private void ChatBubbleIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      this.UpdateIsEnabledVisualState();
    }

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      this.UpdateChatBubbleDirection();
      this.UpdateIsEnabledVisualState();
      this.UpdateIsEquallySpaced();
    }

    public ChatBubbleDirection ChatBubbleDirection
    {
      get
      {
        return (ChatBubbleDirection) ((DependencyObject) this).GetValue(ChatBubble.ChatBubbleDirectionProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ChatBubble.ChatBubbleDirectionProperty, (object) value);
      }
    }

    private static void OnChatBubbleDirectionChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is ChatBubble chatBubble))
        return;
      chatBubble.UpdateChatBubbleDirection();
    }

    private void UpdateChatBubbleDirection()
    {
      VisualStateManager.GoToState((Control) this, this.ChatBubbleDirection.ToString(), true);
    }

    private void UpdateIsEnabledVisualState()
    {
      VisualStateManager.GoToState((Control) this, ((Control) this).IsEnabled ? "Normal" : "Disabled", true);
    }

    public bool IsEquallySpaced
    {
      get => (bool) ((DependencyObject) this).GetValue(ChatBubble.IsEquallySpacedProperty);
      set => ((DependencyObject) this).SetValue(ChatBubble.IsEquallySpacedProperty, (object) value);
    }

    private static void OnIsEquallySpacedChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is ChatBubble chatBubble))
        return;
      ChatBubble._triggered = true;
      chatBubble.UpdateIsEquallySpaced();
    }

    private void UpdateIsEquallySpaced()
    {
      int num = this.IsEquallySpaced ? ControlHelper.MagicSpacingNumber : (ChatBubble._triggered ? -1 * ControlHelper.MagicSpacingNumber : 0);
      Thickness margin = ((FrameworkElement) this).Margin;
      switch (this.ChatBubbleDirection)
      {
        case ChatBubbleDirection.UpperRight:
        case ChatBubbleDirection.UpperLeft:
          margin.Bottom += (double) num;
          break;
        case ChatBubbleDirection.LowerRight:
        case ChatBubbleDirection.LowerLeft:
          margin.Top += (double) num;
          break;
      }
      ((FrameworkElement) this).put_Margin(margin);
    }
  }
}

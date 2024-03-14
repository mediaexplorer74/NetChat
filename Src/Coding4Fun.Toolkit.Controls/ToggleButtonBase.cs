// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ToggleButtonBase
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public abstract class ToggleButtonBase : CheckBox, IButtonBase, IAppBarButton
  {
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof (Label), typeof (object), typeof (ToggleButtonBase), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty CheckedBrushProperty = DependencyProperty.Register(nameof (CheckedBrush), typeof (Brush), typeof (ToggleButtonBase), new PropertyMetadata((object) null));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (ToggleButtonBase), new PropertyMetadata((object) (Orientation) 0));
    public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(nameof (ButtonWidth), typeof (double), typeof (ToggleButtonBase), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(nameof (ButtonHeight), typeof (double), typeof (ToggleButtonBase), new PropertyMetadata((object) double.NaN));

    private void ApplyingTemplate()
    {
    }

    private bool IsContentEmpty(object content) => content == null;

    protected ToggleButtonBase()
    {
      WindowsRuntimeMarshal.AddEventHandler<DependencyPropertyChangedEventHandler>(new Func<DependencyPropertyChangedEventHandler, EventRegistrationToken>(((Control) this).add_IsEnabledChanged), new Action<EventRegistrationToken>(((Control) this).remove_IsEnabledChanged), new DependencyPropertyChangedEventHandler(this.IsEnabledStateChanged));
    }

    private void IsEnabledStateChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      this.IsEnabledStateChanged();
    }

    private void IsEnabledStateChanged()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ToggleButtonBase.\u003C\u003Ec__DisplayClass4_0 cDisplayClass40 = new ToggleButtonBase.\u003C\u003Ec__DisplayClass4_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass40.contentBody = ((Control) this).GetTemplateChild("ContentBody") as ContentControl;
      Grid templateChild1 = ((Control) this).GetTemplateChild("EnabledHolder") as Grid;
      Grid templateChild2 = ((Control) this).GetTemplateChild("DisabledHolder") as Grid;
      // ISSUE: reference to a compiler-generated field
      if (cDisplayClass40.contentBody != null && templateChild2 != null && templateChild1 != null)
      {
        if (!((Control) this).IsEnabled)
        {
          // ISSUE: reference to a compiler-generated field
          ((ICollection<UIElement>) ((Panel) templateChild1).Children).Remove((UIElement) cDisplayClass40.contentBody);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          ((ICollection<UIElement>) ((Panel) templateChild2).Children).Remove((UIElement) cDisplayClass40.contentBody);
        }
        if (((Control) this).IsEnabled)
        {
          // ISSUE: reference to a compiler-generated field
          if (!((ICollection<UIElement>) ((Panel) templateChild1).Children).Contains((UIElement) cDisplayClass40.contentBody))
          {
            // ISSUE: reference to a compiler-generated field
            ((IList<UIElement>) ((Panel) templateChild1).Children).Insert(0, (UIElement) cDisplayClass40.contentBody);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (!((ICollection<UIElement>) ((Panel) templateChild2).Children).Contains((UIElement) cDisplayClass40.contentBody))
          {
            // ISSUE: reference to a compiler-generated field
            ((IList<UIElement>) ((Panel) templateChild2).Children).Insert(0, (UIElement) cDisplayClass40.contentBody);
          }
        }
      }
      ((UIElement) this).UpdateLayout();
      if (ApplicationSpace.IsDesignMode)
      {
        // ISSUE: reference to a compiler-generated field
        ButtonBaseHelper.ApplyForegroundToFillBinding(cDisplayClass40.contentBody);
      }
      else
      {
        // ISSUE: method pointer
        ((DependencyObject) this).Dispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) cDisplayClass40, __methodptr(\u003CIsEnabledStateChanged\u003Eb__0))).AsTask();
      }
    }

    protected virtual void OnContentChanged(object oldContent, object newContent)
    {
      ((ContentControl) this).OnContentChanged(oldContent, newContent);
      if (oldContent == newContent)
        return;
      this.AppendCheck(((ContentControl) this).Content);
      this.IsEnabledStateChanged();
    }

    private void AppendCheck(object content)
    {
      if (!this.IsContentEmpty(content))
        return;
      ((ContentControl) this).put_Content((object) ButtonBaseHelper.CreateXamlCheck((FrameworkElement) this));
    }

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      this.ApplyingTemplate();
      this.AppendCheck(((ContentControl) this).Content);
      this.IsEnabledStateChanged();
      ButtonBaseHelper.ApplyTitleOffset(((Control) this).GetTemplateChild("ContentTitle") as ContentControl);
    }

    public object Label
    {
      get => ((DependencyObject) this).GetValue(ToggleButtonBase.LabelProperty);
      set => ((DependencyObject) this).SetValue(ToggleButtonBase.LabelProperty, value);
    }

    public Brush CheckedBrush
    {
      get => (Brush) ((DependencyObject) this).GetValue(ToggleButtonBase.CheckedBrushProperty);
      set
      {
        ((DependencyObject) this).SetValue(ToggleButtonBase.CheckedBrushProperty, (object) value);
      }
    }

    public Orientation Orientation
    {
      get => (Orientation) ((DependencyObject) this).GetValue(ToggleButtonBase.OrientationProperty);
      set
      {
        ((DependencyObject) this).SetValue(ToggleButtonBase.OrientationProperty, (object) value);
      }
    }

    public double ButtonWidth
    {
      get => (double) ((DependencyObject) this).GetValue(ToggleButtonBase.ButtonWidthProperty);
      set
      {
        ((DependencyObject) this).SetValue(ToggleButtonBase.ButtonWidthProperty, (object) value);
      }
    }

    public double ButtonHeight
    {
      get => (double) ((DependencyObject) this).GetValue(ToggleButtonBase.ButtonHeightProperty);
      set
      {
        ((DependencyObject) this).SetValue(ToggleButtonBase.ButtonHeightProperty, (object) value);
      }
    }
  }
}

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


namespace Coding4Fun.Toolkit.Controls
{
  public abstract class ToggleButtonBase : CheckBox, IButtonBase, IAppBarButton
  {
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof (Label), typeof (object), typeof (ToggleButtonBase), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty CheckedBrushProperty = DependencyProperty.Register(nameof (CheckedBrush), typeof (Brush), typeof (ToggleButtonBase), new PropertyMetadata((object) null));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (ToggleButtonBase), new PropertyMetadata((object) Orientation.Horizontal));
    public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(nameof (ButtonWidth), typeof (double), typeof (ToggleButtonBase), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(nameof (ButtonHeight), typeof (double), typeof (ToggleButtonBase), new PropertyMetadata((object) double.NaN));

    private void ApplyingTemplate()
    {
    }

    private bool IsContentEmpty(object content) => content == null;

    protected ToggleButtonBase()
    {
      this.IsEnabledChanged += IsEnabledStateChanged;
    }

    private void IsEnabledStateChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      this.IsEnabledStateChanged();
    }

    private void IsEnabledStateChanged()
    {
      var contentBody = this.GetTemplateChild("ContentBody") as ContentControl;
      Grid templateChild1 = this.GetTemplateChild("EnabledHolder") as Grid;
      Grid templateChild2 = this.GetTemplateChild("DisabledHolder") as Grid;
      
      if (contentBody != null && templateChild2 != null && templateChild1 != null)
      {
        if (!this.IsEnabled)
        {
          templateChild1.Children.Remove(contentBody);
        }
        else
        {
          templateChild2.Children.Remove(contentBody);
        }
        
        if (this.IsEnabled)
        {
          if (!templateChild1.Children.Contains(contentBody))
          {
            templateChild1.Children.Insert(0, contentBody);
          }
        }
        else
        {
          if (!templateChild2.Children.Contains(contentBody))
          {
            templateChild2.Children.Insert(0, contentBody);
          }
        }
      }
      
      this.UpdateLayout();
      
      if (ApplicationSpace.IsDesignMode)
      {
        ButtonBaseHelper.ApplyForegroundToFillBinding(contentBody);
      }
      else
      {
        this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
          ButtonBaseHelper.ApplyForegroundToFillBinding(contentBody);
        });
      }
    }

    protected override void OnContentChanged(object oldContent, object newContent)
    {
      base.OnContentChanged(oldContent, newContent);
      if (oldContent == newContent)
        return;
      this.AppendCheck(this.Content);
      this.IsEnabledStateChanged();
    }

    private void AppendCheck(object content)
    {
      if (!this.IsContentEmpty(content))
        return;
      ((ContentControl)this).Content = ButtonBaseHelper.CreateXamlCheck((FrameworkElement) this);
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.ApplyingTemplate();
      this.AppendCheck(this.Content);
      this.IsEnabledStateChanged();
      ButtonBaseHelper.ApplyTitleOffset(this.GetTemplateChild("ContentTitle") as ContentControl);
    }

    public object Label
    {
      get => this.GetValue(ToggleButtonBase.LabelProperty);
      set => this.SetValue(ToggleButtonBase.LabelProperty, value);
    }

    public Brush CheckedBrush
    {
      get => (Brush) this.GetValue(ToggleButtonBase.CheckedBrushProperty);
      set
      {
        this.SetValue(ToggleButtonBase.CheckedBrushProperty, value);
      }
    }

    public Orientation Orientation
    {
      get => (Orientation) this.GetValue(ToggleButtonBase.OrientationProperty);
      set
      {
        this.SetValue(ToggleButtonBase.OrientationProperty, value);
      }
    }

    public double ButtonWidth
    {
      get => (double) this.GetValue(ToggleButtonBase.ButtonWidthProperty);
      set
      {
        this.SetValue(ToggleButtonBase.ButtonWidthProperty, value);
      }
    }

    public double ButtonHeight
    {
      get => (double) this.GetValue(ToggleButtonBase.ButtonHeightProperty);
      set
      {
        this.SetValue(ToggleButtonBase.ButtonHeightProperty, value);
      }
    }
  }
}
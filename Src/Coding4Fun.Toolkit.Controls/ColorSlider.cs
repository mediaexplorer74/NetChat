﻿// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ColorSlider
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;


namespace Coding4Fun.Toolkit.Controls
{
  public class ColorSlider : ColorBaseControl
  {
    private const double HueSelectorSize = 24.0;
    private bool _fromSliderChange;
    protected Grid Body;
    private const string BodyName = "Body";
    protected Rectangle SelectedColor;
    private const string SelectedColorName = "SelectedColor";
    protected SuperSlider Slider;
    private const string SliderName = "Slider";
    public static readonly DependencyProperty ThumbProperty = DependencyProperty.Register(nameof (Thumb), typeof (object), typeof (ColorSlider), new PropertyMetadata((object) null));
    public static readonly DependencyProperty IsColorVisibleProperty = DependencyProperty.Register(nameof (IsColorVisible), typeof (bool), typeof (ColorSlider), new PropertyMetadata((object) true, new PropertyChangedCallback(ColorSlider.OnIsColorVisibleChanged)));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (ColorSlider), new PropertyMetadata((object) (Orientation) 0, new PropertyChangedCallback(ColorSlider.OnOrientationPropertyChanged)));

    public ColorSlider()
    {
      this.DefaultStyleKey = typeof (ColorSlider);
      this.IsEnabledChanged += this.SuperSlider_IsEnabledChanged;
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.Body = this.GetTemplateChild("Body") as Grid;
      this.Slider = this.GetTemplateChild("Slider") as SuperSlider;
      if (this.Thumb == null)
        this.Thumb = (object) new ColorSliderThumb();
      this.SelectedColor = this.GetTemplateChild("SelectedColor") as Rectangle;
      this.SizeChanged += this.UserControl_SizeChanged;
      if (this.Slider != null)
      {
        this.Slider.ValueChanged += new EventHandler<PropertyChangedEventArgs<double>>(this.Slider_ValueChanged);
        Color color = this.Color;
        if (color.A == (byte) 0)
        {
          color = this.Color;
          if (color.R == (byte) 0)
          {
            color = this.Color;
            if (color.G == (byte) 0)
            {
              color = this.Color;
              if (color.B == (byte) 0)
              {
                this.Color = Color.FromArgb(byte.MaxValue, (byte) 6, byte.MaxValue, (byte) 0);
                goto label_9;
              }
            }
          }
        }
        this.UpdateLayoutBasedOnColor();
      }
label_9:
      this.IsEnabledVisualStateUpdate();
    }

    private void Slider_ValueChanged(object sender, PropertyChangedEventArgs<double> e)
    {
      this.SetColorFromSlider(e.NewValue);
    }

    private void SetColorFromSlider(double value)
    {
      this._fromSliderChange = true;
      this.ColorChanging(ColorSpace.GetColorFromHueValue((float) ((int) value % 360)));
      this._fromSliderChange = false;
    }

    private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      this.AdjustLayoutBasedOnOrientation();
    }

    private void SuperSlider_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      this.IsEnabledVisualStateUpdate();
    }

    public object Thumb
    {
      get => this.GetValue(ColorSlider.ThumbProperty);
      set => this.SetValue(ColorSlider.ThumbProperty, value);
    }

    public bool IsColorVisible
    {
      get => (bool) this.GetValue(ColorSlider.IsColorVisibleProperty);
      set => this.SetValue(ColorSlider.IsColorVisibleProperty, value);
    }

    public Orientation Orientation
    {
      get => (Orientation) this.GetValue(ColorSlider.OrientationProperty);
      set => this.SetValue(ColorSlider.OrientationProperty, value);
    }

    private static void OnIsColorVisibleChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is ColorSlider colorSlider))
        return;
      colorSlider.AdjustLayoutBasedOnOrientation();
    }

    private static void OnOrientationPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is ColorSlider colorSlider))
        return;
      colorSlider.AdjustLayoutBasedOnOrientation();
    }

    private void AdjustLayoutBasedOnOrientation()
    {
      if (this.Body == null || this.Slider == null || this.SelectedColor == null)
        return;
      bool flag = this.Orientation == 0;
      this.IsEnabledVisualStateUpdate();
      ((ICollection<RowDefinition>) this.Body.RowDefinitions).Clear();
      ((ICollection<ColumnDefinition>) this.Body.ColumnDefinitions).Clear();
      if (flag)
      {
        ((ICollection<RowDefinition>) this.Body.RowDefinitions).Add(new RowDefinition());
        ((ICollection<RowDefinition>) this.Body.RowDefinitions).Add(new RowDefinition());
      }
      else
      {
        ((ICollection<ColumnDefinition>) this.Body.ColumnDefinitions).Add(new ColumnDefinition());
        ((ICollection<ColumnDefinition>) this.Body.ColumnDefinitions).Add(new ColumnDefinition());
      }
      FrameworkElement thumb = (FrameworkElement) this.Slider.Thumb;
      if (thumb != null)
      {
        thumb.Height = flag ? 24.0 : double.NaN;
        thumb.Width = flag ? double.NaN : 24.0;
      }
      ((DependencyObject) this.SelectedColor).SetValue(Grid.RowProperty, (object) (flag ? 1 : 0));
      ((DependencyObject) this.SelectedColor).SetValue(Grid.ColumnProperty, (object) (flag ? 0 : 1));
      double actualWidth = this.Slider.ActualWidth;
      double actualHeight = this.Slider.ActualHeight;
      double num1 = flag ? actualWidth : actualHeight;
      Rectangle selectedColor = this.SelectedColor;
      double num2;
      ((FrameworkElement) this.SelectedColor).Width = num2 = num1;
      double num3 = num2;
      ((FrameworkElement) selectedColor).Height = num3;
      if (flag)
      {
        ((IList<RowDefinition>) this.Body.RowDefinitions)[0].Height = new GridLength(1.0, GridUnitType.Star);
        ((IList<RowDefinition>) this.Body.RowDefinitions)[1].Height = new GridLength(1.0, GridUnitType.Auto);
      }
      else
      {
        ((IList<ColumnDefinition>) this.Body.ColumnDefinitions)[0].Width = new GridLength(1.0, GridUnitType.Star);
        ((IList<ColumnDefinition>) this.Body.ColumnDefinitions)[1].Width = new GridLength(1.0, GridUnitType.Auto);
      }
      this.SelectedColor.Visibility = this.IsColorVisible ? Visibility.Visible : Visibility.Collapsed;
    }

    protected internal override void UpdateLayoutBasedOnColor()
    {
      if (this._fromSliderChange)
        return;
      base.UpdateLayoutBasedOnColor();
      if (this.Slider == null)
        return;
      this.Slider.Value = (double) this.Color.GetHue();
    }

    private void IsEnabledVisualStateUpdate()
    {
      VisualStateManager.GoToState(this, this.IsEnabled ? "Normal" : "Disabled", true);
      this.Slider.Background = this.IsEnabled ? (Brush) ColorSpace.GetColorGradientBrush(this.Orientation) : (Brush) ColorSpace.GetBlackAndWhiteGradientBrush(this.Orientation);
    }
  }
}

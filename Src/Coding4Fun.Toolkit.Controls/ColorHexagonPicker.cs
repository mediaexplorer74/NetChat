// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ColorHexagonPicker
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;


namespace Coding4Fun.Toolkit.Controls
{
  public sealed class ColorHexagonPicker : ColorBaseControl
  {
    private bool _isLoaded;
    private bool _raisedFromRectangleFocusMethod;
    private Rectangle _focusedRectangle;
    private readonly List<Rectangle> _rectangles = new List<Rectangle>();
    public static readonly DependencyProperty SelectedStrokeColorProperty = DependencyProperty.Register(nameof (SelectedStrokeColor), typeof (Color), typeof (ColorHexagonPicker), new PropertyMetadata((object) Color.FromArgb(byte.MaxValue, (byte) 0, byte.MaxValue, byte.MaxValue)));
    public static readonly DependencyProperty ColorDarknessStepsProperty = DependencyProperty.Register(nameof (ColorDarknessSteps), typeof (int), typeof (ColorHexagonPicker), new PropertyMetadata((object) 2, new PropertyChangedCallback(ColorHexagonPicker.OnLayoutDependentPropertyChanged)));
    public static readonly DependencyProperty ColorBrightnessStepsProperty = DependencyProperty.Register(nameof (ColorBrightnessSteps), typeof (int), typeof (ColorHexagonPicker), new PropertyMetadata((object) 4, new PropertyChangedCallback(ColorHexagonPicker.OnLayoutDependentPropertyChanged)));
    public static readonly DependencyProperty GreyScaleStepsProperty = DependencyProperty.Register(nameof (GreyScaleSteps), typeof (int), typeof (ColorHexagonPicker), new PropertyMetadata((object) 20, new PropertyChangedCallback(ColorHexagonPicker.OnLayoutDependentPropertyChanged)));
    public static readonly DependencyProperty ColorSizeProperty = DependencyProperty.Register(nameof (ColorSize), typeof (double), typeof (ColorHexagonPicker), new PropertyMetadata((object) 24.0, new PropertyChangedCallback(ColorHexagonPicker.OnLayoutDependentPropertyChanged)));
    public static readonly DependencyProperty ColorBodyProperty = DependencyProperty.Register(nameof (ColorBody), typeof (object), typeof (ColorHexagonPicker), new PropertyMetadata((object) null));
    public static readonly DependencyProperty GreyScaleBodyProperty = DependencyProperty.Register(nameof (GreyScaleBody), typeof (object), typeof (ColorHexagonPicker), new PropertyMetadata((object) null));

    private void ColorHexagonPickerLoaded(object sender, RoutedEventArgs e)
    {
      this.ColorHexagonPickerLoaded();
    }

    private void SetRectangleEvents(UIElement rect)
    {
      UIElement uiElement1 = rect;
      WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(uiElement1.add_Tapped), new Action<EventRegistrationToken>(uiElement1.remove_Tapped), new TappedEventHandler(this.ExecuteRectangleSelect));
      UIElement uiElement2 = rect;
      WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(uiElement2.add_PointerMoved), new Action<EventRegistrationToken>(uiElement2.remove_PointerMoved), new PointerEventHandler(this.ExecuteRectangleHighlight));
    }

    private void ExecuteRectangleSelect(object sender, TappedRoutedEventArgs e)
    {
      this.ExecuteRectangleSelect(sender);
    }

    private void ExecuteRectangleHighlight(object sender, PointerRoutedEventArgs e)
    {
      this.ExecuteRectangleHighlight(sender, e.Pointer.IsInContact);
    }

    public ColorHexagonPicker()
    {
      this.put_DefaultStyleKey((object) typeof (ColorHexagonPicker));
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Loaded), new RoutedEventHandler(this.ColorHexagonPickerLoaded));
    }

    private void ColorHexagonPickerLoaded()
    {
      this._isLoaded = true;
      this.GenerateLayout();
    }

    protected internal override void UpdateLayoutBasedOnColor()
    {
      if (this._raisedFromRectangleFocusMethod)
        return;
      base.UpdateLayoutBasedOnColor();
      if (this._rectangles.All<Rectangle>((Func<Rectangle, bool>) (r => ((SolidColorBrush) ((Shape) r).Fill).Color != this.Color)))
        return;
      this.SetFocusedRectangle(this._rectangles.First<Rectangle>((Func<Rectangle, bool>) (r => ((SolidColorBrush) ((Shape) r).Fill).Color == this.Color)));
    }

    public void GenerateLayout()
    {
      if (!this._isLoaded)
        return;
      int totalSteps = this.ColorBrightnessSteps + this.ColorDarknessSteps;
      this.GreyScaleBody = (object) null;
      this.ColorBody = (object) null;
      this._rectangles.Clear();
      if (totalSteps > 0)
      {
        StackPanel stackPanel = new StackPanel();
        for (int i = 0; i < totalSteps; ++i)
        {
          int items = totalSteps + i + 1;
          ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) this.CreateChildren(items, this.CalculateOffsetForY(totalSteps, i)));
        }
        ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) this.CreateChildren(totalSteps * 2 + 1, 0.0));
        for (int i = totalSteps - 1; i >= 0; --i)
        {
          int items = totalSteps + i + 1;
          ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) this.CreateChildren(items, -this.CalculateOffsetForY(totalSteps, i)));
        }
        this.ColorBody = (object) stackPanel;
      }
      if (this.GreyScaleSteps <= 0)
        return;
      StackPanel stackPanel1 = new StackPanel();
      ((FrameworkElement) stackPanel1).put_Margin(new Thickness(0.0, this.ColorSize, 0.0, 0.0));
      StackPanel horizontalStackPanel1 = ColorHexagonPicker.CreateHorizontalStackPanel();
      StackPanel horizontalStackPanel2 = ColorHexagonPicker.CreateHorizontalStackPanel();
      int num1 = this.GreyScaleSteps + 2;
      double num2 = (double) byte.MaxValue / (double) num1;
      for (int index = 0; index <= num1; ++index)
      {
        byte num3 = (byte) (num2 * (double) index);
        Rectangle rectangle = this.CreateRectangle(Color.FromArgb(byte.MaxValue, num3, num3, num3));
        if (index % 2 == 0)
          ((ICollection<UIElement>) ((Panel) horizontalStackPanel1).Children).Add((UIElement) rectangle);
        else
          ((ICollection<UIElement>) ((Panel) horizontalStackPanel2).Children).Add((UIElement) rectangle);
      }
      ((ICollection<UIElement>) ((Panel) stackPanel1).Children).Add((UIElement) horizontalStackPanel1);
      ((ICollection<UIElement>) ((Panel) stackPanel1).Children).Add((UIElement) horizontalStackPanel2);
      this.GreyScaleBody = (object) stackPanel1;
    }

    private double CalculateOffsetForY(int totalSteps, int i)
    {
      return this.ColorSize * (double) (totalSteps - i - 1);
    }

    private static double CalculateDistance(double x1, double y1)
    {
      return Math.Sqrt(Math.Pow(x1, 2.0) + Math.Pow(y1, 2.0));
    }

    private static double CalculateAngle(double x1, double y1)
    {
      double num = Math.Atan2(y1, x1) * 57.295779513082323;
      return num <= 0.0 ? num + 360.0 : num;
    }

    private static StackPanel CreateHorizontalStackPanel()
    {
      StackPanel horizontalStackPanel = new StackPanel();
      ((FrameworkElement) horizontalStackPanel).put_HorizontalAlignment((HorizontalAlignment) 1);
      horizontalStackPanel.put_Orientation((Orientation) 1);
      return horizontalStackPanel;
    }

    private float CalculateStep(int steps, double distance)
    {
      return (float) (distance / ((double) steps * this.ColorSize));
    }

    private StackPanel CreateChildren(int items, double yOffset)
    {
      StackPanel horizontalStackPanel = ColorHexagonPicker.CreateHorizontalStackPanel();
      float num = (float) items / 2f;
      for (int index = 1; index <= items; ++index)
      {
        double x1 = ((double) index - (double) num - 0.5) * this.ColorSize;
        double distance1 = ColorHexagonPicker.CalculateDistance(x1, yOffset);
        float angle = (float) ColorHexagonPicker.CalculateAngle(x1, yOffset);
        Color rgb;
        if (this.ColorSize * (double) this.ColorBrightnessSteps >= distance1)
        {
          rgb = ColorSpace.ConvertHsvToRgb(angle, this.CalculateStep(this.ColorBrightnessSteps, distance1), 1f);
        }
        else
        {
          double distance2 = (double) (this.ColorBrightnessSteps + this.ColorDarknessSteps + 1) * this.ColorSize - distance1;
          rgb = ColorSpace.ConvertHsvToRgb(angle, 1f, this.CalculateStep(this.ColorDarknessSteps + 1, distance2));
        }
        ((ICollection<UIElement>) ((Panel) horizontalStackPanel).Children).Add((UIElement) this.CreateRectangle(rgb));
      }
      return horizontalStackPanel;
    }

    private Rectangle CreateRectangle(Color color)
    {
      Rectangle rectangle = new Rectangle();
      ((FrameworkElement) rectangle).put_Width(this.ColorSize);
      ((FrameworkElement) rectangle).put_Height(this.ColorSize);
      ((Shape) rectangle).put_StrokeThickness(3.0);
      ((Shape) rectangle).put_Stroke((Brush) new SolidColorBrush(color));
      ((Shape) rectangle).put_Fill((Brush) new SolidColorBrush(color));
      Rectangle rect = rectangle;
      this.SetRectangleEvents((UIElement) rect);
      if (this.Color == color)
        this.SetFocusedRectangle(rect);
      this._rectangles.Add(rect);
      return rect;
    }

    private void ExecuteRectangleSelect(object sender) => this.SetRectFromTapEvent(sender);

    private void ExecuteRectangleHighlight(object sender, bool isInContact)
    {
      if (!isInContact)
        return;
      this.SetRectFromTapEvent(sender);
    }

    private void SetRectFromTapEvent(object sender)
    {
      if (!(sender is Rectangle rect))
        return;
      this.SetFocusedRectangle(rect);
    }

    private void SetFocusedRectangle(Rectangle rect)
    {
      if (rect == null)
        return;
      ((Shape) rect).put_Stroke((Brush) new SolidColorBrush(this.SelectedStrokeColor));
      if (this._focusedRectangle != null && this._focusedRectangle != rect)
        ((Shape) this._focusedRectangle).put_Stroke(((Shape) this._focusedRectangle).Fill);
      this._focusedRectangle = rect;
      this._raisedFromRectangleFocusMethod = true;
      this.ColorChanging(((SolidColorBrush) ((Shape) rect).Fill).Color);
      this._raisedFromRectangleFocusMethod = false;
    }

    public Color SelectedStrokeColor
    {
      get
      {
        return (Color) ((DependencyObject) this).GetValue(ColorHexagonPicker.SelectedStrokeColorProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ColorHexagonPicker.SelectedStrokeColorProperty, (object) value);
      }
    }

    public int ColorDarknessSteps
    {
      get
      {
        return (int) ((DependencyObject) this).GetValue(ColorHexagonPicker.ColorDarknessStepsProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ColorHexagonPicker.ColorDarknessStepsProperty, (object) value);
      }
    }

    public int ColorBrightnessSteps
    {
      get
      {
        return (int) ((DependencyObject) this).GetValue(ColorHexagonPicker.ColorBrightnessStepsProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ColorHexagonPicker.ColorBrightnessStepsProperty, (object) value);
      }
    }

    public int GreyScaleSteps
    {
      get => (int) ((DependencyObject) this).GetValue(ColorHexagonPicker.GreyScaleStepsProperty);
      set
      {
        ((DependencyObject) this).SetValue(ColorHexagonPicker.GreyScaleStepsProperty, (object) value);
      }
    }

    public double ColorSize
    {
      get => (double) ((DependencyObject) this).GetValue(ColorHexagonPicker.ColorSizeProperty);
      set
      {
        ((DependencyObject) this).SetValue(ColorHexagonPicker.ColorSizeProperty, (object) value);
      }
    }

    public object ColorBody
    {
      get => ((DependencyObject) this).GetValue(ColorHexagonPicker.ColorBodyProperty);
      set => ((DependencyObject) this).SetValue(ColorHexagonPicker.ColorBodyProperty, value);
    }

    public object GreyScaleBody
    {
      get => ((DependencyObject) this).GetValue(ColorHexagonPicker.GreyScaleBodyProperty);
      set => ((DependencyObject) this).SetValue(ColorHexagonPicker.GreyScaleBodyProperty, value);
    }

    private static void OnLayoutDependentPropertyChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(o is ColorHexagonPicker colorHexagonPicker) || e.NewValue == e.OldValue)
        return;
      colorHexagonPicker.GenerateLayout();
    }
  }
}

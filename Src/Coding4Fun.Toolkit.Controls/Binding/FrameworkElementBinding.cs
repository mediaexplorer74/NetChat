using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Coding4Fun.Toolkit.Controls.Binding
{
  public class FrameworkElementBinding
  {
    public static readonly DependencyProperty ClipToBoundsProperty = DependencyProperty.RegisterAttached("ClipToBounds", typeof(bool), typeof(FrameworkElementBinding), new PropertyMetadata(false, OnClipToBoundsPropertyChanged));

    public static bool GetClipToBounds(DependencyObject obj)
    {
      return (bool)obj.GetValue(ClipToBoundsProperty);
    }

    public static void SetClipToBounds(DependencyObject obj, bool value)
    {
      obj.SetValue(ClipToBoundsProperty, value);
    }

    private static void OnClipToBoundsPropertyChanged(
      DependencyObject obj,
      DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == e.OldValue)
        return;
      HandleClipToBoundsEventAppend(obj, (bool)e.NewValue);
    }

    private static void HandleClipToBoundsEventAppend(object sender, bool value)
    {
      if (!(sender is FrameworkElement element))
        return;
        
      SetClippingBound(element, value);
      
      if (value)
      {
        element.Loaded += ClipToBoundsPropertyChanged;
        element.SizeChanged += ClipToBoundsPropertyChanged;
      }
      else
      {
        element.Loaded -= ClipToBoundsPropertyChanged;
        element.SizeChanged -= ClipToBoundsPropertyChanged;
      }
    }

    private static void ClipToBoundsPropertyChanged(object sender, RoutedEventArgs e)
    {
      if (sender is FrameworkElement element)
        SetClippingBound(element, GetClipToBounds(element));
    }

    private static void SetClippingBound(FrameworkElement element, bool setClippingBound)
    {
      if (setClippingBound)
      {
        var rectangleGeometry = new RectangleGeometry
        {
          Rect = new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight)
        };
        element.Clip = rectangleGeometry;
      }
      else
      {
        element.Clip = null;
      }
    }
  }
}

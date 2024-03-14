// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Binding.FrameworkElementBinding
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls.Binding
{
  public class FrameworkElementBinding
  {
    public static readonly DependencyProperty ClipToBoundsProperty = DependencyProperty.RegisterAttached("ClipToBounds", typeof (bool), typeof (FrameworkElementBinding), new PropertyMetadata((object) false, new PropertyChangedCallback(FrameworkElementBinding.OnClipToBoundsPropertyChanged)));

    public static bool GetClipToBounds(DependencyObject obj)
    {
      return (bool) obj.GetValue(FrameworkElementBinding.ClipToBoundsProperty);
    }

    public static void SetClipToBounds(DependencyObject obj, bool value)
    {
      obj.SetValue(FrameworkElementBinding.ClipToBoundsProperty, (object) value);
    }

    private static void OnClipToBoundsPropertyChanged(
      DependencyObject obj,
      DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == e.OldValue)
        return;
      FrameworkElementBinding.HandleClipToBoundsEventAppend((object) obj, (bool) e.NewValue);
    }

    private static void HandleClipToBoundsEventAppend(object sender, bool value)
    {
      if (!(sender is FrameworkElement element))
        return;
      FrameworkElementBinding.SetClippingBound(element, value);
      if (value)
      {
        FrameworkElement frameworkElement1 = element;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(frameworkElement1.add_Loaded), new Action<EventRegistrationToken>(frameworkElement1.remove_Loaded), new RoutedEventHandler(FrameworkElementBinding.ClipToBoundsPropertyChanged));
        FrameworkElement frameworkElement2 = element;
        WindowsRuntimeMarshal.AddEventHandler<SizeChangedEventHandler>(new Func<SizeChangedEventHandler, EventRegistrationToken>(frameworkElement2.add_SizeChanged), new Action<EventRegistrationToken>(frameworkElement2.remove_SizeChanged), new SizeChangedEventHandler(FrameworkElementBinding.ClipToBoundsPropertyChanged));
      }
      else
      {
        WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(element.remove_Loaded), new RoutedEventHandler(FrameworkElementBinding.ClipToBoundsPropertyChanged));
        WindowsRuntimeMarshal.RemoveEventHandler<SizeChangedEventHandler>(new Action<EventRegistrationToken>(element.remove_SizeChanged), new SizeChangedEventHandler(FrameworkElementBinding.ClipToBoundsPropertyChanged));
      }
    }

    private static void ClipToBoundsPropertyChanged(object sender, RoutedEventArgs e)
    {
      if (!(sender is FrameworkElement element))
        return;
      FrameworkElementBinding.SetClippingBound(element, FrameworkElementBinding.GetClipToBounds((DependencyObject) element));
    }

    private static void SetClippingBound(FrameworkElement element, bool setClippingBound)
    {
      if (setClippingBound)
      {
        FrameworkElement frameworkElement = element;
        RectangleGeometry rectangleGeometry = new RectangleGeometry();
        rectangleGeometry.put_Rect(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
        ((UIElement) frameworkElement).put_Clip(rectangleGeometry);
      }
      else
        ((UIElement) element).put_Clip((RectangleGeometry) null);
    }
  }
}

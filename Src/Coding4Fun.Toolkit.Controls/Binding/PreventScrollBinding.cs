// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Binding.PreventScrollBinding
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Binding
{
  public class PreventScrollBinding
  {
    private static FrameworkElement _internalPanningControl;
    private static readonly DependencyProperty IsScrollSuspendedProperty = DependencyProperty.RegisterAttached("IsScrollSuspended", typeof (bool), typeof (PreventScrollBinding), new PropertyMetadata((object) false));
    private static readonly DependencyProperty LastTouchPointProperty = DependencyProperty.RegisterAttached("LastTouchPoint", typeof (Point), typeof (PreventScrollBinding), new PropertyMetadata((object) null));
    public static readonly DependencyProperty IsEnabled = DependencyProperty.RegisterAttached(nameof (IsEnabled), typeof (bool), typeof (PreventScrollBinding), new PropertyMetadata((object) false, new PropertyChangedCallback(PreventScrollBinding.IsEnabledDependencyPropertyChangedCallback)));

    public static bool GetIsEnabled(DependencyObject obj)
    {
      return (bool) obj.GetValue(PreventScrollBinding.IsEnabled);
    }

    public static void SetIsEnabled(DependencyObject obj, bool value)
    {
      obj.SetValue(PreventScrollBinding.IsEnabled, (object) value);
    }

    private static void IsEnabledDependencyPropertyChangedCallback(
      DependencyObject dobj,
      DependencyPropertyChangedEventArgs ea)
    {
      if (!(dobj is FrameworkElement frameworkElement1))
        return;
      FrameworkElement frameworkElement2 = frameworkElement1;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(frameworkElement2.add_Unloaded), new Action<EventRegistrationToken>(frameworkElement2.remove_Unloaded), new RoutedEventHandler(PreventScrollBinding.BlockingElementUnloaded));
      FrameworkElement frameworkElement3 = frameworkElement1;
      WindowsRuntimeMarshal.AddEventHandler<ManipulationStartedEventHandler>(new Func<ManipulationStartedEventHandler, EventRegistrationToken>(((UIElement) frameworkElement3).add_ManipulationStarted), new Action<EventRegistrationToken>(((UIElement) frameworkElement3).remove_ManipulationStarted), new ManipulationStartedEventHandler(PreventScrollBinding.SuspendScroll));
      FrameworkElement frameworkElement4 = frameworkElement1;
      WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(((UIElement) frameworkElement4).add_PointerPressed), new Action<EventRegistrationToken>(((UIElement) frameworkElement4).remove_PointerPressed), new PointerEventHandler(PreventScrollBinding.SuspendScroll));
      FrameworkElement frameworkElement5 = frameworkElement1;
      WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(((UIElement) frameworkElement5).add_PointerMoved), new Action<EventRegistrationToken>(((UIElement) frameworkElement5).remove_PointerMoved), new PointerEventHandler(PreventScrollBinding.SuspendScroll));
    }

    private static void BlockingElementUnloaded(object sender, RoutedEventArgs e)
    {
      if (!(sender is FrameworkElement frameworkElement))
        return;
      WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(frameworkElement.remove_Unloaded), new RoutedEventHandler(PreventScrollBinding.BlockingElementUnloaded));
      WindowsRuntimeMarshal.RemoveEventHandler<ManipulationStartedEventHandler>(new Action<EventRegistrationToken>(((UIElement) frameworkElement).remove_ManipulationStarted), new ManipulationStartedEventHandler(PreventScrollBinding.SuspendScroll));
      WindowsRuntimeMarshal.RemoveEventHandler<PointerEventHandler>(new Action<EventRegistrationToken>(((UIElement) frameworkElement).remove_PointerPressed), new PointerEventHandler(PreventScrollBinding.SuspendScroll));
    }

    private static void SuspendScroll(object sender, RoutedEventArgs e)
    {
      FrameworkElement blockingElement = sender as FrameworkElement;
      if (PreventScrollBinding._internalPanningControl == null)
        PreventScrollBinding._internalPanningControl = PreventScrollBinding.FindAncestor((DependencyObject) blockingElement, (Func<DependencyObject, bool>) (p =>
        {
          switch (p)
          {
            case Pivot _:
            case Hub _:
              return true;
            default:
              return p is FlipView;
          }
        })) as FrameworkElement;
      if (PreventScrollBinding._internalPanningControl != null && (bool) ((DependencyObject) PreventScrollBinding._internalPanningControl).GetValue(PreventScrollBinding.IsScrollSuspendedProperty) || PreventScrollBinding.FindAncestor(e.OriginalSource as DependencyObject, (Func<DependencyObject, bool>) (dobj => dobj == blockingElement)) != blockingElement)
        return;
      if (PreventScrollBinding._internalPanningControl != null)
        ((DependencyObject) PreventScrollBinding._internalPanningControl).SetValue(PreventScrollBinding.IsScrollSuspendedProperty, (object) true);
      CoreWindow forCurrentThread = CoreWindow.GetForCurrentThread();
      // ISSUE: method pointer
      WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<CoreWindow, PointerEventArgs>>(new Func<TypedEventHandler<CoreWindow, PointerEventArgs>, EventRegistrationToken>(forCurrentThread.add_PointerReleased), new Action<EventRegistrationToken>(forCurrentThread.remove_PointerReleased), new TypedEventHandler<CoreWindow, PointerEventArgs>((object) null, __methodptr(PreventScrollBinding_PointerReleased)));
      if (blockingElement != null)
        ((UIElement) blockingElement).put_IsHitTestVisible(true);
      if (PreventScrollBinding._internalPanningControl == null)
        return;
      ((UIElement) PreventScrollBinding._internalPanningControl).put_IsHitTestVisible(false);
    }

    private static void PreventScrollBinding_PointerReleased(
      CoreWindow sender,
      PointerEventArgs args)
    {
      if (PreventScrollBinding._internalPanningControl == null)
        return;
      Point point = (Point) ((DependencyObject) PreventScrollBinding._internalPanningControl).GetValue(PreventScrollBinding.LastTouchPointProperty);
      bool flag = (bool) ((DependencyObject) PreventScrollBinding._internalPanningControl).GetValue(PreventScrollBinding.IsScrollSuspendedProperty);
      Point position = args.CurrentPoint.Position;
      int num = point != position ? 1 : 0;
      if (!flag)
        return;
      // ISSUE: method pointer
      WindowsRuntimeMarshal.RemoveEventHandler<TypedEventHandler<CoreWindow, PointerEventArgs>>(new Action<EventRegistrationToken>(CoreWindow.GetForCurrentThread().remove_PointerReleased), new TypedEventHandler<CoreWindow, PointerEventArgs>((object) null, __methodptr(PreventScrollBinding_PointerReleased)));
      ((UIElement) PreventScrollBinding._internalPanningControl).put_IsHitTestVisible(true);
      ((DependencyObject) PreventScrollBinding._internalPanningControl).SetValue(PreventScrollBinding.IsScrollSuspendedProperty, (object) false);
    }

    public static DependencyObject FindAncestor(
      DependencyObject dependencyObject,
      Func<DependencyObject, bool> predicate)
    {
      if (predicate(dependencyObject))
        return dependencyObject;
      DependencyObject dependencyObject1 = (DependencyObject) null;
      if (dependencyObject is FrameworkElement frameworkElement)
        dependencyObject1 = frameworkElement.Parent ?? VisualTreeHelper.GetParent((DependencyObject) frameworkElement);
      return dependencyObject1 == null ? (DependencyObject) null : PreventScrollBinding.FindAncestor(dependencyObject1, predicate);
    }
  }
}

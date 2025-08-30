using System;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Coding4Fun.Toolkit.Controls.Binding
{
  public class PreventScrollBinding
  {
    private static FrameworkElement _internalPanningControl;
    private static readonly DependencyProperty IsScrollSuspendedProperty = DependencyProperty.RegisterAttached("IsScrollSuspended", typeof(bool), typeof(PreventScrollBinding), new PropertyMetadata(false));
    private static readonly DependencyProperty LastTouchPointProperty = DependencyProperty.RegisterAttached("LastTouchPoint", typeof(Point), typeof(PreventScrollBinding), new PropertyMetadata(null));
    public static readonly DependencyProperty IsEnabled = DependencyProperty.RegisterAttached(nameof(IsEnabled), typeof(bool), typeof(PreventScrollBinding), new PropertyMetadata(false, IsEnabledDependencyPropertyChangedCallback));

    public static bool GetIsEnabled(DependencyObject obj)
    {
      return (bool)obj.GetValue(IsEnabled);
    }

    public static void SetIsEnabled(DependencyObject obj, bool value)
    {
      obj.SetValue(IsEnabled, value);
    }

    private static void IsEnabledDependencyPropertyChangedCallback(
      DependencyObject dobj,
      DependencyPropertyChangedEventArgs ea)
    {
      if (!(dobj is FrameworkElement frameworkElement))
        return;
      
      frameworkElement.Unloaded += BlockingElementUnloaded;
      frameworkElement.ManipulationStarted += SuspendScroll;
      frameworkElement.PointerPressed += SuspendScroll;
      frameworkElement.PointerMoved += SuspendScroll;
    }

    private static void BlockingElementUnloaded(object sender, RoutedEventArgs e)
    {
      if (!(sender is FrameworkElement frameworkElement))
        return;
      
      frameworkElement.Unloaded -= BlockingElementUnloaded;
      frameworkElement.ManipulationStarted -= SuspendScroll;
      frameworkElement.PointerPressed -= SuspendScroll;
    }

    private static void SuspendScroll(object sender, RoutedEventArgs e)
    {
      FrameworkElement blockingElement = sender as FrameworkElement;
      if (_internalPanningControl == null)
        _internalPanningControl = FindAncestor(blockingElement, p =>
        {
          return p is Pivot || p is Hub || p is FlipView;
        }) as FrameworkElement;
      
      if (_internalPanningControl != null && (bool)_internalPanningControl.GetValue(IsScrollSuspendedProperty) || 
          FindAncestor(e.OriginalSource as DependencyObject, dobj => dobj == blockingElement) != blockingElement)
        return;
        
      if (_internalPanningControl != null)
        _internalPanningControl.SetValue(IsScrollSuspendedProperty, true);
        
      CoreWindow forCurrentThread = CoreWindow.GetForCurrentThread();
      forCurrentThread.PointerReleased += PreventScrollBinding_PointerReleased;
      
      if (blockingElement != null)
        blockingElement.IsHitTestVisible = true;
      if (_internalPanningControl != null)
        _internalPanningControl.IsHitTestVisible = false;
    }

    private static void PreventScrollBinding_PointerReleased(
      CoreWindow sender,
      PointerEventArgs args)
    {
      if (_internalPanningControl == null)
        return;
        
      Point point = (Point)_internalPanningControl.GetValue(LastTouchPointProperty);
      bool flag = (bool)_internalPanningControl.GetValue(IsScrollSuspendedProperty);
      Point position = args.CurrentPoint.Position;
      bool moved = point != position;
      
      if (!flag)
        return;
        
      CoreWindow.GetForCurrentThread().PointerReleased -= PreventScrollBinding_PointerReleased;
      _internalPanningControl.IsHitTestVisible = true;
      _internalPanningControl.SetValue(IsScrollSuspendedProperty, false);
    }

    public static DependencyObject FindAncestor(
      DependencyObject dependencyObject,
      Func<DependencyObject, bool> predicate)
    {
      if (predicate(dependencyObject))
        return dependencyObject;
        
      DependencyObject parent = null;
      if (dependencyObject is FrameworkElement frameworkElement)
        parent = frameworkElement.Parent ?? VisualTreeHelper.GetParent(frameworkElement);
        
      return parent == null ? null : FindAncestor(parent, predicate);
    }
  }
}

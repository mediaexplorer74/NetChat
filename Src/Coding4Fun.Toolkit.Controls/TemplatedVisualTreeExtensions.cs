// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.TemplatedVisualTreeExtensions
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Coding4Fun.Toolkit.Controls
{
  public static class TemplatedVisualTreeExtensions
  {
    public static T GetFirstLogicalChildByType<T>(this FrameworkElement parent, bool applyTemplates) where T : FrameworkElement
    {
      Queue<FrameworkElement> frameworkElementQueue = new Queue<FrameworkElement>();
      frameworkElementQueue.Enqueue(parent);
      while (frameworkElementQueue.Count > 0)
      {
        FrameworkElement parent1 = frameworkElementQueue.Dequeue();
        Control control = parent1 as Control;
        if (applyTemplates && control != null)
          control.ApplyTemplate();
        if (parent1 is T && parent1 != parent)
          return (T) parent1;
        foreach (FrameworkElement frameworkElement in ((DependencyObject) parent1).GetVisualChildren().OfType<FrameworkElement>())
          frameworkElementQueue.Enqueue(frameworkElement);
      }
      return default (T);
    }

    public static IEnumerable<T> GetLogicalChildrenByType<T>(
      this FrameworkElement parent,
      bool applyTemplates)
      where T : FrameworkElement
    {
      if (applyTemplates && parent is Control)
        ((Control) parent).ApplyTemplate();
      Queue<FrameworkElement> queue = new Queue<FrameworkElement>(((DependencyObject) parent).GetVisualChildren().OfType<FrameworkElement>());
      while (queue.Count > 0)
      {
        FrameworkElement element = queue.Dequeue();
        if (applyTemplates && element is Control)
          ((Control) element).ApplyTemplate();
        if (element is T obj)
          yield return obj;
        foreach (FrameworkElement frameworkElement in ((DependencyObject) element).GetVisualChildren().OfType<FrameworkElement>())
          queue.Enqueue(frameworkElement);
        element = (FrameworkElement) null;
      }
    }

    public static IEnumerable<T> GetVisualAncestorsByType<T>(
      this FrameworkElement node,
      bool applyTemplates)
      where T : FrameworkElement
    {
      for (FrameworkElement parent = node.GetVisualParent(); parent != null; parent = parent.GetVisualParent())
      {
        if (applyTemplates && parent is Control)
          ((Control) parent).ApplyTemplate();
        if (parent is T)
          yield return parent as T;
      }
    }
  }
}

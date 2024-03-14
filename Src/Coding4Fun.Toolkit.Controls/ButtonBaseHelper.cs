// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ButtonBaseHelper
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Converters;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  internal static class ButtonBaseHelper
  {
    public static void ApplyTitleOffset(ContentControl contentTitle)
    {
      if (contentTitle == null)
        return;
      double bottom = -(((Control) contentTitle).FontSize / 8.0);
      double top = -(((Control) contentTitle).FontSize / 2.0) - bottom;
      ((FrameworkElement) contentTitle).put_Margin(new Thickness(0.0, top, 0.0, bottom));
    }

    public static void ApplyForegroundToFillBinding(ContentControl control)
    {
      if (control == null || !(control.Content is FrameworkElement content))
        return;
      if (content.IsTypeOf(typeof (Shape)))
      {
        Shape target = content as Shape;
        ButtonBaseHelper.ResetVerifyAndApplyForegroundToFillBinding((FrameworkElement) control, target);
      }
      else
      {
        foreach (Shape target in content.GetLogicalChildrenByType<Shape>(false))
        {
          target.GetHashCode();
          ButtonBaseHelper.ResetVerifyAndApplyForegroundToFillBinding((FrameworkElement) control, target);
        }
      }
    }

    internal static void ResetVerifyAndApplyForegroundToFillBinding(
      FrameworkElement source,
      Shape target)
    {
      if (target == null)
        return;
      bool flag = !(((DependencyObject) target).ReadLocalValue(Shape.FillProperty) is Brush);
      if (!(target.Fill == null | flag))
        return;
      target.put_Fill((Brush) null);
      ButtonBaseHelper.ApplyBinding(source, (FrameworkElement) target, "Foreground", Shape.FillProperty);
    }

    internal static void ApplyForegroundToFillBinding(
      FrameworkElement source,
      FrameworkElement target)
    {
      ButtonBaseHelper.ApplyBinding(source, target, "Foreground", Shape.FillProperty);
    }

    public static void ApplyBinding(
      FrameworkElement source,
      FrameworkElement target,
      string propertyPath,
      DependencyProperty property,
      IValueConverter converter = null,
      object converterParameter = null)
    {
      if (source == null || target == null)
        return;
      Binding binding = new Binding();
      binding.put_Source((object) source);
      binding.put_Path(new PropertyPath(propertyPath));
      binding.put_Converter(converter);
      binding.put_ConverterParameter(converterParameter);
      target.SetBinding(property, (BindingBase) binding);
    }

    public static Path CreateXamlCheck(FrameworkElement control)
    {
      if (XamlReader.Load("<Path \r\n\t\t\t\t\txmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n\t\t\t\t\tStretch=\"Uniform\" \r\n\t\t\t\t\tData=\"F1M227.2217,408.499L226.4427,407.651C226.2357,407.427,226.2467,407.075,226.4737,406.865L228.7357,404.764C228.8387,404.668,228.9737,404.615,229.1147,404.615C229.2707,404.615,229.4147,404.679,229.5207,404.792L235.7317,411.479L246.4147,397.734C246.5207,397.601,246.6827,397.522,246.8547,397.522C246.9797,397.522,247.0987,397.563,247.1967,397.639L249.6357,399.533C249.7507,399.624,249.8257,399.756,249.8447,399.906C249.8627,400.052,249.8237,400.198,249.7357,400.313L236.0087,417.963z\"\r\n\t\t\t\t\t/>") is Path target)
        ButtonBaseHelper.ApplyBinding(control, (FrameworkElement) target, "ButtonHeight", FrameworkElement.HeightProperty, (IValueConverter) new NumberMultiplierConverter(), (object) 0.25);
      return target;
    }

    public static Path CreateXamlCancel(FrameworkElement control)
    {
      if (XamlReader.Load("<Path \r\n\t\t\t\t\txmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\r\n\t\t\t\t\tStretch=\"Uniform\" \r\n\t\t\t\t\tData=\"M15.047,0 L17.709,2.663 L11.5166,8.85499 L17.71,15.048 L15.049,17.709 L8.8553,11.5161 L2.662,17.709 L0,15.049 L6.19351,8.85467 L0.002036,2.66401 L2.66304,0.002015 L8.85463,6.19319 z\"\r\n\t\t\t\t\t/>") is Path target)
        ButtonBaseHelper.ApplyBinding(control, (FrameworkElement) target, "ButtonHeight", FrameworkElement.HeightProperty, (IValueConverter) new NumberMultiplierConverter(), (object) 0.25);
      return target;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.ControlHelper
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;


namespace Coding4Fun.Toolkit.Controls.Common
{
  public class ControlHelper
  {
    internal static int MagicSpacingNumber = 10;

    [Obsolete("Made into extension, Moved to Coding4Fun.Toolkit.dll now, Namespace is System, ")]
    public static double CheckBound(double value, double max) => value.CheckBound(max);

    [Obsolete("Made into extension, Moved to Coding4Fun.Toolkit.dll now, Namespace is System, ")]
    public static double CheckBound(double value, double min, double max)
    {
      return value.CheckBound(min, max);
    }

    public static void CreateDoubleAnimations(
      Storyboard sb,
      DependencyObject target,
      string propertyPath,
      double fromValue = 0.0,
      double toValue = 0.0,
      int speed = 500)
    {
      DoubleAnimation doubleAnimation1 = new DoubleAnimation();
      doubleAnimation1.put_To(new double?(toValue));
      doubleAnimation1.put_From(new double?(fromValue));
      ((Timeline) doubleAnimation1).put_Duration(new Duration(TimeSpan.FromMilliseconds((double) speed)));
      DoubleAnimation doubleAnimation2 = doubleAnimation1;
      Storyboard.SetTarget((Timeline) doubleAnimation2, target);
      Storyboard.SetTargetProperty((Timeline) doubleAnimation2, propertyPath);
      ((ICollection<Timeline>) sb.Children).Add((Timeline) doubleAnimation2);
    }
  }
}

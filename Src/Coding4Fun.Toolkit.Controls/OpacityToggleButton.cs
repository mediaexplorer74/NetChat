// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.OpacityToggleButton
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Coding4Fun.Toolkit.Controls
{
  public class OpacityToggleButton : ToggleButtonBase
  {
    public static readonly DependencyProperty AnimationDurationProperty = DependencyProperty.Register(nameof (AnimationDuration), typeof (Duration), typeof (OpacityToggleButton), new PropertyMetadata((object) new Duration(TimeSpan.FromMilliseconds(100.0))));
    public static readonly DependencyProperty UncheckedOpacityProperty = DependencyProperty.Register(nameof (UncheckedOpacity), typeof (double), typeof (OpacityToggleButton), new PropertyMetadata((object) 0.5));
    public static readonly DependencyProperty CheckedOpacityProperty = DependencyProperty.Register(nameof (CheckedOpacity), typeof (double), typeof (OpacityToggleButton), new PropertyMetadata((object) 1.0));

    public OpacityToggleButton()
    {
      ((Control) this).put_DefaultStyleKey((object) typeof (OpacityToggleButton));
    }

    public Duration AnimationDuration
    {
      get
      {
        return (Duration) ((DependencyObject) this).GetValue(OpacityToggleButton.AnimationDurationProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(OpacityToggleButton.AnimationDurationProperty, (object) value);
      }
    }

    public double UncheckedOpacity
    {
      get
      {
        return (double) ((DependencyObject) this).GetValue(OpacityToggleButton.UncheckedOpacityProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(OpacityToggleButton.UncheckedOpacityProperty, (object) value);
      }
    }

    public double CheckedOpacity
    {
      get
      {
        return (double) ((DependencyObject) this).GetValue(OpacityToggleButton.CheckedOpacityProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(OpacityToggleButton.CheckedOpacityProperty, (object) value);
      }
    }
  }
}

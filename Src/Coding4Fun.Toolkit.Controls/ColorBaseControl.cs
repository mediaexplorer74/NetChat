// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ColorBaseControl
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls
{
  public abstract class ColorBaseControl : Control
  {
    public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof (Color), typeof (Color), typeof (ColorBaseControl), new PropertyMetadata((object) null, new PropertyChangedCallback(ColorBaseControl.OnColorChanged)));
    public static readonly DependencyProperty SolidColorBrushProperty = DependencyProperty.Register(nameof (SolidColorBrush), typeof (SolidColorBrush), typeof (ColorBaseControl), new PropertyMetadata((object) null));

    public event ColorBaseControl.ColorChangedHandler ColorChanged;

    public Color Color
    {
      get => (Color) ((DependencyObject) this).GetValue(ColorBaseControl.ColorProperty);
      set => ((DependencyObject) this).SetValue(ColorBaseControl.ColorProperty, (object) value);
    }

    public SolidColorBrush SolidColorBrush
    {
      get
      {
        return (SolidColorBrush) ((DependencyObject) this).GetValue(ColorBaseControl.SolidColorBrushProperty);
      }
      private set
      {
        ((DependencyObject) this).SetValue(ColorBaseControl.SolidColorBrushProperty, (object) value);
      }
    }

    private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (!(d is ColorBaseControl colorBaseControl))
        return;
      colorBaseControl.UpdateLayoutBasedOnColor();
      colorBaseControl.SolidColorBrush = new SolidColorBrush((Color) e.NewValue);
    }

    protected internal virtual void UpdateLayoutBasedOnColor()
    {
    }

    protected internal void ColorChanging(Color color)
    {
      this.Color = color;
      this.SolidColorBrush = new SolidColorBrush(this.Color);
      if (this.ColorChanged == null)
        return;
      this.ColorChanged((object) this, this.Color);
    }

    public delegate void ColorChangedHandler(object sender, Color color);
  }
}

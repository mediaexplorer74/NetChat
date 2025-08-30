// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.MovementMonitor
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;


namespace Coding4Fun.Toolkit.Controls
{
  public class MovementMonitor
  {
    protected Rectangle Monitor;
    private double _xOffsetStartValue;
    private double _yOffsetStartValue;

    public event EventHandler<MovementMonitorEventArgs> Movement;

    public void MonitorControl(Panel panel)
    {
      Rectangle rectangle = new Rectangle();
      ((Shape)rectangle).Fill = new SolidColorBrush(Color.FromArgb((byte) 0, (byte) 0, (byte) 0, (byte) 0));
      this.Monitor = rectangle;
      this.Monitor.SetValue(Grid.RowSpanProperty, 2147483646);
      this.Monitor.SetValue(Grid.ColumnSpanProperty, 2147483646);
      ((UIElement)this.Monitor).PointerPressed += this.Monitor_PointerPressed;
      ((UIElement)this.Monitor).PointerReleased += this.Monitor_PointerReleased;
      ((UIElement)this.Monitor).PointerMoved += this.Monitor_PointerMoved;
      ((ICollection<UIElement>) panel.Children).Add((UIElement) this.Monitor);
    }

    private void Monitor_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
      Point position = e.GetCurrentPoint((UIElement) this.Monitor).Position;
      if (this.Movement != null)
        this.Movement((object) this, new MovementMonitorEventArgs()
        {
          X = position.X,
          Y = position.Y
        });
      ((PointerRoutedEventArgs)e).Handled = true;
    }

    private void Monitor_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
      Point position = e.GetCurrentPoint((UIElement) this.Monitor).Position;
      this._xOffsetStartValue = position.X;
      this._yOffsetStartValue = position.Y;
      if (this.Movement != null)
        this.Movement((object) this, new MovementMonitorEventArgs()
        {
          X = this._xOffsetStartValue,
          Y = this._yOffsetStartValue
        });
      ((PointerRoutedEventArgs)e).Handled = true;
    }

    private void Monitor_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
      if (!e.Pointer.IsInContact)
        return;
      Point position = e.GetCurrentPoint((UIElement) this.Monitor).Position;
      if (this.Movement != null)
        this.Movement((object) this, new MovementMonitorEventArgs()
        {
          X = position.X,
          Y = position.Y
        });
      ((PointerRoutedEventArgs)e).Handled = true;
    }
  }
}

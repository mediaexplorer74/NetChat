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
      ((Shape) rectangle).put_Fill((Brush) new SolidColorBrush(Color.FromArgb((byte) 0, (byte) 0, (byte) 0, (byte) 0)));
      this.Monitor = rectangle;
      ((DependencyObject) this.Monitor).SetValue(Grid.RowSpanProperty, (object) 2147483646);
      ((DependencyObject) this.Monitor).SetValue(Grid.ColumnSpanProperty, (object) 2147483646);
      Rectangle monitor1 = this.Monitor;
      WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(((UIElement) monitor1).add_PointerPressed), new Action<EventRegistrationToken>(((UIElement) monitor1).remove_PointerPressed), new PointerEventHandler(this.Monitor_PointerPressed));
      Rectangle monitor2 = this.Monitor;
      WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(((UIElement) monitor2).add_PointerReleased), new Action<EventRegistrationToken>(((UIElement) monitor2).remove_PointerReleased), new PointerEventHandler(this.Monitor_PointerReleased));
      Rectangle monitor3 = this.Monitor;
      WindowsRuntimeMarshal.AddEventHandler<PointerEventHandler>(new Func<PointerEventHandler, EventRegistrationToken>(((UIElement) monitor3).add_PointerMoved), new Action<EventRegistrationToken>(((UIElement) monitor3).remove_PointerMoved), new PointerEventHandler(this.Monitor_PointerMoved));
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
      e.put_Handled(true);
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
      e.put_Handled(true);
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
      e.put_Handled(true);
    }
  }
}

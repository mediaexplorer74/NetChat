// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.RectangularButton
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls
{
  public class RectangularButton : ButtonBase, IAppBarButton
  {
    public static readonly DependencyProperty PressedBrushProperty = DependencyProperty.Register(nameof (PressedBrush), typeof (Brush), typeof (RectangularButton), new PropertyMetadata((object) null));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (RectangularButton), new PropertyMetadata((object) (Orientation) 0));
    public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(nameof (ButtonWidth), typeof (double), typeof (RectangularButton), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(nameof (ButtonHeight), typeof (double), typeof (RectangularButton), new PropertyMetadata((object) double.NaN));

    public RectangularButton()
    {
      ((Control) this).put_DefaultStyleKey((object) typeof (RectangularButton));
    }

    private void ApplyingTemplate()
    {
    }

    private bool IsContentEmpty(object content) => content == null;

    protected virtual void OnContentChanged(object oldContent, object newContent)
    {
      ((ContentControl) this).OnContentChanged(oldContent, newContent);
      if (oldContent == newContent)
        return;
      this.AppendCheck(((ContentControl) this).Content);
      ButtonBaseHelper.ApplyForegroundToFillBinding(((Control) this).GetTemplateChild("ContentBody") as ContentControl);
    }

    private void AppendCheck(object content)
    {
      if (!this.IsContentEmpty(content))
        return;
      ((ContentControl) this).put_Content((object) ButtonBaseHelper.CreateXamlCheck((FrameworkElement) this));
    }

    protected override void OnApplyTemplate()
    {
      this.ApplyingTemplate();
      this.AppendCheck(((ContentControl) this).Content);
      ButtonBaseHelper.ApplyForegroundToFillBinding(((Control) this).GetTemplateChild("ContentBody") as ContentControl);
      ButtonBaseHelper.ApplyTitleOffset(((Control) this).GetTemplateChild("ContentTitle") as ContentControl);
      base.OnApplyTemplate();
    }

    public Brush PressedBrush
    {
      get => (Brush) ((DependencyObject) this).GetValue(RectangularButton.PressedBrushProperty);
      set
      {
        ((DependencyObject) this).SetValue(RectangularButton.PressedBrushProperty, (object) value);
      }
    }

    public Orientation Orientation
    {
      get
      {
        return (Orientation) ((DependencyObject) this).GetValue(RectangularButton.OrientationProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(RectangularButton.OrientationProperty, (object) value);
      }
    }

    public double ButtonWidth
    {
      get => (double) ((DependencyObject) this).GetValue(RectangularButton.ButtonWidthProperty);
      set
      {
        ((DependencyObject) this).SetValue(RectangularButton.ButtonWidthProperty, (object) value);
      }
    }

    public double ButtonHeight
    {
      get => (double) ((DependencyObject) this).GetValue(RectangularButton.ButtonHeightProperty);
      set
      {
        ((DependencyObject) this).SetValue(RectangularButton.ButtonHeightProperty, (object) value);
      }
    }
  }
}

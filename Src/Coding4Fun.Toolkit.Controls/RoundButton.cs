// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.RoundButton
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class RoundButton : ButtonBase, IAppBarButton
  {
    public static readonly DependencyProperty PressedBrushProperty = DependencyProperty.Register(nameof (PressedBrush), typeof (Brush), typeof (RoundButton), new PropertyMetadata((object) null));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (RoundButton), new PropertyMetadata((object) (Orientation) 0));
    public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(nameof (ButtonWidth), typeof (double), typeof (RoundButton), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(nameof (ButtonHeight), typeof (double), typeof (RoundButton), new PropertyMetadata((object) double.NaN));

    private void ApplyingTemplate()
    {
    }

    private bool IsContentEmpty(object content) => content == null;

    public RoundButton() => ((Control) this).put_DefaultStyleKey((object) typeof (RoundButton));

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
      get => (Brush) ((DependencyObject) this).GetValue(RoundButton.PressedBrushProperty);
      set => ((DependencyObject) this).SetValue(RoundButton.PressedBrushProperty, (object) value);
    }

    public Orientation Orientation
    {
      get => (Orientation) ((DependencyObject) this).GetValue(RoundButton.OrientationProperty);
      set => ((DependencyObject) this).SetValue(RoundButton.OrientationProperty, (object) value);
    }

    public double ButtonWidth
    {
      get => (double) ((DependencyObject) this).GetValue(RoundButton.ButtonWidthProperty);
      set => ((DependencyObject) this).SetValue(RoundButton.ButtonWidthProperty, (object) value);
    }

    public double ButtonHeight
    {
      get => (double) ((DependencyObject) this).GetValue(RoundButton.ButtonHeightProperty);
      set => ((DependencyObject) this).SetValue(RoundButton.ButtonHeightProperty, (object) value);
    }
  }
}

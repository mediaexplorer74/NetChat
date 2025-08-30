// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.RoundButton
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls
{
  public class RoundButton : ButtonBase, IAppBarButton
  {
    public static readonly DependencyProperty PressedBrushProperty = DependencyProperty.Register(nameof (PressedBrush), typeof (Brush), typeof (RoundButton), new PropertyMetadata((object) null));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (RoundButton), new PropertyMetadata((object) Orientation.Horizontal));
    public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(nameof (ButtonWidth), typeof (double), typeof (RoundButton), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(nameof (ButtonHeight), typeof (double), typeof (RoundButton), new PropertyMetadata((object) double.NaN));

    private void ApplyingTemplate()
    {
    }

    private bool IsContentEmpty(object content) => content == null;

    public RoundButton() => this.DefaultStyleKey = typeof (RoundButton);

    protected override void OnContentChanged(object oldContent, object newContent)
    {
      base.OnContentChanged(oldContent, newContent);
      if (oldContent == newContent)
        return;
      this.AppendCheck(this.Content);
      ButtonBaseHelper.ApplyForegroundToFillBinding(this.GetTemplateChild("ContentBody") as ContentControl);
    }

    private void AppendCheck(object content)
    {
      if (!this.IsContentEmpty(content))
        return;
      ((ContentControl)this).Content = ButtonBaseHelper.CreateXamlCheck(this);
    }

    protected override void OnApplyTemplate()
    {
      this.ApplyingTemplate();
      this.AppendCheck(this.Content);
      ButtonBaseHelper.ApplyForegroundToFillBinding(this.GetTemplateChild("ContentBody") as ContentControl);
      ButtonBaseHelper.ApplyTitleOffset(this.GetTemplateChild("ContentTitle") as ContentControl);
      base.OnApplyTemplate();
    }

    public Brush PressedBrush
    {
      get => (Brush) this.GetValue(RoundButton.PressedBrushProperty);
      set => this.SetValue(RoundButton.PressedBrushProperty, value);
    }

    public Orientation Orientation
    {
      get => (Orientation) this.GetValue(RoundButton.OrientationProperty);
      set => this.SetValue(RoundButton.OrientationProperty, value);
    }

    public double ButtonWidth
    {
      get => (double) this.GetValue(RoundButton.ButtonWidthProperty);
      set => this.SetValue(RoundButton.ButtonWidthProperty, value);
    }

    public double ButtonHeight
    {
      get => (double) this.GetValue(RoundButton.ButtonHeightProperty);
      set => this.SetValue(RoundButton.ButtonHeightProperty, value);
    }
  }
}
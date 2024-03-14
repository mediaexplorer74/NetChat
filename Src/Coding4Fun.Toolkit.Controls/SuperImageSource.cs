// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.SuperImageSource
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls
{
  public class SuperImageSource : DependencyObject
  {
    public static readonly DependencyProperty MinScaleProperty = DependencyProperty.Register(nameof (MinScale), typeof (int), typeof (SuperImageSource), new PropertyMetadata((object) 0));
    public static readonly DependencyProperty MaxScaleProperty = DependencyProperty.Register(nameof (MaxScale), typeof (int), typeof (SuperImageSource), new PropertyMetadata((object) 0));
    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof (Source), typeof (ImageSource), typeof (SuperImageSource), new PropertyMetadata((object) null));
    public static readonly DependencyProperty IsDefaultProperty = DependencyProperty.Register(nameof (IsDefault), typeof (bool), typeof (SuperImageSource), new PropertyMetadata((object) false));

    public int MinScale
    {
      get => (int) this.GetValue(SuperImageSource.MinScaleProperty);
      set => this.SetValue(SuperImageSource.MinScaleProperty, (object) value);
    }

    public int MaxScale
    {
      get => (int) this.GetValue(SuperImageSource.MaxScaleProperty);
      set => this.SetValue(SuperImageSource.MaxScaleProperty, (object) value);
    }

    public ImageSource Source
    {
      get => (ImageSource) this.GetValue(SuperImageSource.SourceProperty);
      set => this.SetValue(SuperImageSource.SourceProperty, (object) value);
    }

    public bool IsDefault
    {
      get => (bool) this.GetValue(SuperImageSource.IsDefaultProperty);
      set => this.SetValue(SuperImageSource.IsDefaultProperty, (object) value);
    }
  }
}

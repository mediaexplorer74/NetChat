// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Tile
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class Tile : ButtonBase
  {
    public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(nameof (TextWrapping), typeof (TextWrapping), typeof (Tile), new PropertyMetadata((object) (TextWrapping) 1));

    public Tile() => ((Control) this).put_DefaultStyleKey((object) typeof (Tile));

    public TextWrapping TextWrapping
    {
      get => (TextWrapping) ((DependencyObject) this).GetValue(Tile.TextWrappingProperty);
      set => ((DependencyObject) this).SetValue(Tile.TextWrappingProperty, (object) value);
    }
  }
}

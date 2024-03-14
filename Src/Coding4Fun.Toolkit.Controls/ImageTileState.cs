// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ImageTileState
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml.Media.Animation;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public struct ImageTileState
  {
    public Storyboard Storyboard { get; set; }

    public int Row { get; set; }

    public int Column { get; set; }

    public bool ForceLargeImageCleanup { get; set; }
  }
}

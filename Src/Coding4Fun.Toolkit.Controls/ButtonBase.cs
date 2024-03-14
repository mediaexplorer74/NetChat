// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ButtonBase
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public abstract class ButtonBase : Button, IButtonBase
  {
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof (Label), typeof (object), typeof (ButtonBase), new PropertyMetadata((object) string.Empty));

    protected virtual void OnApplyTemplate() => ((FrameworkElement) this).OnApplyTemplate();

    public object Label
    {
      get => ((DependencyObject) this).GetValue(ButtonBase.LabelProperty);
      set => ((DependencyObject) this).SetValue(ButtonBase.LabelProperty, value);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ProgressOverlay
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;


namespace Coding4Fun.Toolkit.Controls
{
  public class ProgressOverlay : ContentControl
  {
    private Storyboard _fadeIn;
    private Storyboard _fadeOut;
    private Grid _layoutGrid;
    private const string FadeInName = "FadeInStoryboard";
    private const string FadeOutName = "FadeOutStoryboard";
    private const string LayoutGridName = "LayoutGrid";
    public static readonly DependencyProperty ProgressControlProperty = DependencyProperty.Register(nameof (ProgressControl), typeof (object), typeof (ProgressOverlay), new PropertyMetadata((object) null));

    public ProgressOverlay()
    {
      ((Control) this).put_DefaultStyleKey((object) typeof (ProgressOverlay));
    }

    public object ProgressControl
    {
      get => ((DependencyObject) this).GetValue(ProgressOverlay.ProgressControlProperty);
      set => ((DependencyObject) this).SetValue(ProgressOverlay.ProgressControlProperty, value);
    }

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      this._fadeIn = ((Control) this).GetTemplateChild("FadeInStoryboard") as Storyboard;
      this._fadeOut = ((Control) this).GetTemplateChild("FadeOutStoryboard") as Storyboard;
      this._layoutGrid = ((Control) this).GetTemplateChild("LayoutGrid") as Grid;
      if (this._fadeOut == null)
        return;
      Storyboard fadeOut = this._fadeOut;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(((Timeline) fadeOut).add_Completed), new Action<EventRegistrationToken>(((Timeline) fadeOut).remove_Completed), new EventHandler<object>(this.FadeOutCompleted));
    }

    private void FadeOutCompleted(object sender, object o)
    {
      ((UIElement) this._layoutGrid).put_Opacity(1.0);
      ((UIElement) this).put_Visibility((Visibility) 1);
    }

    public void Show()
    {
      if (this._fadeIn == null)
        ((Control) this).ApplyTemplate();
      ((UIElement) this).put_Visibility((Visibility) 0);
      if (this._fadeOut != null)
        this._fadeOut.Stop();
      if (this._fadeIn == null)
        return;
      this._fadeIn.Begin();
    }

    public void Hide()
    {
      if (this._fadeOut == null)
        ((Control) this).ApplyTemplate();
      if (this._fadeIn != null)
        this._fadeIn.Stop();
      if (this._fadeOut == null)
        return;
      this._fadeOut.Begin();
    }
  }
}

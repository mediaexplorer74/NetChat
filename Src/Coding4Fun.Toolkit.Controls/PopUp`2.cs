// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.PopUp`2
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Clarity.Phone.Extensions;
using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls
{
  public abstract class PopUp<T, TPopUpResult> : Control
  {
    internal DialogService PopUpService;
    private Page _startingPage;
    private bool _alreadyFired;
    private bool _isCalculateFrameVerticalOffset;
    private bool _isOverlayApplied = true;
    private static readonly DependencyProperty FrameTransformProperty = DependencyProperty.Register(nameof (FrameTransform), typeof (double), typeof (PopUp<T, TPopUpResult>), new PropertyMetadata((object) 0.0, new PropertyChangedCallback(PopUp<T, TPopUpResult>.OnFrameTransformPropertyChanged)));
    public static readonly DependencyProperty OverlayProperty = DependencyProperty.Register(nameof (Overlay), typeof (Brush), typeof (PopUp<T, TPopUpResult>), new PropertyMetadata((object) null));

    public event EventHandler<PopUpEventArgs<T, TPopUpResult>> Completed;

    public event EventHandler Opened;

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      if (this.PopUpService == null)
        return;
      this.PopUpService.BackgroundBrush = this.Overlay;
      this.PopUpService.ApplyOverlayBackground();
      this.PopUpService.SetAlignmentsOnOverlay(((FrameworkElement) this).HorizontalAlignment, ((FrameworkElement) this).VerticalAlignment);
    }

    public virtual async void Show()
    {
      if (this.IsOpen)
        return;
      if (this._alreadyFired)
        throw new InvalidOperationException("Invalid control state, do not reuse object after calling Show()");
      if (this.PopUpService == null)
        this.PopUpService = new DialogService()
        {
          AnimationType = this.AnimationType,
          Child = (FrameworkElement) this,
          IsBackKeyOverride = this.IsBackKeyOverride,
          IsOverlayApplied = this.IsOverlayApplied,
          MainBodyDelay = this.MainBodyDelay
        };
      if (this.PopUpService.Page == null)
      {
        CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        PopUp<T, TPopUpResult> popUp = this;
        // ISSUE: virtual method pointer
        DispatchedHandler dispatchedHandler = new DispatchedHandler((object) popUp, __vmethodptr(popUp, Show));
        await dispatcher.RunAsync((CoreDispatcherPriority) 0, dispatchedHandler);
      }
      else
      {
        if (this.IsCalculateFrameVerticalOffset)
          this.PopUpService.ControlVerticalOffset = -this.FrameTransform;
        this.PopUpService.Closed -= new EventHandler(this.PopUpClosed);
        this.PopUpService.Opened -= new EventHandler(this.PopUpOpened);
        this.PopUpService.Closed += new EventHandler(this.PopUpClosed);
        this.PopUpService.Opened += new EventHandler(this.PopUpOpened);
        if (!this.IsAppBarVisible && this.PopUpService.Page.BottomAppBar != null && ((UIElement) this.PopUpService.Page.BottomAppBar).Visibility == null)
        {
          ((UIElement) this.PopUpService.Page.BottomAppBar).put_Visibility((Visibility) 1);
          this.IsSetAppBarVisibiilty = true;
        }
        this._startingPage = this.PopUpService.Page;
        this.PopUpService.Show();
      }
    }

    protected virtual TPopUpResult GetOnClosedValue() => default (TPopUpResult);

    public void Hide() => this.PopUpClosed((object) this, (EventArgs) null);

    private void PopUpOpened(object sender, EventArgs e)
    {
      if (this.Opened == null)
        return;
      this.Opened(sender, e);
    }

    private void PopUpClosed(object sender, EventArgs e)
    {
      if (!this._alreadyFired)
        this.OnCompleted(new PopUpEventArgs<T, TPopUpResult>()
        {
          PopUpResult = this.GetOnClosedValue()
        });
      else
        this.ResetWorldAndDestroyPopUp();
    }

    public virtual void OnCompleted(PopUpEventArgs<T, TPopUpResult> result)
    {
      this._alreadyFired = true;
      if (this.Completed != null)
        this.Completed((object) this, result);
      if (this.PopUpService != null)
        this.PopUpService.Hide();
      if (this.PopUpService == null || !this.PopUpService.BackButtonPressed)
        return;
      this.ResetWorldAndDestroyPopUp();
    }

    private void ResetWorldAndDestroyPopUp()
    {
      if (this.PopUpService == null)
        return;
      if (!this.IsAppBarVisible && this.IsSetAppBarVisibiilty)
        ((UIElement) this._startingPage.BottomAppBar).put_Visibility(this.IsSetAppBarVisibiilty ? (Visibility) 0 : (Visibility) 1);
      this._startingPage = (Page) null;
      this.PopUpService.Child = (FrameworkElement) null;
      this.PopUpService = (DialogService) null;
    }

    private static void OnFrameTransformPropertyChanged(
      DependencyObject source,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(source is PopUp<T, TPopUpResult> popUp) || popUp.PopUpService == null || !popUp.IsCalculateFrameVerticalOffset)
        return;
      popUp.PopUpService.ControlVerticalOffset = -popUp.FrameTransform;
      popUp.PopUpService.CalculateVerticalOffset();
    }

    public bool IsOpen => this.PopUpService != null && this.PopUpService.IsOpen;

    public bool IsAppBarVisible { get; set; }

    protected bool IsCalculateFrameVerticalOffset
    {
      get => this._isCalculateFrameVerticalOffset;
      set
      {
        this._isCalculateFrameVerticalOffset = value;
        if (!this._isCalculateFrameVerticalOffset)
          return;
        Binding binding = new Binding();
        binding.put_Path(new PropertyPath("Y"));
        Frame rootFrame = ApplicationSpace.RootFrame;
        if (rootFrame == null || !(((UIElement) rootFrame).RenderTransform is TransformGroup renderTransform))
          return;
        binding.put_Source((object) ((IEnumerable<Transform>) renderTransform.Children).FirstOrDefault<Transform>((Func<Transform, bool>) (t => t is TranslateTransform)));
        ((FrameworkElement) this).SetBinding(PopUp<T, TPopUpResult>.FrameTransformProperty, (BindingBase) binding);
      }
    }

    public bool IsOverlayApplied
    {
      get => this._isOverlayApplied;
      set => this._isOverlayApplied = value;
    }

    internal bool IsSetAppBarVisibiilty { get; set; }

    internal TimeSpan MainBodyDelay { get; set; }

    protected internal bool IsBackKeyOverride { get; set; }

    protected DialogService.AnimationTypes AnimationType { get; set; }

    private double FrameTransform
    {
      get
      {
        return (double) ((DependencyObject) this).GetValue(PopUp<T, TPopUpResult>.FrameTransformProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(PopUp<T, TPopUpResult>.FrameTransformProperty, (object) value);
      }
    }

    public Brush Overlay
    {
      get => (Brush) ((DependencyObject) this).GetValue(PopUp<T, TPopUpResult>.OverlayProperty);
      set
      {
        ((DependencyObject) this).SetValue(PopUp<T, TPopUpResult>.OverlayProperty, (object) value);
      }
    }
  }
}

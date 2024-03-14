// Decompiled with JetBrains decompiler
// Type: Clarity.Phone.Extensions.DialogService
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls;
using Coding4Fun.Toolkit.Controls.Binding;
using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

#nullable disable
namespace Clarity.Phone.Extensions
{
  public class DialogService
  {
    private const string SlideUpStoryboard = "\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.Y)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"150\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.35\" Value=\"0\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"0\" To=\"1\" Duration=\"0:0:0.350\">\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>";
    private const string SlideHorizontalInStoryboard = "\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.X)\" >\r\n                    <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"-150\"/>\r\n                    <EasingDoubleKeyFrame KeyTime=\"0:0:0.35\" Value=\"0\">\r\n                        <EasingDoubleKeyFrame.EasingFunction>\r\n                            <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                        </EasingDoubleKeyFrame.EasingFunction>\r\n                    </EasingDoubleKeyFrame>\r\n                </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"0\" To=\"1\" Duration=\"0:0:0.350\" >\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>";
    private const string SlideHorizontalOutStoryboard = "\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.X)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"0\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.25\" Value=\"150\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"1\" To=\"0\" Duration=\"0:0:0.25\">\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>";
    private const string SlideDownStoryboard = "\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.Y)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"0\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.25\" Value=\"150\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"1\" To=\"0\" Duration=\"0:0:0.25\">\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>";
    private const string SwivelInStoryboard = "<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation \r\n\t\t\t\tTo=\".5\"\r\n                Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.CenterOfRotationY)\" />\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.RotationX)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"-30\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.35\" Value=\"0\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Opacity)\">\r\n                <DiscreteDoubleKeyFrame KeyTime=\"0\" Value=\"1\" />\r\n            </DoubleAnimationUsingKeyFrames>\r\n        </Storyboard>";
    private const string SwivelOutStoryboard = "<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation BeginTime=\"0:0:0\" Duration=\"0\" \r\n                                Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.CenterOfRotationY)\" \r\n                                To=\".5\"/>\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.RotationX)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"0\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.25\" Value=\"45\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Opacity)\">\r\n                <DiscreteDoubleKeyFrame KeyTime=\"0\" Value=\"1\" />\r\n                <DiscreteDoubleKeyFrame KeyTime=\"0:0:0.267\" Value=\"0\" />\r\n            </DoubleAnimationUsingKeyFrames>\r\n        </Storyboard>";
    private const string FadeInStoryboard = "<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation \r\n\t\t\t\tDuration=\"0:0:0.2\" \r\n\t\t\t\tStoryboard.TargetProperty=\"(UIElement.Opacity)\" \r\n                To=\"1\"/>\r\n        </Storyboard>";
    private const string FadeOutStoryboard = "<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation \r\n\t\t\t\tDuration=\"0:0:0.2\"\r\n\t\t\t\tStoryboard.TargetProperty=\"(UIElement.Opacity)\" \r\n                To=\"0\"/>\r\n        </Storyboard>";
    private Panel _popupContainer;
    private Frame _rootFrame;
    private Page _page;
    private Grid _childPanel;
    private Grid _overlay;
    private bool _isOverlayApplied = true;
    private bool _deferredShowToLoaded;
    private static readonly object Lockobj = new object();

    public bool IsOverlayApplied
    {
      get => this._isOverlayApplied;
      set => this._isOverlayApplied = value;
    }

    public FrameworkElement Child { get; set; }

    public DialogService.AnimationTypes AnimationType { get; set; }

    public TimeSpan MainBodyDelay { get; set; }

    public double VerticalOffset { get; set; }

    internal double ControlVerticalOffset { get; set; }

    public bool BackButtonPressed { get; set; }

    public Brush BackgroundBrush { get; set; }

    internal bool IsOpen { get; set; }

    protected internal bool IsBackKeyOverride { get; set; }

    public event EventHandler Closed;

    public event EventHandler Opened;

    public bool HasPopup { get; set; }

    internal Page Page
    {
      get
      {
        return this._page ?? (this._page = ((FrameworkElement) this.RootFrame).GetFirstLogicalChildByType<Page>(false));
      }
    }

    internal Frame RootFrame => this._rootFrame ?? (this._rootFrame = ApplicationSpace.RootFrame);

    internal Panel PopupContainer
    {
      get
      {
        if (this._popupContainer == null)
        {
          IEnumerable<ContentPresenter> logicalChildrenByType1 = ((FrameworkElement) this.RootFrame).GetLogicalChildrenByType<ContentPresenter>(false);
          for (int index = 0; index < logicalChildrenByType1.Count<ContentPresenter>(); ++index)
          {
            IEnumerable<Panel> logicalChildrenByType2 = ((FrameworkElement) logicalChildrenByType1.ElementAt<ContentPresenter>(index)).GetLogicalChildrenByType<Panel>(false);
            if (logicalChildrenByType2.Any<Panel>())
            {
              this._popupContainer = logicalChildrenByType2.First<Panel>();
              break;
            }
          }
        }
        return this._popupContainer;
      }
    }

    public DialogService()
    {
      this.AnimationType = DialogService.AnimationTypes.Slide;
      this.BackButtonPressed = false;
    }

    private void InitializePopup()
    {
      this._childPanel = this.CreateGrid();
      if (this.IsOverlayApplied)
      {
        this._overlay = this.CreateGrid();
        PreventScrollBinding.SetIsEnabled((DependencyObject) this._overlay, true);
      }
      this.ApplyOverlayBackground();
      if (this.PopupContainer != null)
      {
        if (this._overlay != null)
          ((ICollection<UIElement>) this.PopupContainer.Children).Add((UIElement) this._overlay);
        ((ICollection<UIElement>) this.PopupContainer.Children).Add((UIElement) this._childPanel);
        ((ICollection<UIElement>) ((Panel) this._childPanel).Children).Add((UIElement) this.Child);
      }
      else
      {
        this._deferredShowToLoaded = true;
        Frame rootFrame = this.RootFrame;
        WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) rootFrame).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) rootFrame).remove_Loaded), new RoutedEventHandler(this.RootFrameDeferredShowLoaded));
      }
    }

    internal void ApplyOverlayBackground()
    {
      if (!this.IsOverlayApplied || this.BackgroundBrush == null)
        return;
      ((Panel) this._overlay).put_Background(this.BackgroundBrush);
    }

    private Grid CreateGrid()
    {
      Grid grid1 = new Grid();
      ((FrameworkElement) grid1).put_Name(Guid.NewGuid().ToString());
      Grid grid2 = grid1;
      Grid.SetColumnSpan((FrameworkElement) grid2, int.MaxValue);
      Grid.SetRowSpan((FrameworkElement) grid2, int.MaxValue);
      ((UIElement) grid2).put_Opacity(0.0);
      this.CalculateVerticalOffset((Panel) grid2);
      return grid2;
    }

    internal void CalculateVerticalOffset()
    {
      this.CalculateVerticalOffset((Panel) this._childPanel);
    }

    internal void CalculateVerticalOffset(Panel panel)
    {
      if (panel == null)
        return;
      int num = 0;
      ((FrameworkElement) panel).put_Margin(new Thickness(0.0, this.VerticalOffset + (double) num + this.ControlVerticalOffset, 0.0, 0.0));
    }

    private void RootFrameDeferredShowLoaded(object sender, RoutedEventArgs e)
    {
      WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(((FrameworkElement) this.RootFrame).remove_Loaded), new RoutedEventHandler(this.RootFrameDeferredShowLoaded));
      this._deferredShowToLoaded = false;
      this.Show();
    }

    protected internal void SetAlignmentsOnOverlay(
      HorizontalAlignment horizontalAlignment,
      VerticalAlignment verticalAlignment)
    {
      if (this._childPanel == null)
        return;
      ((FrameworkElement) this._childPanel).put_HorizontalAlignment(horizontalAlignment);
      ((FrameworkElement) this._childPanel).put_VerticalAlignment(verticalAlignment);
    }

    public void Show()
    {
      lock (DialogService.Lockobj)
      {
        WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<BackPressedEventArgs>>(new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.OnBackKeyPress));
        this.IsOpen = true;
        this.InitializePopup();
        if (this._deferredShowToLoaded)
          return;
        if (!this.IsBackKeyOverride)
          WindowsRuntimeMarshal.AddEventHandler<EventHandler<BackPressedEventArgs>>(new Func<EventHandler<BackPressedEventArgs>, EventRegistrationToken>(HardwareButtons.add_BackPressed), new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.OnBackKeyPress));
        Frame rootFrame = this.RootFrame;
        WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(rootFrame.add_Navigated), new Action<EventRegistrationToken>(rootFrame.remove_Navigated), new NavigatedEventHandler(this.OnNavigated));
        this.RunShowStoryboard((UIElement) this._overlay, DialogService.AnimationTypes.Fade);
        this.RunShowStoryboard((UIElement) this._childPanel, this.AnimationType, this.MainBodyDelay);
        if (this.Opened == null)
          return;
        this.Opened((object) this, (EventArgs) null);
      }
    }

    private void RunShowStoryboard(UIElement grid, DialogService.AnimationTypes animation)
    {
      this.RunShowStoryboard(grid, animation, TimeSpan.MinValue);
    }

    private async void RunShowStoryboard(
      UIElement grid,
      DialogService.AnimationTypes animation,
      TimeSpan delay)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      DialogService.\u003C\u003Ec__DisplayClass82_0 cDisplayClass820 = new DialogService.\u003C\u003Ec__DisplayClass82_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass820.grid = grid;
      // ISSUE: reference to a compiler-generated field
      if (cDisplayClass820.grid == null)
        return;
      switch (animation)
      {
        case DialogService.AnimationTypes.Slide:
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.storyboard = XamlReader.Load("\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.Y)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"150\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.35\" Value=\"0\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"0\" To=\"1\" Duration=\"0:0:0.350\">\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>") as Storyboard;
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.grid.put_RenderTransform((Transform) new TranslateTransform());
          break;
        case DialogService.AnimationTypes.SlideHorizontal:
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.storyboard = XamlReader.Load("\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.X)\" >\r\n                    <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"-150\"/>\r\n                    <EasingDoubleKeyFrame KeyTime=\"0:0:0.35\" Value=\"0\">\r\n                        <EasingDoubleKeyFrame.EasingFunction>\r\n                            <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                        </EasingDoubleKeyFrame.EasingFunction>\r\n                    </EasingDoubleKeyFrame>\r\n                </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"0\" To=\"1\" Duration=\"0:0:0.350\" >\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>") as Storyboard;
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.grid.put_RenderTransform((Transform) new TranslateTransform());
          break;
        case DialogService.AnimationTypes.Fade:
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.storyboard = XamlReader.Load("<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation \r\n\t\t\t\tDuration=\"0:0:0.2\" \r\n\t\t\t\tStoryboard.TargetProperty=\"(UIElement.Opacity)\" \r\n                To=\"1\"/>\r\n        </Storyboard>") as Storyboard;
          break;
        default:
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.storyboard = XamlReader.Load("<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation \r\n\t\t\t\tTo=\".5\"\r\n                Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.CenterOfRotationY)\" />\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.RotationX)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"-30\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.35\" Value=\"0\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseOut\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Opacity)\">\r\n                <DiscreteDoubleKeyFrame KeyTime=\"0\" Value=\"1\" />\r\n            </DoubleAnimationUsingKeyFrames>\r\n        </Storyboard>") as Storyboard;
          // ISSUE: reference to a compiler-generated field
          cDisplayClass820.grid.put_Projection((Projection) new PlaneProjection());
          break;
      }
      // ISSUE: reference to a compiler-generated field
      if (cDisplayClass820.storyboard == null)
        return;
      // ISSUE: reference to a compiler-generated field
      foreach (Timeline child in (IEnumerable<Timeline>) cDisplayClass820.storyboard.Children)
      {
        if (child is DoubleAnimationUsingKeyFrames)
        {
          foreach (DoubleKeyFrame keyFrame in (IEnumerable<DoubleKeyFrame>) (child as DoubleAnimationUsingKeyFrames).KeyFrames)
            keyFrame.put_KeyTime(KeyTime.FromTimeSpan(keyFrame.KeyTime.TimeSpan.Add(delay)));
        }
      }
      // ISSUE: method pointer
      await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) cDisplayClass820, __methodptr(\u003CRunShowStoryboard\u003Eb__0)));
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => this.Hide();

    public void Hide()
    {
      if (!this.IsOpen)
        return;
      if (this.Page != null)
      {
        WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<BackPressedEventArgs>>(new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.OnBackKeyPress));
        WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>(this.RootFrame.remove_Navigated), new NavigatedEventHandler(this.OnNavigated));
        this._page = (Page) null;
      }
      this.RunHideStoryboard(this._overlay, DialogService.AnimationTypes.Fade);
      this.RunHideStoryboard(this._childPanel, this.AnimationType);
    }

    private void RunHideStoryboard(Grid grid, DialogService.AnimationTypes animation)
    {
      if (grid == null)
        return;
      Storyboard storyboard1;
      switch (animation)
      {
        case DialogService.AnimationTypes.Slide:
          storyboard1 = XamlReader.Load("\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.Y)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"0\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.25\" Value=\"150\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"1\" To=\"0\" Duration=\"0:0:0.25\">\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>") as Storyboard;
          break;
        case DialogService.AnimationTypes.SlideHorizontal:
          storyboard1 = XamlReader.Load("\r\n        <Storyboard  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.RenderTransform).(TranslateTransform.X)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"0\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.25\" Value=\"150\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimation Storyboard.TargetProperty=\"(UIElement.Opacity)\" From=\"1\" To=\"0\" Duration=\"0:0:0.25\">\r\n                <DoubleAnimation.EasingFunction>\r\n                    <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                </DoubleAnimation.EasingFunction>\r\n            </DoubleAnimation>\r\n        </Storyboard>") as Storyboard;
          break;
        case DialogService.AnimationTypes.Fade:
          storyboard1 = XamlReader.Load("<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation \r\n\t\t\t\tDuration=\"0:0:0.2\"\r\n\t\t\t\tStoryboard.TargetProperty=\"(UIElement.Opacity)\" \r\n                To=\"0\"/>\r\n        </Storyboard>") as Storyboard;
          break;
        default:
          storyboard1 = XamlReader.Load("<Storyboard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n            <DoubleAnimation BeginTime=\"0:0:0\" Duration=\"0\" \r\n                                Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.CenterOfRotationY)\" \r\n                                To=\".5\"/>\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Projection).(PlaneProjection.RotationX)\">\r\n                <EasingDoubleKeyFrame KeyTime=\"0\" Value=\"0\"/>\r\n                <EasingDoubleKeyFrame KeyTime=\"0:0:0.25\" Value=\"45\">\r\n                    <EasingDoubleKeyFrame.EasingFunction>\r\n                        <ExponentialEase EasingMode=\"EaseIn\" Exponent=\"6\"/>\r\n                    </EasingDoubleKeyFrame.EasingFunction>\r\n                </EasingDoubleKeyFrame>\r\n            </DoubleAnimationUsingKeyFrames>\r\n            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty=\"(UIElement.Opacity)\">\r\n                <DiscreteDoubleKeyFrame KeyTime=\"0\" Value=\"1\" />\r\n                <DiscreteDoubleKeyFrame KeyTime=\"0:0:0.267\" Value=\"0\" />\r\n            </DoubleAnimationUsingKeyFrames>\r\n        </Storyboard>") as Storyboard;
          break;
      }
      try
      {
        if (storyboard1 == null)
          return;
        Storyboard storyboard2 = storyboard1;
        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(((Timeline) storyboard2).add_Completed), new Action<EventRegistrationToken>(((Timeline) storyboard2).remove_Completed), new EventHandler<object>(this.HideStoryboardCompleted));
        foreach (Timeline child in (IEnumerable<Timeline>) storyboard1.Children)
          Storyboard.SetTarget(child, (DependencyObject) grid);
        storyboard1.Begin();
      }
      catch (Exception ex)
      {
        this.HideStoryboardCompleted((object) null, (object) null);
      }
    }

    private void HideStoryboardCompleted(object sender, object e)
    {
      this.IsOpen = false;
      try
      {
        if (this.PopupContainer != null && this.PopupContainer.Children != null)
        {
          if (this._overlay != null)
            ((ICollection<UIElement>) this.PopupContainer.Children).Remove((UIElement) this._overlay);
          ((ICollection<UIElement>) this.PopupContainer.Children).Remove((UIElement) this._childPanel);
        }
        ((ICollection<UIElement>) ((Panel) this._childPanel).Children).Clear();
      }
      catch
      {
      }
      try
      {
        if (this.Closed == null)
          return;
        this.Closed((object) this, (EventArgs) null);
      }
      catch
      {
      }
    }

    public void OnBackKeyPress(object sender, BackPressedEventArgs e)
    {
      if (this.HasPopup)
      {
        e.put_Handled(true);
      }
      else
      {
        if (!this.IsOpen)
          return;
        e.put_Handled(true);
        this.BackButtonPressed = true;
        this.Hide();
      }
    }

    public enum AnimationTypes
    {
      Slide,
      SlideHorizontal,
      Swivel,
      SwivelHorizontal,
      Fade,
    }
  }
}

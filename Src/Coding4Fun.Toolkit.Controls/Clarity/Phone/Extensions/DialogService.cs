﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;


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
        return _page ?? (_page = RootFrame?.Content as Page);
      }
    }

    internal Frame RootFrame => _rootFrame ?? (_rootFrame = ApplicationSpace.RootFrame);

    internal Panel PopupContainer
    {
      get
      {
        if (_popupContainer == null)
        {
          // Find the main content panel in the current window
          if (RootFrame?.Content is Page page)
          {
            _popupContainer = FindVisualChild<Panel>(page) ?? page.Content as Panel;
          }
        }
        return _popupContainer;
      }
    }

    private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
      {
        var child = VisualTreeHelper.GetChild(parent, i);
        if (child is T result)
          return result;
        
        var childOfChild = FindVisualChild<T>(child);
        if (childOfChild != null)
          return childOfChild;
      }
      return null;
    }

    public DialogService()
    {
      AnimationType = AnimationTypes.Slide;
      BackButtonPressed = false;
    }

    private void InitializePopup()
    {
      _childPanel = CreateGrid();
      if (IsOverlayApplied)
      {
        _overlay = CreateGrid();
      }
      ApplyOverlayBackground();
      if (PopupContainer != null)
      {
        if (_overlay != null)
          PopupContainer.Children.Add(_overlay);
        PopupContainer.Children.Add(_childPanel);
        _childPanel.Children.Add(Child);
      }
      else
      {
        _deferredShowToLoaded = true;
        RootFrame.Loaded += RootFrameDeferredShowLoaded;
      }
    }

    internal void ApplyOverlayBackground()
    {
      if (!IsOverlayApplied || BackgroundBrush == null || _overlay == null)
        return;
      _overlay.Background = BackgroundBrush;
    }

    private Grid CreateGrid()
    {
      var grid = new Grid
      {
        Name = Guid.NewGuid().ToString()
      };
      Grid.SetColumnSpan(grid, int.MaxValue);
      Grid.SetRowSpan(grid, int.MaxValue);
      grid.Opacity = 0.0;
      CalculateVerticalOffset(grid);
      return grid;
    }

    internal void CalculateVerticalOffset()
    {
      CalculateVerticalOffset(_childPanel);
    }

    internal void CalculateVerticalOffset(Panel panel)
    {
      if (panel == null)
        return;
      panel.Margin = new Thickness(0.0, VerticalOffset + ControlVerticalOffset, 0.0, 0.0);
    }

    private void RootFrameDeferredShowLoaded(object sender, RoutedEventArgs e)
    {
      RootFrame.Loaded -= RootFrameDeferredShowLoaded;
      _deferredShowToLoaded = false;
      Show();
    }

    protected internal void SetAlignmentsOnOverlay(
      HorizontalAlignment horizontalAlignment,
      VerticalAlignment verticalAlignment)
    {
      if (_childPanel == null)
        return;
      _childPanel.HorizontalAlignment = horizontalAlignment;
      _childPanel.VerticalAlignment = verticalAlignment;
    }

    public void Show()
    {
      lock (Lockobj)
      {
        // UWP doesn't use HardwareButtons.BackPressed like Windows Phone
        // Back button handling should be done through SystemNavigationManager in UWP
        IsOpen = true;
        InitializePopup();
        if (_deferredShowToLoaded)
          return;
          
        Frame rootFrame = RootFrame;
        rootFrame.Navigated += OnNavigated;
        RunShowStoryboard(_overlay, AnimationTypes.Fade);
        RunShowStoryboard(_childPanel, AnimationType, MainBodyDelay);
        Opened?.Invoke(this, EventArgs.Empty);
      }
    }

    private void RunShowStoryboard(UIElement grid, AnimationTypes animation)
    {
      RunShowStoryboard(grid, animation, TimeSpan.MinValue);
    }

    private async void RunShowStoryboard(
      UIElement grid,
      AnimationTypes animation,
      TimeSpan delay)
    {
      if (grid == null)
        return;
        
      await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
      {
        // Simple fade-in animation for UWP
        var storyboard = new Storyboard();
        var fadeAnimation = new DoubleAnimation
        {
          From = 0,
          To = 1,
          Duration = new Duration(TimeSpan.FromMilliseconds(300))
        };
        
        Storyboard.SetTarget(fadeAnimation, grid);
        Storyboard.SetTargetProperty(fadeAnimation, "Opacity");
        storyboard.Children.Add(fadeAnimation);
        storyboard.Begin();
      });
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => Hide();

    public void Hide()
    {
      if (!IsOpen)
        return;
      if (Page != null)
      {
        // Remove UWP navigation event handler
        RootFrame.Navigated -= OnNavigated;
        _page = null;
      }
      RunHideStoryboard(_overlay, AnimationTypes.Fade);
      RunHideStoryboard(_childPanel, AnimationType);
    }

    private void RunHideStoryboard(Grid grid, AnimationTypes animation)
    {
      if (grid == null)
        return;
        
      // Simple fade-out animation for UWP
      var storyboard = new Storyboard();
      var fadeAnimation = new DoubleAnimation
      {
        From = 1,
        To = 0,
        Duration = new Duration(TimeSpan.FromMilliseconds(200))
      };
      
      Storyboard.SetTarget(fadeAnimation, grid);
      Storyboard.SetTargetProperty(fadeAnimation, "Opacity");
      storyboard.Children.Add(fadeAnimation);
      storyboard.Completed += HideStoryboardCompleted;
      storyboard.Begin();
    }

    private void HideStoryboardCompleted(object sender, object e)
    {
      IsOpen = false;
      try
      {
        if (PopupContainer != null && PopupContainer.Children != null)
        {
          if (_overlay != null)
            PopupContainer.Children.Remove(_overlay);
          PopupContainer.Children.Remove(_childPanel);
        }
        _childPanel?.Children.Clear();
      }
      catch
      {
      }
      try
      {
        Closed?.Invoke(this, EventArgs.Empty);
      }
      catch
      {
      }
    }

    // UWP back navigation handling - this would need to be connected to SystemNavigationManager
    // if back button handling is required in UWP
    public void OnBackKeyPress()
    {
      if (HasPopup)
      {
        // Handle popup back navigation
      }
      else
      {
        if (!IsOpen)
          return;
        BackButtonPressed = true;
        Hide();
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

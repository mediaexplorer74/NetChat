// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ToastPrompt
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Clarity.Phone.Extensions;
using Coding4Fun.Toolkit.Controls.Binding;
using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls
{
  public class ToastPrompt : PopUp<string, PopUpResult>, IDisposable, IImageSourceFull, IImageSource
  {
    protected Image ToastImage;
    private const string ToastImageName = "ToastImage";
    private DispatcherTimer _timer;
    private TranslateTransform _translate;
    public static readonly DependencyProperty MillisecondsUntilHiddenProperty = DependencyProperty.Register(nameof (MillisecondsUntilHidden), typeof (int), typeof (ToastPrompt), new PropertyMetadata((object) 4000));
    public static readonly DependencyProperty IsTimerEnabledProperty = DependencyProperty.Register(nameof (IsTimerEnabled), typeof (bool), typeof (ToastPrompt), new PropertyMetadata((object) true));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (ToastPrompt), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof (Message), typeof (string), typeof (ToastPrompt), new PropertyMetadata((object) ""));
    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof (ImageSource), typeof (ImageSource), typeof (ToastPrompt), new PropertyMetadata((object) null, new PropertyChangedCallback(ToastPrompt.OnImageSource)));
    public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(nameof (Stretch), typeof (Stretch), typeof (ToastPrompt), new PropertyMetadata((object) Stretch.None));
    public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register(nameof (ImageWidth), typeof (double), typeof (ToastPrompt), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register(nameof (ImageHeight), typeof (double), typeof (ToastPrompt), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty TextOrientationProperty = DependencyProperty.Register(nameof (TextOrientation), typeof (Orientation), typeof (ToastPrompt), new PropertyMetadata((object) Orientation.Vertical));
    public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(nameof (TextWrapping), typeof (TextWrapping), typeof (ToastPrompt), new PropertyMetadata((object) TextWrapping.Wrap, new PropertyChangedCallback(ToastPrompt.OnTextWrapping)));

    public ToastPrompt()
    {
      this.DefaultStyleKey = typeof (ToastPrompt);
      this.IsAppBarVisible = true;
      this.IsBackKeyOverride = true;
      this.IsCalculateFrameVerticalOffset = true;
      this.IsOverlayApplied = false;
      ((UIElement)this).ManipulationMode = ManipulationModes.TranslateX;
      this.AnimationType = DialogService.AnimationTypes.SlideHorizontal;
      ((UIElement)this).ManipulationStarted += this.ToastPromptManipulationStarted;
      ((UIElement)this).ManipulationDelta += this.ToastPromptManipulationDelta;
      ((UIElement)this).ManipulationCompleted += this.ToastPromptManipulationCompleted;
      this.Opened += new EventHandler(this.ToastPromptOpened);
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.SetRenderTransform();
      this.ToastImage = this.GetTemplateChild("ToastImage") as Image;
      if (this.ToastImage != null && this.ImageSource != null)
      {
        this.ToastImage.Source = this.ImageSource;
        this.SetImageVisibility(this.ImageSource);
      }
      this.SetTextOrientation(this.TextWrapping);
    }

    public override void Show()
    {
      if (!this.IsTimerEnabled)
        return;
      base.Show();
      this.SetRenderTransform();
      PreventScrollBinding.SetIsEnabled((DependencyObject) this, true);
    }

    public void Dispose()
    {
      if (this._timer == null)
        return;
      this._timer.Stop();
      this._timer = null;
    }

    private void ToastPromptManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
      this.PauseTimer();
    }

    private void ToastPromptManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
      TranslateTransform translate = this._translate;
      translate.X += e.Delta.Translation.X;
      if (this._translate.X >= 0.0)
        return;
      ((TranslateTransform)this._translate).X = 0.0;
    }

    private void ToastPromptManipulationCompleted(
      object sender,
      ManipulationCompletedRoutedEventArgs e)
    {
      if (e.Cumulative.Translation.X > 200.0 || e.Velocities.Linear.X > 1000.0)
        this.OnCompleted(new PopUpEventArgs<string, PopUpResult>()
        {
          PopUpResult = PopUpResult.UserDismissed
        });
      else if (e.Cumulative.Translation.X < 20.0)
      {
        this.OnCompleted(new PopUpEventArgs<string, PopUpResult>()
        {
          PopUpResult = PopUpResult.Ok
        });
      }
      else
      {
        ((TranslateTransform)this._translate).X = 0.0;
        this.StartTimer();
      }
    }

    private void ToastPromptOpened(object sender, EventArgs e) => this.StartTimer();

    private void TimerTick(object sender, object e)
    {
      this.OnCompleted(new PopUpEventArgs<string, PopUpResult>()
      {
        PopUpResult = PopUpResult.NoResponse
      });
    }

    public override void OnCompleted(PopUpEventArgs<string, PopUpResult> result)
    {
      PreventScrollBinding.SetIsEnabled((DependencyObject) this, false);
      this.PauseTimer();
      this.Dispose();
      base.OnCompleted(result);
    }

    private void SetImageVisibility(ImageSource source)
    {
      ((UIElement)this.ToastImage).Visibility = source == null ? Visibility.Collapsed : Visibility.Visible;
    }

    private void SetTextOrientation(TextWrapping value)
    {
      if (value == TextWrapping.NoWrap)
        return;
      this.TextOrientation = Orientation.Horizontal;
    }

    private void StartTimer()
    {
      if (this._timer == null)
      {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        ((DispatcherTimer)dispatcherTimer).Interval = TimeSpan.FromMilliseconds((double) this.MillisecondsUntilHidden);
        this._timer = dispatcherTimer;
        ((DispatcherTimer)this._timer).Tick += new EventHandler<object>(this.TimerTick);
      }
      this._timer.Start();
    }

    private void PauseTimer()
    {
      if (this._timer == null)
        return;
      this._timer.Stop();
    }

    private void SetRenderTransform()
    {
      this._translate = new TranslateTransform();
      ((UIElement)this).RenderTransform = this._translate;
    }

    private static void OnTextWrapping(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      if (!(o is ToastPrompt toastPrompt) || toastPrompt.ToastImage == null)
        return;
      toastPrompt.SetTextOrientation((TextWrapping) e.NewValue);
    }

    private static void OnImageSource(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      if (!(o is ToastPrompt toastPrompt) || toastPrompt.ToastImage == null)
        return;
      toastPrompt.SetImageVisibility(e.NewValue as ImageSource);
    }

    public int MillisecondsUntilHidden
    {
      get => (int) this.GetValue(ToastPrompt.MillisecondsUntilHiddenProperty);
      set
      {
        this.SetValue(ToastPrompt.MillisecondsUntilHiddenProperty, value);
      }
    }

    public bool IsTimerEnabled
    {
      get => (bool) this.GetValue(ToastPrompt.IsTimerEnabledProperty);
      set => this.SetValue(ToastPrompt.IsTimerEnabledProperty, value);
    }

    public string Title
    {
      get => (string) this.GetValue(ToastPrompt.TitleProperty);
      set => this.SetValue(ToastPrompt.TitleProperty, value);
    }

    public string Message
    {
      get => (string) this.GetValue(ToastPrompt.MessageProperty);
      set => this.SetValue(ToastPrompt.MessageProperty, value);
    }

    public ImageSource ImageSource
    {
      get => (ImageSource) this.GetValue(ToastPrompt.ImageSourceProperty);
      set => this.SetValue(ToastPrompt.ImageSourceProperty, value);
    }

    public Stretch Stretch
    {
      get => (Stretch) this.GetValue(ToastPrompt.StretchProperty);
      set => this.SetValue(ToastPrompt.StretchProperty, value);
    }

    public double ImageWidth
    {
      get => (double) this.GetValue(ToastPrompt.ImageWidthProperty);
      set => this.SetValue(ToastPrompt.ImageWidthProperty, value);
    }

    public double ImageHeight
    {
      get => (double) this.GetValue(ToastPrompt.ImageHeightProperty);
      set => this.SetValue(ToastPrompt.ImageHeightProperty, value);
    }

    public Orientation TextOrientation
    {
      get => (Orientation) this.GetValue(ToastPrompt.TextOrientationProperty);
      set
      {
        this.SetValue(ToastPrompt.TextOrientationProperty, value);
      }
    }

    public TextWrapping TextWrapping
    {
      get => (TextWrapping) this.GetValue(ToastPrompt.TextWrappingProperty);
      set => this.SetValue(ToastPrompt.TextWrappingProperty, value);
    }
  }
}

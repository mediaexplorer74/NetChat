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

#nullable disable
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
    public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(nameof (Stretch), typeof (Stretch), typeof (ToastPrompt), new PropertyMetadata((object) (Stretch) 0));
    public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register(nameof (ImageWidth), typeof (double), typeof (ToastPrompt), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register(nameof (ImageHeight), typeof (double), typeof (ToastPrompt), new PropertyMetadata((object) double.NaN));
    public static readonly DependencyProperty TextOrientationProperty = DependencyProperty.Register(nameof (TextOrientation), typeof (Orientation), typeof (ToastPrompt), new PropertyMetadata((object) (Orientation) 1));
    public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(nameof (TextWrapping), typeof (TextWrapping), typeof (ToastPrompt), new PropertyMetadata((object) (TextWrapping) 1, new PropertyChangedCallback(ToastPrompt.OnTextWrapping)));

    public ToastPrompt()
    {
      this.put_DefaultStyleKey((object) typeof (ToastPrompt));
      this.IsAppBarVisible = true;
      this.IsBackKeyOverride = true;
      this.IsCalculateFrameVerticalOffset = true;
      this.IsOverlayApplied = false;
      ((UIElement) this).put_ManipulationMode((ManipulationModes) 1);
      this.AnimationType = DialogService.AnimationTypes.SlideHorizontal;
      WindowsRuntimeMarshal.AddEventHandler<ManipulationStartedEventHandler>(new Func<ManipulationStartedEventHandler, EventRegistrationToken>(((UIElement) this).add_ManipulationStarted), new Action<EventRegistrationToken>(((UIElement) this).remove_ManipulationStarted), new ManipulationStartedEventHandler(this.ToastPromptManipulationStarted));
      WindowsRuntimeMarshal.AddEventHandler<ManipulationDeltaEventHandler>(new Func<ManipulationDeltaEventHandler, EventRegistrationToken>(((UIElement) this).add_ManipulationDelta), new Action<EventRegistrationToken>(((UIElement) this).remove_ManipulationDelta), new ManipulationDeltaEventHandler(this.ToastPromptManipulationDelta));
      WindowsRuntimeMarshal.AddEventHandler<ManipulationCompletedEventHandler>(new Func<ManipulationCompletedEventHandler, EventRegistrationToken>(((UIElement) this).add_ManipulationCompleted), new Action<EventRegistrationToken>(((UIElement) this).remove_ManipulationCompleted), new ManipulationCompletedEventHandler(this.ToastPromptManipulationCompleted));
      this.Opened += new EventHandler(this.ToastPromptOpened);
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.SetRenderTransform();
      this.ToastImage = this.GetTemplateChild("ToastImage") as Image;
      if (this.ToastImage != null && this.ImageSource != null)
      {
        this.ToastImage.put_Source(this.ImageSource);
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
      this._timer = (DispatcherTimer) null;
    }

    private void ToastPromptManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
      this.PauseTimer();
    }

    private void ToastPromptManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
      TranslateTransform translate = this._translate;
      translate.put_X(translate.X + e.Delta.Translation.X);
      if (this._translate.X >= 0.0)
        return;
      this._translate.put_X(0.0);
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
        this._translate.put_X(0.0);
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
      ((UIElement) this.ToastImage).put_Visibility(source == null ? (Visibility) 1 : (Visibility) 0);
    }

    private void SetTextOrientation(TextWrapping value)
    {
      if (value != 2)
        return;
      this.TextOrientation = (Orientation) 0;
    }

    private void StartTimer()
    {
      if (this._timer == null)
      {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.put_Interval(TimeSpan.FromMilliseconds((double) this.MillisecondsUntilHidden));
        this._timer = dispatcherTimer;
        DispatcherTimer timer = this._timer;
        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(timer.add_Tick), new Action<EventRegistrationToken>(timer.remove_Tick), new EventHandler<object>(this.TimerTick));
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
      ((UIElement) this).put_RenderTransform((Transform) this._translate);
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
      get => (int) ((DependencyObject) this).GetValue(ToastPrompt.MillisecondsUntilHiddenProperty);
      set
      {
        ((DependencyObject) this).SetValue(ToastPrompt.MillisecondsUntilHiddenProperty, (object) value);
      }
    }

    public bool IsTimerEnabled
    {
      get => (bool) ((DependencyObject) this).GetValue(ToastPrompt.IsTimerEnabledProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.IsTimerEnabledProperty, (object) value);
    }

    public string Title
    {
      get => (string) ((DependencyObject) this).GetValue(ToastPrompt.TitleProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.TitleProperty, (object) value);
    }

    public string Message
    {
      get => (string) ((DependencyObject) this).GetValue(ToastPrompt.MessageProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.MessageProperty, (object) value);
    }

    public ImageSource ImageSource
    {
      get => (ImageSource) ((DependencyObject) this).GetValue(ToastPrompt.ImageSourceProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.ImageSourceProperty, (object) value);
    }

    public Stretch Stretch
    {
      get => (Stretch) ((DependencyObject) this).GetValue(ToastPrompt.StretchProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.StretchProperty, (object) value);
    }

    public double ImageWidth
    {
      get => (double) ((DependencyObject) this).GetValue(ToastPrompt.ImageWidthProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.ImageWidthProperty, (object) value);
    }

    public double ImageHeight
    {
      get => (double) ((DependencyObject) this).GetValue(ToastPrompt.ImageHeightProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.ImageHeightProperty, (object) value);
    }

    public Orientation TextOrientation
    {
      get => (Orientation) ((DependencyObject) this).GetValue(ToastPrompt.TextOrientationProperty);
      set
      {
        ((DependencyObject) this).SetValue(ToastPrompt.TextOrientationProperty, (object) value);
      }
    }

    public TextWrapping TextWrapping
    {
      get => (TextWrapping) ((DependencyObject) this).GetValue(ToastPrompt.TextWrappingProperty);
      set => ((DependencyObject) this).SetValue(ToastPrompt.TextWrappingProperty, (object) value);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ImageTile
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class ImageTile : ButtonBase, IDisposable
  {
    private DispatcherTimer _changeImageTimer;
    private static readonly Random RandomIndexer = new Random();
    private readonly Dictionary<int, Uri> _imageCurrentLocation = new Dictionary<int, Uri>();
    private readonly List<Uri> _imagesBeingShown = new List<Uri>();
    private readonly List<int> _availableSpotsOnGrid = new List<int>();
    private readonly List<ImageTileState> _animationTracking = new List<ImageTileState>();
    private int _largeImageIndex = -1;
    private bool _createAnimation = true;
    private bool _isLoaded;
    private ImageTileLayoutStates _imageTileLayoutState;
    private Grid _imageContainer;
    public static readonly DependencyProperty ColumnProperty = DependencyProperty.Register(nameof (Columns), typeof (int), typeof (ImageTile), new PropertyMetadata((object) 3, new PropertyChangedCallback(ImageTile.OnGridSizeChanged)));
    public static readonly DependencyProperty RowsProperty = DependencyProperty.Register(nameof (Rows), typeof (int), typeof (ImageTile), new PropertyMetadata((object) 3, new PropertyChangedCallback(ImageTile.OnGridSizeChanged)));
    public static readonly DependencyProperty LargeTileColumnsProperty = DependencyProperty.Register(nameof (LargeTileColumns), typeof (int), typeof (ImageTile), new PropertyMetadata((object) 2, new PropertyChangedCallback(ImageTile.OnLargeTileChanged)));
    public static readonly DependencyProperty LargeTileRowsProperty = DependencyProperty.Register(nameof (LargeTileRows), typeof (int), typeof (ImageTile), new PropertyMetadata((object) 2, new PropertyChangedCallback(ImageTile.OnLargeTileChanged)));
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof (ItemsSource), typeof (List<Uri>), typeof (ImageTile), new PropertyMetadata((object) null));
    public static readonly DependencyProperty AnimationTypesProperty = DependencyProperty.Register(nameof (AnimationType), typeof (ImageTileAnimationTypes), typeof (ImageTile), new PropertyMetadata((object) ImageTileAnimationTypes.Fade));
    public static readonly DependencyProperty IsFrozenProperty = DependencyProperty.Register(nameof (IsFrozen), typeof (bool), typeof (ImageTile), new PropertyMetadata((object) false, new PropertyChangedCallback(ImageTile.OnIsFrozenPropertyChanged)));
    public static readonly DependencyProperty AnimationDurationProperty = DependencyProperty.Register(nameof (AnimationDuration), typeof (int), typeof (ImageTile), new PropertyMetadata((object) 500));
    public static readonly DependencyProperty ImageCycleIntervalProperty = DependencyProperty.Register(nameof (ImageCycleInterval), typeof (int), typeof (ImageTile), new PropertyMetadata((object) 1000, new PropertyChangedCallback(ImageTile.OnImageCycleIntervalPropertyChanged)));

    public event EventHandler<ExceptionRoutedEventArgs> ImageFailed;

    public ImageTile()
    {
      ((Control) this).put_DefaultStyleKey((object) typeof (ImageTile));
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Loaded), new RoutedEventHandler(this.ImageTileLoaded));
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) this).add_Unloaded), new Action<EventRegistrationToken>(((FrameworkElement) this).remove_Unloaded), new RoutedEventHandler(this.ImageTileUnloaded));
    }

    private void ImageTileUnloaded(object sender, RoutedEventArgs e) => this.Dispose();

    private void FrameNavigated(object sender, NavigationEventArgs e) => this.Dispose();

    public void Dispose()
    {
      this._isLoaded = false;
      if (this._changeImageTimer != null)
      {
        this._changeImageTimer.Stop();
        WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(this._changeImageTimer.remove_Tick), new EventHandler<object>(this.ChangeImageTimerTick));
        this._changeImageTimer = (DispatcherTimer) null;
      }
      if (this._imageContainer != null)
        ((ICollection<UIElement>) ((Panel) this._imageContainer).Children).Clear();
      foreach (ImageTileState imageTileState in this._animationTracking)
        imageTileState.Storyboard.Stop();
      Frame rootFrame = ApplicationSpace.RootFrame;
      if (rootFrame == null)
        return;
      WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>(rootFrame.remove_Navigated), new NavigatedEventHandler(this.FrameNavigated));
    }

    private void ImageTileLoaded(object sender, RoutedEventArgs e)
    {
      this._isLoaded = true;
      if (ApplicationSpace.IsDesignMode)
        return;
      Frame rootFrame = ApplicationSpace.RootFrame;
      if (rootFrame == null)
        return;
      WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>(rootFrame.remove_Navigated), new NavigatedEventHandler(this.FrameNavigated));
      Frame frame = rootFrame;
      WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(frame.add_Navigated), new Action<EventRegistrationToken>(frame.remove_Navigated), new NavigatedEventHandler(this.FrameNavigated));
      this.FinishLoadAndTemplateApply();
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this._imageContainer = (Grid) ((Control) this).GetTemplateChild("ImageContainer");
      this.FinishLoadAndTemplateApply();
    }

    private void FinishLoadAndTemplateApply()
    {
      if (!this._isLoaded)
        return;
      if (this._changeImageTimer == null)
        this._changeImageTimer = new DispatcherTimer();
      WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(this._changeImageTimer.remove_Tick), new EventHandler<object>(this.ChangeImageTimerTick));
      DispatcherTimer changeImageTimer = this._changeImageTimer;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(changeImageTimer.add_Tick), new Action<EventRegistrationToken>(changeImageTimer.remove_Tick), new EventHandler<object>(this.ChangeImageTimerTick));
      this.GridSizeChanged();
      this.ResetGridStateManagement();
      this._createAnimation = false;
      if (!ApplicationSpace.IsDesignMode)
      {
        for (int row = 0; row < this.Rows; ++row)
        {
          for (int col = 0; col < this.Columns; ++col)
            this.CycleImage(row, col);
        }
      }
      this._createAnimation = true;
      this.ImageCycleIntervalChanged();
      this.IsFrozenPropertyChanged();
    }

    private int CalculateIndex(int row, int col) => row * this.Columns + col;

    private void ChangeImageTimerTick(object sender, object e)
    {
      if (!this._isLoaded)
        return;
      this.CycleImage();
    }

    public void CycleImage(int row = -1, int col = -1)
    {
      if (this._imageContainer == null || this.ItemsSource == null)
        return;
      if (this.ItemsSource.Count <= 0)
        return;
      try
      {
        int index;
        bool isLargeImage;
        this.CalculateNextValidItem(out index, ref row, ref col, out isLargeImage);
        Image imageControl = this.CreateImageControl(row, col, isLargeImage);
        ((ICollection<UIElement>) ((Panel) this._imageContainer).Children).Add((UIElement) imageControl);
        this.SetImageSource(imageControl, index, (int) ((FrameworkElement) this).ActualWidth);
        if (!this._createAnimation || this.AnimationType == ImageTileAnimationTypes.None)
          return;
        Storyboard sb = new Storyboard();
        this.TrackAnimationForImageRemoval(row, col, sb, isLargeImage);
        switch (this.AnimationType)
        {
          case ImageTileAnimationTypes.Fade:
            ControlHelper.CreateDoubleAnimations(sb, (DependencyObject) imageControl, "Opacity", toValue: 1.0, speed: this.AnimationDuration);
            break;
          case ImageTileAnimationTypes.HorizontalExpand:
            ((UIElement) imageControl).put_Projection((Projection) new PlaneProjection());
            ControlHelper.CreateDoubleAnimations(sb, (DependencyObject) ((UIElement) imageControl).Projection, "RotationY", 270.0, 360.0, this.AnimationDuration);
            break;
          case ImageTileAnimationTypes.VerticalExpand:
            ((UIElement) imageControl).put_Projection((Projection) new PlaneProjection());
            ControlHelper.CreateDoubleAnimations(sb, (DependencyObject) ((UIElement) imageControl).Projection, "RotationX", 270.0, 360.0, this.AnimationDuration);
            break;
        }
        Storyboard storyboard = sb;
        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(((Timeline) storyboard).add_Completed), new Action<EventRegistrationToken>(((Timeline) storyboard).remove_Completed), new EventHandler<object>(this.AnimationCompleted));
        sb.Begin();
      }
      catch
      {
      }
    }

    private void CalculateNextValidItem(
      out int index,
      ref int row,
      ref int col,
      out bool isLargeImage)
    {
      isLargeImage = false;
      if (row == -1 && col == -1)
      {
        if (this._availableSpotsOnGrid.Count == 0)
        {
          this.ResetGridStateManagement();
          isLargeImage = this._imageTileLayoutState == ImageTileLayoutStates.BigImage;
        }
        List<int> list = this._availableSpotsOnGrid.Where<int>(new Func<int, bool>(this.IsValidLargeTilePosition)).ToList<int>();
        List<int> intList = isLargeImage ? list : this._availableSpotsOnGrid;
        int index1 = ImageTile.RandomIndexer.Next(0, intList.Count);
        index = intList[index1];
        this.GetRowAndColumnForIndex(index, out row, out col);
      }
      else
        index = this.CalculateIndex(row, col);
      if (isLargeImage)
      {
        this._largeImageIndex = index;
        for (int index2 = 0; index2 < this.LargeTileRows; ++index2)
        {
          for (int index3 = 0; index3 < this.LargeTileColumns; ++index3)
            this._availableSpotsOnGrid.Remove(this.CalculateIndex(row + index2, col + index3));
        }
      }
      else
        this._availableSpotsOnGrid.Remove(index);
    }

    private bool IsValidLargeTilePosition(int index)
    {
      int row;
      int column;
      this.GetRowAndColumnForIndex(index, out row, out column);
      return column <= this.Columns - this.LargeTileColumns && row <= this.Rows - this.LargeTileRows;
    }

    private void ResetGridStateManagement()
    {
      if (this._availableSpotsOnGrid.Count != 0)
        return;
      bool isEnabled = this._changeImageTimer.IsEnabled;
      this._changeImageTimer.Stop();
      this.AlterCycleState();
      if (this._imageTileLayoutState == ImageTileLayoutStates.ForceOverwriteOfBigImage)
      {
        this._availableSpotsOnGrid.Add(this._largeImageIndex);
      }
      else
      {
        int num = this.Rows * this.Columns;
        for (int index = 0; index < num; ++index)
          this._availableSpotsOnGrid.Add(index);
        if (num > 1 && this._imageTileLayoutState == ImageTileLayoutStates.AllButBigImage)
          this._availableSpotsOnGrid.Remove(this._largeImageIndex);
      }
      if (!isEnabled)
        return;
      this._changeImageTimer.Start();
    }

    private void AlterCycleState()
    {
      switch (this._imageTileLayoutState)
      {
        case ImageTileLayoutStates.AllImages:
          this._imageTileLayoutState = ImageTileLayoutStates.BigImage;
          break;
        case ImageTileLayoutStates.BigImage:
          this._imageTileLayoutState = ImageTileLayoutStates.AllButBigImage;
          break;
        case ImageTileLayoutStates.AllButBigImage:
          this._imageTileLayoutState = ImageTileLayoutStates.ForceOverwriteOfBigImage;
          break;
        default:
          this._imageTileLayoutState = ImageTileLayoutStates.AllImages;
          break;
      }
    }

    private Image CreateImageControl(int row, int col, bool isLargeImage)
    {
      Image image = new Image();
      ((FrameworkElement) image).put_HorizontalAlignment((HorizontalAlignment) 1);
      ((FrameworkElement) image).put_VerticalAlignment((VerticalAlignment) 1);
      image.put_Stretch((Stretch) 3);
      ((FrameworkElement) image).put_Name(Guid.NewGuid().ToString());
      ((UIElement) image).put_UseLayoutRounding(false);
      Image imageControl = image;
      ((DependencyObject) imageControl).SetValue(Grid.ColumnProperty, (object) col);
      ((DependencyObject) imageControl).SetValue(Grid.RowProperty, (object) row);
      if (isLargeImage)
      {
        ((DependencyObject) imageControl).SetValue(Grid.ColumnSpanProperty, (object) this.LargeTileColumns);
        ((DependencyObject) imageControl).SetValue(Grid.RowSpanProperty, (object) this.LargeTileRows);
      }
      return imageControl;
    }

    private void SetImageSource(Image img, int index, int imgWidth)
    {
      Uri randomImageUri = this.GetRandomImageUri(index);
      img.put_Source((ImageSource) this.GetImage(randomImageUri, imgWidth));
    }

    private BitmapImage GetImage(Uri file, int imgWidth)
    {
      BitmapImage image = new BitmapImage(file);
      image.put_DecodePixelWidth(imgWidth);
      BitmapImage bitmapImage1 = image;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(bitmapImage1.add_ImageOpened), new Action<EventRegistrationToken>(bitmapImage1.remove_ImageOpened), new RoutedEventHandler(this.ImageOpened));
      BitmapImage bitmapImage2 = image;
      WindowsRuntimeMarshal.AddEventHandler<ExceptionRoutedEventHandler>(new Func<ExceptionRoutedEventHandler, EventRegistrationToken>(bitmapImage2.add_ImageFailed), new Action<EventRegistrationToken>(bitmapImage2.remove_ImageFailed), new ExceptionRoutedEventHandler(this.ImageLoadFail));
      return image;
    }

    private void ImageOpened(object sender, RoutedEventArgs e) => this.CleanupImageEvents(sender);

    private void ImageLoadFail(object sender, ExceptionRoutedEventArgs e)
    {
      this.CleanupImageEvents(sender);
      if (this.ImageFailed == null)
        return;
      this.ImageFailed(sender, e);
    }

    private void CleanupImageEvents(object sender)
    {
      if (!(sender is BitmapImage bitmapImage))
        return;
      WindowsRuntimeMarshal.RemoveEventHandler<RoutedEventHandler>(new Action<EventRegistrationToken>(bitmapImage.remove_ImageOpened), new RoutedEventHandler(this.ImageOpened));
      WindowsRuntimeMarshal.RemoveEventHandler<ExceptionRoutedEventHandler>(new Action<EventRegistrationToken>(bitmapImage.remove_ImageFailed), new ExceptionRoutedEventHandler(this.ImageLoadFail));
    }

    private void TrackAnimationForImageRemoval(
      int row,
      int col,
      Storyboard sb,
      bool forceLargeImageCleanup)
    {
      this._animationTracking.Add(new ImageTileState()
      {
        Storyboard = sb,
        Row = row,
        Column = col,
        ForceLargeImageCleanup = forceLargeImageCleanup
      });
    }

    private void AnimationCompleted(object sender, object e)
    {
      Storyboard itemStoryboard = sender as Storyboard;
      if (itemStoryboard == null)
        return;
      WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<object>>(new Action<EventRegistrationToken>(((Timeline) itemStoryboard).remove_Completed), new EventHandler<object>(this.AnimationCompleted));
      ImageTileState imageTileState = this._animationTracking.FirstOrDefault<ImageTileState>((Func<ImageTileState, bool>) (x => x.Storyboard == itemStoryboard));
      if (imageTileState.ForceLargeImageCleanup)
      {
        for (int index1 = 0; index1 < this.LargeTileRows; ++index1)
        {
          for (int index2 = 0; index2 < this.LargeTileColumns; ++index2)
          {
            if (index1 != 0 || index2 != 0)
              this.RemoveOldImagesFromGrid(index1 + imageTileState.Row, index2 + imageTileState.Column, true);
          }
        }
      }
      this.RemoveOldImagesFromGrid(imageTileState.Row, imageTileState.Column);
      this._animationTracking.Remove(imageTileState);
      imageTileState.Storyboard = (Storyboard) null;
    }

    private void RemoveOldImagesFromGrid(int row, int col, bool forceRemoval = false)
    {
      Image[] array = ((FrameworkElement) this._imageContainer).GetLogicalChildrenByType<Image>(false).Where<Image>((Func<Image, bool>) (x => (int) ((DependencyObject) x).GetValue(Grid.RowProperty) == row && (int) ((DependencyObject) x).GetValue(Grid.ColumnProperty) == col)).ToArray<Image>();
      int num1 = forceRemoval ? 0 : 1;
      int num2 = ((IEnumerable<Image>) array).Count<Image>();
      for (int index = 0; index < num2 - num1; ++index)
        ((ICollection<UIElement>) ((Panel) this._imageContainer).Children).Remove((UIElement) array[index]);
    }

    private Uri GetRandomImageUri(int index)
    {
      int count = this.ItemsSource.Count;
      int maxAvailableSlots = this.Rows * this.Columns;
      int maxLoopCounter = 0;
      Uri imgUri;
      do
      {
        imgUri = this.ItemsSource[ImageTile.RandomIndexer.Next(count)];
        ++maxLoopCounter;
      }
      while (this.AllowRandomImageFetchToContinue(index, maxAvailableSlots, count, maxLoopCounter, imgUri));
      this._imageCurrentLocation[index] = imgUri;
      this._imagesBeingShown.Add(imgUri);
      return imgUri;
    }

    private void GetRowAndColumnForIndex(int index, out int row, out int column)
    {
      column = index % this.Columns;
      row = (index - column) / this.Rows;
    }

    private bool AllowRandomImageFetchToContinue(
      int targetIndex,
      int maxAvailableSlots,
      int imageSourceCount,
      int maxLoopCounter,
      Uri imgUri)
    {
      if (maxLoopCounter >= 10)
        return false;
      if (imageSourceCount > maxAvailableSlots)
        return this._imageCurrentLocation.ContainsValue(imgUri);
      return (!this._imageCurrentLocation.ContainsKey(targetIndex) ? 0 : (this._imageCurrentLocation[targetIndex] == imgUri ? 1 : 0)) != 0 || this._imagesBeingShown.Contains(imgUri);
    }

    public int Columns
    {
      get => (int) ((DependencyObject) this).GetValue(ImageTile.ColumnProperty);
      set => ((DependencyObject) this).SetValue(ImageTile.ColumnProperty, (object) value);
    }

    public int Rows
    {
      get => (int) ((DependencyObject) this).GetValue(ImageTile.RowsProperty);
      set => ((DependencyObject) this).SetValue(ImageTile.RowsProperty, (object) value);
    }

    public int LargeTileColumns
    {
      get => (int) ((DependencyObject) this).GetValue(ImageTile.LargeTileColumnsProperty);
      set => ((DependencyObject) this).SetValue(ImageTile.LargeTileColumnsProperty, (object) value);
    }

    public int LargeTileRows
    {
      get => (int) ((DependencyObject) this).GetValue(ImageTile.LargeTileRowsProperty);
      set => ((DependencyObject) this).SetValue(ImageTile.LargeTileRowsProperty, (object) value);
    }

    public List<Uri> ItemsSource
    {
      get => (List<Uri>) ((DependencyObject) this).GetValue(ImageTile.ItemsSourceProperty);
      set => ((DependencyObject) this).SetValue(ImageTile.ItemsSourceProperty, (object) value);
    }

    public ImageTileAnimationTypes AnimationType
    {
      get
      {
        return (ImageTileAnimationTypes) ((DependencyObject) this).GetValue(ImageTile.AnimationTypesProperty);
      }
      set => ((DependencyObject) this).SetValue(ImageTile.AnimationTypesProperty, (object) value);
    }

    public bool IsFrozen
    {
      get => (bool) ((DependencyObject) this).GetValue(ImageTile.IsFrozenProperty);
      set => ((DependencyObject) this).SetValue(ImageTile.IsFrozenProperty, (object) value);
    }

    public int AnimationDuration
    {
      get => (int) ((DependencyObject) this).GetValue(ImageTile.AnimationDurationProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageTile.AnimationDurationProperty, (object) value);
      }
    }

    public int ImageCycleInterval
    {
      get => (int) ((DependencyObject) this).GetValue(ImageTile.ImageCycleIntervalProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageTile.ImageCycleIntervalProperty, (object) value);
      }
    }

    private static void OnIsFrozenPropertyChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      if (!(dependencyObject is ImageTile imageTile) || imageTile._changeImageTimer == null)
        return;
      imageTile.IsFrozenPropertyChanged();
    }

    private void IsFrozenPropertyChanged()
    {
      if (this.IsFrozen)
        this._changeImageTimer.Stop();
      else
        this._changeImageTimer.Start();
    }

    private static void OnImageCycleIntervalPropertyChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      if (!(dependencyObject is ImageTile imageTile) || imageTile._changeImageTimer == null)
        return;
      imageTile.ImageCycleIntervalChanged();
    }

    private void ImageCycleIntervalChanged()
    {
      int num = this._changeImageTimer.IsEnabled ? 1 : 0;
      this._changeImageTimer.Stop();
      this._changeImageTimer.put_Interval(TimeSpan.FromMilliseconds((double) this.ImageCycleInterval));
      if (num == 0)
        return;
      this._changeImageTimer.Start();
    }

    private static void OnLargeTileChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      if (!(dependencyObject is ImageTile imageTile) || args.NewValue == args.OldValue)
        return;
      imageTile.VerifyGridBounds();
    }

    private static void OnGridSizeChanged(
      DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      if (!(dependencyObject is ImageTile imageTile) || args.NewValue == args.OldValue)
        return;
      imageTile.VerifyGridBounds();
      imageTile.GridSizeChanged();
    }

    private void GridSizeChanged()
    {
      if (this._imageContainer == null)
        return;
      int count1 = ((ICollection<ColumnDefinition>) this._imageContainer.ColumnDefinitions).Count;
      int count2 = ((ICollection<RowDefinition>) this._imageContainer.RowDefinitions).Count;
      if (count1 > this.Columns)
      {
        for (int index = count1 - 1; index >= this.Columns; --index)
        {
          ((IList<ColumnDefinition>) this._imageContainer.ColumnDefinitions).RemoveAt(index);
          this.KeepGridInSyncCol(index);
        }
      }
      else if (count1 < this.Columns)
      {
        for (int index = 0; index < this.Columns - count1; ++index)
          ((ICollection<ColumnDefinition>) this._imageContainer.ColumnDefinitions).Add(new ColumnDefinition());
      }
      if (count2 > this.Rows)
      {
        for (int index = count2 - 1; index >= this.Rows; --index)
        {
          ((IList<RowDefinition>) this._imageContainer.RowDefinitions).RemoveAt(index);
          this.KeepGridInSyncRow(index);
        }
      }
      else
      {
        if (count2 >= this.Rows)
          return;
        for (int index = 0; index < this.Rows - count2; ++index)
          ((ICollection<RowDefinition>) this._imageContainer.RowDefinitions).Add(new RowDefinition());
      }
    }

    private void VerifyGridBounds()
    {
      if (this.Rows < 1)
        throw new ArgumentOutOfRangeException("Rows", "Rows must be greater than 0");
      if (this.Columns < 1)
        throw new ArgumentOutOfRangeException("Columns", "Columns must be greater than 0");
      if (this.LargeTileRows < 1)
        throw new ArgumentOutOfRangeException("LargeTileRows", "LargeTileRows must be greater than 0");
      if (this.LargeTileRows > this.Rows)
        throw new ArgumentOutOfRangeException("LargeTileRows", "LargeTileRows must be less than or equal to Rows");
      if (this.LargeTileColumns < 1)
        throw new ArgumentOutOfRangeException("LargeTileColumns", "LargeTileColumns must be greater than 0");
      if (this.LargeTileColumns > this.Columns)
        throw new ArgumentOutOfRangeException("LargeTileColumns", "LargeTileColumns must be less than or equal to Columns");
    }

    private void KeepGridInSyncRow(int row)
    {
      for (int col = 0; col < this.Columns; ++col)
        this.KeepGridInSync(row, col);
    }

    private void KeepGridInSyncCol(int col)
    {
      for (int row = 0; row < this.Rows; ++row)
        this.KeepGridInSync(row, col);
    }

    private void KeepGridInSync(int row, int col)
    {
      int index = this.CalculateIndex(row, col);
      Uri uri;
      if (this._imageCurrentLocation.TryGetValue(index, out uri))
      {
        this._imagesBeingShown.Remove(uri);
        this._imageCurrentLocation.Remove(index);
      }
      this._availableSpotsOnGrid.Remove(index);
    }
  }
}

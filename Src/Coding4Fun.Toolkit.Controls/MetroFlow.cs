// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.MetroFlow
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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;


namespace Coding4Fun.Toolkit.Controls
{
  public class MetroFlow : ItemsControl
  {
    private GridLength _minimizedGridLength = new GridLength(48.0);
    private readonly GridLength _maximizedGridLength = new GridLength(1.0, GridUnitType.Star);
    private Storyboard _animationBoard;
    private Grid _layoutGrid;
    private int _minimizingColumnIndex;
    private const string LayoutRootName = "LayoutRoot";
    public static readonly DependencyProperty AnimationDurationProperty = DependencyProperty.Register(nameof (AnimationDuration), typeof (TimeSpan), typeof (MetroFlow), new PropertyMetadata((object) TimeSpan.FromMilliseconds(100.0)));
    public static readonly DependencyProperty SelectedColumnIndexProperty = DependencyProperty.Register(nameof (SelectedColumnIndex), typeof (int), typeof (MetroFlow), new PropertyMetadata((object) 0, new PropertyChangedCallback(MetroFlow.SelectedColumnIndexChanged)));
    public static readonly DependencyProperty ExpandingWidthProperty = DependencyProperty.Register(nameof (ExpandingWidth), typeof (double), typeof (MetroFlow), new PropertyMetadata((object) 0.0, new PropertyChangedCallback(MetroFlow.ColumnGrowWidthChanged)));
    public static readonly DependencyProperty CollapsingWidthProperty = DependencyProperty.Register(nameof (CollapsingWidth), typeof (double), typeof (MetroFlow), new PropertyMetadata((object) 0.0, new PropertyChangedCallback(MetroFlow.ColumnShrinkWidthChanged)));

    public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

    public event EventHandler<SelectionTapEventArgs> SelectionTap;

    public MetroFlow() => ((Control) this).put_DefaultStyleKey((object) typeof (MetroFlow));

    protected virtual void OnItemsChanged(object e)
    {
      base.OnItemsChanged(e);
      if (this._layoutGrid == null)
        return;
      if (this.SelectedColumnIndex >= ((ICollection<object>) this.Items).Count)
        this.SelectedColumnIndex = ((ICollection<object>) this.Items).Count - 1;
      else if (((ICollection<object>) this.Items).Count > 0 && this.SelectedColumnIndex < 0)
        this.SelectedColumnIndex = 0;
      this.ControlLoaded();
    }

    protected virtual bool IsItemItsOwnContainerOverride(object item) => item is MetroFlowData;

    protected virtual void OnApplyTemplate()
    {
      ((FrameworkElement) this).OnApplyTemplate();
      this._layoutGrid = ((Control) this).GetTemplateChild("LayoutRoot") as Grid;
      if (this._layoutGrid == null || ApplicationSpace.IsDesignMode && ((ICollection<object>) this.Items).Count <= 0)
        return;
      this.ControlLoaded();
    }

    public TimeSpan AnimationDuration
    {
      get => (TimeSpan) ((DependencyObject) this).GetValue(MetroFlow.AnimationDurationProperty);
      set
      {
        ((DependencyObject) this).SetValue(MetroFlow.AnimationDurationProperty, (object) value);
      }
    }

    public int SelectedColumnIndex
    {
      get => (int) ((DependencyObject) this).GetValue(MetroFlow.SelectedColumnIndexProperty);
      set
      {
        ((DependencyObject) this).SetValue(MetroFlow.SelectedColumnIndexProperty, (object) value);
      }
    }

    private static void SelectedColumnIndexChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is MetroFlow metroFlow) || e.NewValue == e.OldValue)
        return;
      metroFlow.SelectionIndexChanged((int) e.OldValue);
    }

    private void SelectionIndexChanged(int oldIndex)
    {
      this._minimizingColumnIndex = oldIndex;
      this.VerifyMinimizingColumnIndex();
      if (this.SelectionChanged != null)
      {
        MetroFlowData metroFlowData = ((ICollection<object>) this.Items).Count <= 0 || this.SelectedColumnIndex < 0 ? (MetroFlowData) null : (MetroFlowData) ((IList<object>) this.Items)[this.SelectedColumnIndex];
        this.SelectionChanged((object) this, new SelectionChangedEventArgs((IList<object>) new List<object>()
        {
          (object) (((ICollection<object>) this.Items).Count <= 0 || this._minimizingColumnIndex < 0 ? (MetroFlowData) null : (MetroFlowData) ((IList<object>) this.Items)[this._minimizingColumnIndex])
        }, (IList<object>) new List<object>()
        {
          (object) metroFlowData
        }));
      }
      this.CreateSb(this._layoutGrid, oldIndex);
    }

    public double ExpandingWidth
    {
      get => (double) ((DependencyObject) this).GetValue(MetroFlow.ExpandingWidthProperty);
      set => ((DependencyObject) this).SetValue(MetroFlow.ExpandingWidthProperty, (object) value);
    }

    public double CollapsingWidth
    {
      get => (double) ((DependencyObject) this).GetValue(MetroFlow.CollapsingWidthProperty);
      set => ((DependencyObject) this).SetValue(MetroFlow.CollapsingWidthProperty, (object) value);
    }

    private static void ColumnGrowWidthChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is MetroFlow metroFlow))
        return;
      Grid layoutGrid = metroFlow._layoutGrid;
      if (((ICollection<ColumnDefinition>) layoutGrid.ColumnDefinitions).Count <= 1)
        return;
      MetroFlow.ChangeColumnWidth(((IList<ColumnDefinition>) layoutGrid.ColumnDefinitions)[metroFlow.SelectedColumnIndex], (double) e.NewValue);
    }

    private static void ColumnShrinkWidthChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is MetroFlow metroFlow))
        return;
      metroFlow.VerifyMinimizingColumnIndex();
      Grid layoutGrid = metroFlow._layoutGrid;
      if (((ICollection<ColumnDefinition>) layoutGrid.ColumnDefinitions).Count <= 1)
        return;
      MetroFlow.ChangeColumnWidth(((IList<ColumnDefinition>) layoutGrid.ColumnDefinitions)[metroFlow._minimizingColumnIndex], (double) e.NewValue);
    }

    private void VerifyMinimizingColumnIndex()
    {
      if (this._minimizingColumnIndex < ((ICollection<object>) this.Items).Count)
        return;
      this._minimizingColumnIndex = ((ICollection<object>) this.Items).Count - 1;
      if (this.SelectedColumnIndex == this._minimizingColumnIndex)
        --this._minimizingColumnIndex;
      if (this._minimizingColumnIndex >= 0)
        return;
      this._minimizingColumnIndex = 0;
    }

    private static void ChangeColumnWidth(ColumnDefinition target, double value)
    {
      target?.put_Width(new GridLength(value));
    }

    private void ControlLoaded()
    {
      Grid layoutGrid = this._layoutGrid;
      if (this._layoutGrid == null || this.Items == null)
        return;
      ((ICollection<ColumnDefinition>) layoutGrid.ColumnDefinitions).Clear();
      ((ICollection<UIElement>) ((Panel) layoutGrid).Children).Clear();
      int num = 0;
      foreach (MetroFlowData metroFlowData in (IEnumerable<object>) this.Items)
      {
        bool flag = num == this.SelectedColumnIndex;
        ColumnDefinition columnDefinition1 = new ColumnDefinition();
        columnDefinition1.put_Width(!flag ? this._minimizedGridLength : new GridLength(1.0, GridUnitType.Star));
        ColumnDefinition columnDefinition2 = columnDefinition1;
        ((ICollection<ColumnDefinition>) layoutGrid.ColumnDefinitions).Add(columnDefinition2);
        MetroFlowItem metroFlowItem1 = new MetroFlowItem()
        {
          ItemIndex = num + 1,
          ItemIndexOpacity = !flag ? 1.0 : 0.0,
          ItemIndexVisibility = !flag ? (Visibility) 0 : (Visibility) 1,
          ImageSource = (ImageSource) new BitmapImage(metroFlowData.ImageUri),
          ImageOpacity = flag ? 1.0 : 0.0,
          ImageVisibility = flag ? (Visibility) 0 : (Visibility) 1,
          Title = metroFlowData.Title,
          TitleOpacity = flag ? 1.0 : 0.0,
          TitleVisibility = flag ? (Visibility) 0 : (Visibility) 1
        };
        ((DependencyObject) metroFlowItem1).SetValue(Grid.ColumnProperty, (object) num);
        MetroFlowItem metroFlowItem2 = metroFlowItem1;
        WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(((UIElement) metroFlowItem2).add_Tapped), new Action<EventRegistrationToken>(((UIElement) metroFlowItem2).remove_Tapped), new TappedEventHandler(this.ItemTap));
        ((ICollection<UIElement>) ((Panel) layoutGrid).Children).Add((UIElement) metroFlowItem1);
        ++num;
      }
    }

    private void ItemTap(object sender, TappedRoutedEventArgs e)
    {
      if (!(sender is MetroFlowItem element))
        return;
      int selectedColumnIndex1 = this.SelectedColumnIndex;
      this.SelectedColumnIndex = MetroFlow.GetColumnIndex((DependencyObject) element);
      int selectedColumnIndex2 = this.SelectedColumnIndex;
      if (selectedColumnIndex1 != selectedColumnIndex2 || this.SelectionTap == null)
        return;
      this.SelectionTap((object) this, new SelectionTapEventArgs()
      {
        Index = this.SelectedColumnIndex,
        Data = (MetroFlowData) ((IList<object>) this.Items)[this.SelectedColumnIndex]
      });
    }

    private void HandleStoppingAnimation(int targetIndex)
    {
      if (this._animationBoard == null || this._animationBoard.GetCurrentState() != null)
        return;
      this._animationBoard.Stop();
      this.AnimationCompleted(targetIndex);
    }

    private void CreateSb(Grid target, int oldIndex)
    {
      if (target == null || ((ICollection<ColumnDefinition>) target.ColumnDefinitions).Count < this.SelectedColumnIndex)
        return;
      this.HandleStoppingAnimation(oldIndex);
      Storyboard sb = new Storyboard();
      MetroFlowItem metroFlowItem1 = MetroFlow.GetMetroFlowItem((Panel) target, this.SelectedColumnIndex);
      MetroFlowItem metroFlowItem2 = MetroFlow.GetMetroFlowItem((Panel) target, oldIndex);
      if (metroFlowItem1 != null)
      {
        metroFlowItem1.ImageVisibility = (Visibility) 0;
        metroFlowItem1.TitleVisibility = (Visibility) 0;
        this.CreateDoubleAnimations(sb, (DependencyObject) metroFlowItem1, "ImageOpacity", 1.0, metroFlowItem1.ImageOpacity);
        this.CreateDoubleAnimations(sb, (DependencyObject) metroFlowItem1, "TitleOpacity", 1.0, metroFlowItem1.TitleOpacity);
        this.CreateDoubleAnimations(sb, (DependencyObject) metroFlowItem1, "ItemIndexOpacity", fromValue: metroFlowItem1.ItemIndexOpacity);
      }
      if (metroFlowItem2 != null)
      {
        metroFlowItem2.ItemIndexVisibility = (Visibility) 0;
        this.CreateDoubleAnimations(sb, (DependencyObject) metroFlowItem2, "ImageOpacity", fromValue: metroFlowItem2.ImageOpacity);
        this.CreateDoubleAnimations(sb, (DependencyObject) metroFlowItem2, "TitleOpacity", fromValue: metroFlowItem2.TitleOpacity);
        this.CreateDoubleAnimations(sb, (DependencyObject) metroFlowItem2, "ItemIndexOpacity", 1.0, metroFlowItem2.ItemIndexOpacity);
      }
      DoubleAnimation doubleAnimations1 = this.CreateDoubleAnimations(sb, (DependencyObject) this, "CollapsingWidth", this._minimizedGridLength.Value);
      DoubleAnimation doubleAnimations2 = this.CreateDoubleAnimations(sb, (DependencyObject) this, "ExpandingWidth", fromValue: this._minimizedGridLength.Value);
      Storyboard storyboard = sb;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(((Timeline) storyboard).add_Completed), new Action<EventRegistrationToken>(((Timeline) storyboard).remove_Completed), (EventHandler<object>) ((sbSender, sbEventArgs) => this.AnimationCompleted()));
      if (metroFlowItem2 != null)
      {
        double actualWidth = ((FrameworkElement) metroFlowItem2).ActualWidth;
        doubleAnimations2.put_To(new double?(actualWidth));
        doubleAnimations1.put_From(new double?(actualWidth));
      }
      ((UIElement) this).UpdateLayout();
      this._animationBoard = sb;
      this._animationBoard.Begin();
    }

    private DoubleAnimation CreateDoubleAnimations(
      Storyboard sb,
      DependencyObject target,
      string propertyPath,
      double toValue = 0.0,
      double fromValue = 0.0)
    {
      DoubleAnimation doubleAnimation = new DoubleAnimation();
      doubleAnimation.put_To(new double?(toValue));
      doubleAnimation.put_From(new double?(fromValue));
      ((Timeline) doubleAnimation).put_Duration((Duration) this.AnimationDuration);
      DoubleAnimation doubleAnimations = doubleAnimation;
      Storyboard.SetTarget((Timeline) doubleAnimations, target);
      Storyboard.SetTargetProperty((Timeline) doubleAnimations, propertyPath);
      ((ICollection<Timeline>) sb.Children).Add((Timeline) doubleAnimations);
      return doubleAnimations;
    }

    private static MetroFlowItem GetMetroFlowItem(Panel target, int index)
    {
      return ((IEnumerable<UIElement>) target.Children).Where<UIElement>((Func<UIElement, bool>) (item => MetroFlow.GetColumnIndex((DependencyObject) item) == index)).SingleOrDefault<UIElement>() as MetroFlowItem;
    }

    private static int GetColumnIndex(DependencyObject element)
    {
      return (int) element.GetValue(Grid.ColumnProperty);
    }

    private void AnimationCompleted() => this.AnimationCompleted(this.SelectedColumnIndex);

    private void AnimationCompleted(int column)
    {
      for (int index = 0; index < ((ICollection<ColumnDefinition>) this._layoutGrid.ColumnDefinitions).Count; ++index)
        ((IList<ColumnDefinition>) this._layoutGrid.ColumnDefinitions)[index].put_Width(index != column ? this._minimizedGridLength : this._maximizedGridLength);
      foreach (MetroFlowItem element in ((IEnumerable<UIElement>) ((Panel) this._layoutGrid).Children).Select<UIElement, MetroFlowItem>((Func<UIElement, MetroFlowItem>) (t => t as MetroFlowItem)))
        MetroFlow.SetMetroFlowControlItemProperties(element, MetroFlow.GetColumnIndex((DependencyObject) element) == column);
      ((UIElement) this).UpdateLayout();
    }

    private static void SetMetroFlowControlItemProperties(MetroFlowItem item, bool isLarge)
    {
      if (item == null)
        return;
      item.ImageVisibility = item.TitleVisibility = isLarge ? (Visibility) 0 : (Visibility) 1;
      MetroFlowItem metroFlowItem1 = item;
      MetroFlowItem metroFlowItem2 = item;
      int num1 = isLarge ? 1 : 0;
      double num2;
      double num3 = num2 = (double) num1;
      metroFlowItem2.ImageOpacity = num2;
      double num4 = num3;
      metroFlowItem1.TitleOpacity = num4;
      item.ItemIndexVisibility = isLarge ? (Visibility) 1 : (Visibility) 0;
      item.ItemIndexOpacity = isLarge ? 0.0 : 1.0;
    }
  }
}

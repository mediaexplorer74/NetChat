// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.ActionPopUp`2
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Coding4Fun.Toolkit.Controls
{
  public class ActionPopUp<T, TPopUpResult> : PopUp<T, TPopUpResult>
  {
    private const string ActionButtonAreaName = "actionButtonArea";
    protected Panel ActionButtonArea;
    public readonly DependencyProperty ActionPopUpButtonsProperty = DependencyProperty.Register(nameof (ActionPopUpButtons), typeof (List<Button>), typeof (ActionPopUp<T, TPopUpResult>), new PropertyMetadata((object) new List<Button>(), new PropertyChangedCallback(ActionPopUp<T, TPopUpResult>.OnActionPopUpButtonsChanged)));

    protected override void OnApplyTemplate()
    {
      this.Focus((FocusState) 3);
      base.OnApplyTemplate();
      this.ActionButtonArea = this.GetTemplateChild("actionButtonArea") as Panel;
      this.SetButtons();
    }

    private void SetButtons()
    {
      if (this.ActionButtonArea == null)
        return;
      ((ICollection<UIElement>) this.ActionButtonArea.Children).Clear();
      bool flag = false;
      foreach (Button actionPopUpButton in this.ActionPopUpButtons)
      {
        ((ICollection<UIElement>) this.ActionButtonArea.Children).Add((UIElement) actionPopUpButton);
        flag |= ((ContentControl) actionPopUpButton).Content != null;
      }
      if (!flag)
        return;
      ((FrameworkElement) this.ActionButtonArea).put_Margin(new Thickness());
    }

    private static void OnActionPopUpButtonsChanged(
      DependencyObject o,
      DependencyPropertyChangedEventArgs e)
    {
      ActionPopUp<T, TPopUpResult> actionPopUp = (ActionPopUp<T, TPopUpResult>) o;
      if (actionPopUp == null || e.NewValue == e.OldValue)
        return;
      actionPopUp.SetButtons();
    }

    public List<Button> ActionPopUpButtons
    {
      get => (List<Button>) ((DependencyObject) this).GetValue(this.ActionPopUpButtonsProperty);
      set => ((DependencyObject) this).SetValue(this.ActionPopUpButtonsProperty, (object) value);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: IGM.UI.UICore
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using Windows.UI.Core;
using Windows.UI.Popups;


namespace IGM.UI
{
  public partial class UICore
  {
    public static async void PopupMessage(string message, string buttonLabel)
    {
      MessageDialog messageDialog = new MessageDialog(message);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      messageDialog.Commands.Add((IUICommand) new UICommand(buttonLabel, UICore.\u003C\u003Ec.\u003C\u003E9__0_0 ?? (UICore.\u003C\u003Ec.\u003C\u003E9__0_0 = new UICommandInvokedHandler((object) UICore.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CPopupMessage\u003Eb__0_0)))));
      IUICommand iuiCommand = await messageDialog.ShowAsync();
    }

    public static async void UpdateUIThread(DispatchedHandler action, CoreDispatcher dispatcher)
    {
      await dispatcher.RunAsync((CoreDispatcherPriority) 0, action);
    }
  }
}

﻿using System;
using Windows.UI.Core;
using Windows.UI.Popups;
using System.Threading.Tasks;


namespace IGM.UI
{
  public partial class UICore
  {
    public static async void PopupMessage(string message, string buttonLabel)
    {
      MessageDialog messageDialog = new MessageDialog(message);
      messageDialog.Commands.Add(new UICommand(buttonLabel, (UICommandInvokedHandler)(command => { })));
      IUICommand iuiCommand = await messageDialog.ShowAsync();
    }

    public static async void UpdateUIThread(DispatchedHandler action, CoreDispatcher dispatcher)
    {
      await dispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
    }
  }
}
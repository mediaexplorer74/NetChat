// Decompiled with JetBrains decompiler
// Type: IGM.UI.ChatBubblePanel
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using weekysoft.store.ChatRoom;
using weekysoft.store.Chatting;
using weekysoft.store.Messaging;
using weekysoft.store.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace IGM.UI
{
  public sealed class ChatBubblePanel : UserControl, IComponentConnector
  {
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private ListView lvChat;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBox tbSend;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private MediaElement meChatVoice;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private Button send;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private ToggleButton tgTextToSpeech;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private ToggleButton tgHelp;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;

    public ChatBubblePanel()
    {
      this.InitializeComponent();
      ((FrameworkElement) this).put_DataContext((object) Setting.Current);
      this.InitializeChatPanel();
    }

    private void InitializeChatPanel()
    {
      int lifetimeCount = Setting.Current.LifetimeUseCount++;
      ++Setting.Current.CurrentUseCount;
      if (Setting.Current.CurrentUseCount >= 10 && !Setting.Current.Rated)
      {
        if (Setting.Current.GetLifeTimeUseCountRange(lifetimeCount) != "0")
          Util.LogEvent(string.Format("Lifetime Use Count {0}", (object) Setting.Current.GetLifeTimeUseCountRange(lifetimeCount)));
        this.ShowRatingDialog();
      }
      if (Setting.Current.LifetimeUseCount <= 2)
        this.DisplayHowToUseThisApp();
      MediaElement meChatVoice = this.meChatVoice;
      WindowsRuntimeMarshal.AddEventHandler<ExceptionRoutedEventHandler>(new Func<ExceptionRoutedEventHandler, EventRegistrationToken>(meChatVoice.add_MediaFailed), new Action<EventRegistrationToken>(meChatVoice.remove_MediaFailed), new ExceptionRoutedEventHandler(this.meChatVoice_MediaFailed));
      UIBinder.Current.ForegroundPlayer = this.meChatVoice;
      ClientData.Current.ChatMessaging.MessageReceivedError -= new EventHandler<ErrorEventArgs>(this.MessageReceivedError);
      ClientData.Current.ChatMessaging.MessageReceivedError += new EventHandler<ErrorEventArgs>(this.MessageReceivedError);
      ClientData.Current.ChatMessaging.MessageValidated -= new EventHandler<MessageEventArgs>(this.ChatPanel_MessageValidated);
      ClientData.Current.ChatMessaging.MessageValidated += new EventHandler<MessageEventArgs>(this.ChatPanel_MessageValidated);
      ClientData.Current.ChatMessaging.ReceivedMessageText -= new EventHandler<MessageEventArgs>(this.ReceivedMessageText);
      ClientData.Current.ChatMessaging.ReceivedMessageText += new EventHandler<MessageEventArgs>(this.ReceivedMessageText);
      ClientData.Current.ChatMessaging.MessageConfirmed -= new EventHandler<MessageEventArgs>(this.Main_MessageConfirmed);
      ClientData.Current.ChatMessaging.MessageConfirmed += new EventHandler<MessageEventArgs>(this.Main_MessageConfirmed);
      ClientData.Current.ChatMessaging.MessageLost -= new EventHandler<MessageEventArgs>(this.Main_MessageLost);
      ClientData.Current.ChatMessaging.MessageLost += new EventHandler<MessageEventArgs>(this.Main_MessageLost);
      ClientData.Current.CurrentSite.RoomSwitched += new EventHandler<RoomEventArgs>(this.RoomSwitched);
      ClientData.Current.ChatMessaging.MessageFullyConfirmed -= new EventHandler<MessageEventArgs>(this.Main_MessageFullyConfirmed);
      ClientData.Current.ChatMessaging.MessageFullyConfirmed += new EventHandler<MessageEventArgs>(this.Main_MessageFullyConfirmed);
    }

    private void DisplayHowToUseThisApp()
    {
      UIBinder.Current.HandleReceivedMessage(ClientData.Current.CurrentRoom.CreateBotMessage(ClientData.Current.ChatLabel.AppInstructoinLabel, ClientData.Current.LobbyBot, Gender.Female), ClientData.Current.MySelf, this.lvChat, Colors.Gray);
    }

    private async void Main_MessageFullyConfirmed(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatBubblePanel.\u003C\u003Ec__DisplayClass3_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CMain_MessageFullyConfirmed\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    private async void MessageReceivedError(object sender, ErrorEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatBubblePanel.\u003C\u003Ec__DisplayClass4_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CMessageReceivedError\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    private async void RoomSwitched(object sender, RoomEventArgs e)
    {
      UIBinder.Current.AddRoomBanner(this.lvChat, e.ActiveMember);
    }

    private async void ReceivedMessageText(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatBubblePanel.\u003C\u003Ec__DisplayClass6_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CReceivedMessageText\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    protected async void ShowRatingDialog()
    {
      MessageDialog messageDialog = new MessageDialog("Ready to rating this app?");
      // ISSUE: method pointer
      messageDialog.Commands.Add((IUICommand) new UICommand("Rate", new UICommandInvokedHandler((object) this, __methodptr(RateAppCommand))));
      // ISSUE: method pointer
      messageDialog.Commands.Add((IUICommand) new UICommand("Later", new UICommandInvokedHandler((object) this, __methodptr(RateLaterCommand))));
      IUICommand iuiCommand = await messageDialog.ShowAsync();
    }

    private async void RateLaterCommand(IUICommand command)
    {
      Util.LogEvent("Rate Later");
      Setting.Current.CurrentUseCount = 0;
    }

    private async void RateAppCommand(IUICommand command)
    {
      Util.LogEvent("Rate App");
      await Util.LaunchRateAppUri();
    }

    private async void meChatVoice_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
      Util.LogEvent("Media Failed");
      if (e.ErrorMessage.Contains("MF_MEDIA_ENGINE_ERR_SRC_NOT_SUPPORTED"))
        return;
      Util.LogEvent(e.ErrorMessage);
    }

    private async void ChatPanel_MessageValidated(object sender, MessageEventArgs e)
    {
    }

    protected async void Main_MessageConfirmed(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatBubblePanel.\u003C\u003Ec__DisplayClass12_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CMain_MessageConfirmed\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    protected async void Main_MessageLost(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatBubblePanel.\u003C\u003Ec__DisplayClass13_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CMain_MessageLost\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    protected async void SendMessage(object sender, RoutedEventArgs e)
    {
      if (Setting.Current.IsDebugMode)
      {
        if (this.tbSend.Text == Setting.Current.DisableDelay)
          Setting.Current.HasDelay = false;
        int i = 0;
        int total = 0;
        int.TryParse(this.tbSend.Text, out total);
        while (i < total)
        {
          ++i;
          UIBinder.Current.HandleOwnMessage(await ClientData.Current.CurrentRoom.SendMessage(ClientData.Current.ChatMessaging.UserName + "_" + (object) i), ClientData.Current.MySelf, this.lvChat, Colors.Gray);
          if (Setting.Current.HasDelay)
            await Task.Delay(45);
        }
        this.tbSend.put_Text("");
      }
      else
      {
        ChatMessage message = await ClientData.Current.CurrentRoom.SendMessage(this.tbSend.Text);
        string userName = ClientData.Current.CurrentRoom.ChatMessaging.UserName;
        UIBinder.Current.HandleOwnMessage(message, ClientData.Current.MySelf, this.lvChat, Colors.Gray);
        this.tbSend.put_Text("");
      }
    }

    private async void TrimMessageLog()
    {
      if (((ICollection<object>) ((ItemsControl) this.lvChat).Items).Count <= 500)
        return;
      while (((ICollection<object>) ((ItemsControl) this.lvChat).Items).Count > 100)
        ((IList<object>) ((ItemsControl) this.lvChat).Items).RemoveAt(0);
    }

    private async void tbSend_KeyUp(object sender, KeyRoutedEventArgs e)
    {
      if (!e.Key.Equals((object) (VirtualKey) 13))
        return;
      this.SendMessage(sender, (RoutedEventArgs) e);
    }

    private void tgHelp_Click(object sender, RoutedEventArgs e)
    {
      if (((int) this.tgHelp.IsChecked ?? 0) != 0)
        UIBinder.Current.EnterBot(ClientData.Current.LobbyBot, this.lvChat);
      else
        UIBinder.Current.LeaveBot(ClientData.Current.LobbyBot, this.lvChat);
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///ChatBubblePanel.xaml"), (ComponentResourceLocation) 0);
      this.lvChat = (ListView) ((FrameworkElement) this).FindName("lvChat");
      this.tbSend = (TextBox) ((FrameworkElement) this).FindName("tbSend");
      this.meChatVoice = (MediaElement) ((FrameworkElement) this).FindName("meChatVoice");
      this.send = (Button) ((FrameworkElement) this).FindName("send");
      this.tgTextToSpeech = (ToggleButton) ((FrameworkElement) this).FindName("tgTextToSpeech");
      this.tgHelp = (ToggleButton) ((FrameworkElement) this).FindName("tgHelp");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          UIElement uiElement = (UIElement) target;
          WindowsRuntimeMarshal.AddEventHandler<KeyEventHandler>(new Func<KeyEventHandler, EventRegistrationToken>(uiElement.add_KeyUp), new Action<EventRegistrationToken>(uiElement.remove_KeyUp), new KeyEventHandler(this.tbSend_KeyUp));
          break;
        case 2:
          ButtonBase buttonBase1 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase1.add_Click), new Action<EventRegistrationToken>(buttonBase1.remove_Click), new RoutedEventHandler(this.SendMessage));
          break;
        case 3:
          ButtonBase buttonBase2 = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase2.add_Click), new Action<EventRegistrationToken>(buttonBase2.remove_Click), new RoutedEventHandler(this.tgHelp_Click));
          break;
      }
      this._contentLoaded = true;
    }
  }
}

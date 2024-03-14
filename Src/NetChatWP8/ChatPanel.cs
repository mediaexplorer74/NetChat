// Decompiled with JetBrains decompiler
// Type: IGM.UI.ChatPanel
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
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
  public class ChatPanel : UserControl, IComponentConnector
  {
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private ScrollViewer chatScroll;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBox tbSend;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private Button send;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private MediaElement meChatVoice;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private TextBlock tbMessages;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;

    public ChatPanel()
    {
      this.InitializeComponent();
      ++Setting.Current.LifetimeUseCount;
      ++Setting.Current.CurrentUseCount;
      if (Setting.Current.CurrentUseCount >= 10 && !Setting.Current.Rated)
        this.ShowRatingDialog();
      MediaElement meChatVoice = this.meChatVoice;
      WindowsRuntimeMarshal.AddEventHandler<ExceptionRoutedEventHandler>(new Func<ExceptionRoutedEventHandler, EventRegistrationToken>(meChatVoice.add_MediaFailed), new Action<EventRegistrationToken>(meChatVoice.remove_MediaFailed), new ExceptionRoutedEventHandler(this.meChatVoice_MediaFailed));
      this.meChatVoice.put_Volume(100.0);
      ClientData.Current.ChatMessaging.MessageReceived -= new EventHandler<MessageEventArgs>(this.MessageReceived);
      ClientData.Current.ChatMessaging.MessageReceived += new EventHandler<MessageEventArgs>(this.MessageReceived);
      ClientData.Current.ChatMessaging.MessageValidated -= new EventHandler<MessageEventArgs>(this.ChatPanel_MessageValidated);
      ClientData.Current.ChatMessaging.MessageValidated += new EventHandler<MessageEventArgs>(this.ChatPanel_MessageValidated);
      if (!(ClientData.Current.ChatMessaging is ReliableMessaging))
        return;
      ReliableMessaging chatMessaging = (ReliableMessaging) ClientData.Current.ChatMessaging;
      chatMessaging.MessageConfirmed = chatMessaging.MessageConfirmed - new EventHandler<MessageEventArgs>(this.Main_MessageConfirmed);
      chatMessaging.MessageConfirmed = chatMessaging.MessageConfirmed + new EventHandler<MessageEventArgs>(this.Main_MessageConfirmed);
      chatMessaging.MessageLost = chatMessaging.MessageLost - new EventHandler<MessageEventArgs>(this.Main_MessageLost);
      chatMessaging.MessageLost = chatMessaging.MessageLost + new EventHandler<MessageEventArgs>(this.Main_MessageLost);
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

    private void RateLaterCommand(IUICommand command) => Setting.Current.CurrentUseCount = 0;

    private async void RateAppCommand(IUICommand command) => await Util.LaunchRateAppUri();

    private void meChatVoice_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
    }

    private void ChatPanel_MessageValidated(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ChatPanel.\u003C\u003Ec__DisplayClass5_0 cDisplayClass50 = new ChatPanel.\u003C\u003Ec__DisplayClass5_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass50.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass50.e = e;
      // ISSUE: reference to a compiler-generated field
      if (cDisplayClass50.e.IsValidProtocol)
        return;
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) cDisplayClass50, __methodptr(\u003CChatPanel_MessageValidated\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    protected void Main_MessageConfirmed(object sender, DatagramEventArgs e)
    {
    }

    protected void Main_MessageLost(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatPanel.\u003C\u003Ec__DisplayClass7_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CMain_MessageLost\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    protected void MessageReceived(object sender, MessageEventArgs e)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) new ChatPanel.\u003C\u003Ec__DisplayClass8_0()
      {
        \u003C\u003E4__this = this,
        e = e
      }, __methodptr(\u003CMessageReceived\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    protected async void SendMessage(object sender, RoutedEventArgs e)
    {
      ChatMessage message = await ClientData.Current.CurrentRoom.SendMessage(this.tbSend.Text);
      string userName = ClientData.Current.CurrentRoom.ChatMessaging.UserName;
      int num = (int) UIBinder.Current.HandleMessage(message, ClientData.Current.MySelf, this.tbMessages, Colors.Gray, this.meChatVoice);
      this.chatScroll.ChangeView(new double?(0.0), new double?(this.chatScroll.ScrollableHeight), new float?(1f));
      this.tbSend.put_Text("");
    }

    private async void tbSend_KeyUp(object sender, KeyRoutedEventArgs e)
    {
      if (!e.Key.Equals((object) (VirtualKey) 13))
        return;
      this.SendMessage(sender, (RoutedEventArgs) e);
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///ChatPanel.xaml"), (ComponentResourceLocation) 0);
      this.chatScroll = (ScrollViewer) ((FrameworkElement) this).FindName("chatScroll");
      this.tbSend = (TextBox) ((FrameworkElement) this).FindName("tbSend");
      this.send = (Button) ((FrameworkElement) this).FindName("send");
      this.meChatVoice = (MediaElement) ((FrameworkElement) this).FindName("meChatVoice");
      this.tbMessages = (TextBlock) ((FrameworkElement) this).FindName("tbMessages");
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
          ButtonBase buttonBase = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase.add_Click), new Action<EventRegistrationToken>(buttonBase.remove_Click), new RoutedEventHandler(this.SendMessage));
          break;
      }
      this._contentLoaded = true;
    }
  }
}

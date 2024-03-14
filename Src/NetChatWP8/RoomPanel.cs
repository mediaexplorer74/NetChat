// Decompiled with JetBrains decompiler
// Type: IGM.UI.RoomPanel
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using weekysoft.store.ChatRoom;
using weekysoft.store.Chatting;
using weekysoft.store.Messaging;
using weekysoft.store.Serializer;
using weekysoft.store.Storage;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace IGM.UI
{
  public class RoomPanel : UserControl, IComponentConnector
  {
    private ThreadPoolTimer _PeriodicTimer;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private ListBox lbRooms;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private Button btnNewTemporaryRoom;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;

    public RoomPanel()
    {
      this.InitializeComponent();
      // ISSUE: method pointer
      this._PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler((object) this, __methodptr(SynElapsedHandler)), TimeSpan.FromSeconds((double) Member.RenewTime));
      ((FrameworkElement) this).put_DataContext((object) ClientData.Current.CurrentSite.ActiveRooms);
      ClientData.Current.ChatMessaging.SiteMessageReceived += new EventHandler<MessageEventArgs>(this.SiteMessageReceived);
      ((ContentControl) this.btnNewTemporaryRoom).put_Content((object) ClientData.Current.ChatLabel.NewTemporaryRoomLabel);
    }

    private async void SiteMessageReceived(object sender, MessageEventArgs e)
    {
      ChatMessage message = e.Message;
      if (message.Header.MessageType == MessageType.ChannelAdvertise)
      {
        try
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: method pointer
          UICore.UpdateUIThread(new DispatchedHandler((object) new RoomPanel.\u003C\u003Ec__DisplayClass2_0()
          {
            room = JsonSerialization.JsonToObject<Room>(message.Body)
          }, __methodptr(\u003CSiteMessageReceived\u003Eb__0)), ((DependencyObject) this).Dispatcher);
        }
        catch (Exception ex)
        {
          Util.LogEvent(ex.Message);
          if (!Setting.Current.IsDebugMode)
            return;
          ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.System, ex));
          ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.System, new Exception(message.Body), "1"));
        }
      }
      else
      {
        if (message.Header.MessageType != MessageType.ChannelUpdate)
          return;
        try
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          RoomPanel.\u003C\u003Ec__DisplayClass2_1 cDisplayClass21 = new RoomPanel.\u003C\u003Ec__DisplayClass2_1()
          {
            room = JsonSerialization.JsonToObject<Room>(message.Body)
          };
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          cDisplayClass21.existingRoom = ClientData.Current.CurrentSite.ActiveRooms.FirstOrDefault<Room>(new Func<Room, bool>(cDisplayClass21.\u003CSiteMessageReceived\u003Eb__1));
          // ISSUE: method pointer
          UICore.UpdateUIThread(new DispatchedHandler((object) cDisplayClass21, __methodptr(\u003CSiteMessageReceived\u003Eb__2)), ((DependencyObject) this).Dispatcher);
        }
        catch (Exception ex)
        {
          Util.LogEvent(ex.Message);
          if (!Setting.Current.IsDebugMode)
            return;
          ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.System, ex));
          ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.System, new Exception(message.Body), "2"));
        }
      }
    }

    private void btnNewTemporaryRoom_Click(object sender, RoutedEventArgs e)
    {
      if (ClientData.Current.CurrentSite.ReachedTempRoomLimit())
        return;
      Util.LogEvent("Temporary Room Created");
      Room temporaryRoom = Room.CreateTemporaryRoom(ClientData.Current.ChatMessaging);
      ClientData.Current.CurrentSite.Enter(temporaryRoom);
      ClientData.Current.CurrentSite.SwitchRoom(temporaryRoom, ClientData.Current.MySelf);
      ClientData.Current.CurrentSite.AdvertiseRoom(temporaryRoom);
      ((Selector) this.lbRooms).put_SelectedItem((object) temporaryRoom);
      if (!ClientData.Current.CurrentSite.ReachedTempRoomLimit())
        return;
      ((Control) this.btnNewTemporaryRoom).put_IsEnabled(false);
      ((ContentControl) this.btnNewTemporaryRoom).put_Content((object) ClientData.Current.ChatLabel.MaxRoomLabel);
    }

    protected async void SynElapsedHandler(ThreadPoolTimer timer)
    {
      if (!ClientData.Current.ChatMessaging.IsBroadcastSetup)
        return;
      ClientData.Current.CurrentSite.AdvertiseRooms();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      UICore.UpdateUIThread(RoomPanel.\u003C\u003Ec.\u003C\u003E9__4_0 ?? (RoomPanel.\u003C\u003Ec.\u003C\u003E9__4_0 = new DispatchedHandler((object) RoomPanel.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CSynElapsedHandler\u003Eb__4_0))), ((DependencyObject) this).Dispatcher);
      if (ClientData.Current.CurrentRoom.Host == null || !(ClientData.Current.CurrentRoom.Host.IPAddress == ClientData.Current.MySelf.IPAddress))
        return;
      ClientData.Current.CurrentRoom.SendRoomUpdate();
    }

    private async void lbRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!(((Selector) this.lbRooms).SelectedItem is Room selectedItem) || ClientData.Current.CurrentRoom.Equals((object) selectedItem))
        return;
      ClientData.Current.CurrentSite.SwitchRoom(selectedItem, ClientData.Current.MySelf);
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///RoomPanel.xaml"), (ComponentResourceLocation) 0);
      this.lbRooms = (ListBox) ((FrameworkElement) this).FindName("lbRooms");
      this.btnNewTemporaryRoom = (Button) ((FrameworkElement) this).FindName("btnNewTemporaryRoom");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          Selector selector = (Selector) target;
          WindowsRuntimeMarshal.AddEventHandler<SelectionChangedEventHandler>(new Func<SelectionChangedEventHandler, EventRegistrationToken>(selector.add_SelectionChanged), new Action<EventRegistrationToken>(selector.remove_SelectionChanged), new SelectionChangedEventHandler(this.lbRooms_SelectionChanged));
          break;
        case 2:
          ButtonBase buttonBase = (ButtonBase) target;
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase.add_Click), new Action<EventRegistrationToken>(buttonBase.remove_Click), new RoutedEventHandler(this.btnNewTemporaryRoom_Click));
          break;
      }
      this._contentLoaded = true;
    }
  }
}

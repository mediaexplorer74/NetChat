// Decompiled with JetBrains decompiler
// Type: IGM.UI.MainPage
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using weekysoft.store.ChatRoom;
using weekysoft.store.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

#nullable disable
namespace IGM.UI
{
  public sealed class MainPage : Page, IComponentConnector
  {
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private Pivot pvRoom;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private PivotItem piChat;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private PivotItem piPeers;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private PivotItem piRooms;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private PivotItem piFeedback;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;

    public MainPage()
    {
      this.InitializeComponent();
      this.SetupRoom(ClientData.Current.CurrentRoom);
      ((FrameworkElement) this.piRooms).put_DataContext((object) ClientData.Current.CurrentSite.ActiveRooms);
      ClientData.Current.CurrentSite.RoomSwitching += new EventHandler<RoomEventArgs>(this.RoomSwitching);
      this.put_NavigationCacheMode((NavigationCacheMode) 1);
    }

    private async void SetupRoom(Room room)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      MainPage.\u003C\u003Ec__DisplayClass1_0 cDisplayClass10 = new MainPage.\u003C\u003Ec__DisplayClass1_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass10.\u003C\u003E4__this = this;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass10.room = room;
      // ISSUE: reference to a compiler-generated field
      if (!ClientData.Current.CurrentRoom.Equals((object) cDisplayClass10.room))
      {
        ClientData.Current.CurrentRoom.Leave(ClientData.Current.MySelf);
        // ISSUE: reference to a compiler-generated field
        ClientData.Current.CurrentRoom = cDisplayClass10.room;
      }
      ((FrameworkElement) this.piPeers).put_DataContext((object) ClientData.Current.CurrentRoom.ActivePeers);
      // ISSUE: method pointer
      UICore.UpdateUIThread(new DispatchedHandler((object) cDisplayClass10, __methodptr(\u003CSetupRoom\u003Eb__0)), ((DependencyObject) this).Dispatcher);
    }

    private async void RoomSwitching(object sender, RoomEventArgs e)
    {
      this.pvRoom.put_SelectedIndex(0);
      this.SetupRoom(e.ActiveMember);
    }

    protected virtual void OnNavigatedTo(NavigationEventArgs e)
    {
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///MainPage.xaml"), (ComponentResourceLocation) 0);
      this.pvRoom = (Pivot) ((FrameworkElement) this).FindName("pvRoom");
      this.piChat = (PivotItem) ((FrameworkElement) this).FindName("piChat");
      this.piPeers = (PivotItem) ((FrameworkElement) this).FindName("piPeers");
      this.piRooms = (PivotItem) ((FrameworkElement) this).FindName("piRooms");
      this.piFeedback = (PivotItem) ((FrameworkElement) this).FindName("piFeedback");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target) => this._contentLoaded = true;
  }
}

// Decompiled with JetBrains decompiler
// Type: IGM.UI.AttendeePanel
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using weekysoft.store.ChatRoom;
using weekysoft.store.Messaging;
using weekysoft.store.Storage;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace IGM.UI
{
    public sealed partial class AttendeePanel : UserControl//, IComponentConnector
    {
        public static readonly DependencyProperty PeerCountProperty = DependencyProperty.Register(nameof(PeerCount), typeof(int), typeof(AttendeePanel), (PropertyMetadata)null);
        private ThreadPoolTimer _PeriodicTimer;
        //[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        //private ListBox lbPeers;
        //[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        //private bool _contentLoaded;

        public int PeerCount => ((ICollection<object>)((ItemsControl)this.lbPeers).Items).Count;

        public AttendeePanel()
        {
            this.InitializeComponent();
            // ISSUE: method pointer
            this._PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler((object)this, __methodptr(PeerSynElapsedHandler)), TimeSpan.FromSeconds((double)Member.RenewTime));
            ClientData.Current.CurrentRoom.Enter(ClientData.Current.MySelf);
            this.UpdateRoomSettings();
            ClientData.Current.CurrentSite.RoomSwitched += new EventHandler<RoomEventArgs>(this.RoomSwitched);
        }

        private async void UpdateRoomSettings()
        {
            ((FrameworkElement)this).put_DataContext((object)ClientData.Current.CurrentRoom.ActivePeers);
            ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageAck -= new EventHandler<MessageEventArgs>(this.Room_ReceivedMessageAck);
            ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageAck += new EventHandler<MessageEventArgs>(this.Room_ReceivedMessageAck);
            ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageNak -= new EventHandler<MessageEventArgs>(this.Room_ReceivedMessageNak);
            ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageNak += new EventHandler<MessageEventArgs>(this.Room_ReceivedMessageNak);
            ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageSync -= new EventHandler<MessageEventArgs>(this.Room_ReceivedMessageSync);
            ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageSync += new EventHandler<MessageEventArgs>(this.Room_ReceivedMessageSync);
        }

        private async void RoomSwitched(object sender, RoomEventArgs e) => this.UpdateRoomSettings();

        private async void Room_ReceivedMessageSync(object sender, MessageEventArgs e)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: method pointer
            UICore.UpdateUIThread(new DispatchedHandler((object)new AttendeePanel.\u003C\u003Ec__DisplayClass7_0()
            {
                e = e
            }, __methodptr(\u003CRoom_ReceivedMessageSync\u003Eb__0)), ((DependencyObject)this).Dispatcher);
        }

        private async void Room_ReceivedMessageNak(object sender, MessageEventArgs e)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: method pointer
            UICore.UpdateUIThread(new DispatchedHandler((object)new AttendeePanel.\u003C\u003Ec__DisplayClass8_0()
            {
                e = e
            }, __methodptr(\u003CRoom_ReceivedMessageNak\u003Eb__0)), ((DependencyObject)this).Dispatcher);
        }

        private async void Room_ReceivedMessageAck(object sender, MessageEventArgs e)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: method pointer
            UICore.UpdateUIThread(new DispatchedHandler((object)new AttendeePanel.\u003C\u003Ec__DisplayClass9_0()
            {
                e = e
            }, __methodptr(\u003CRoom_ReceivedMessageAck\u003Eb__0)), ((DependencyObject)this).Dispatcher);
        }

        protected async void PeerSynElapsedHandler(ThreadPoolTimer timer)
        {
            if (!ClientData.Current.ChatMessaging.IsBroadcastSetup)
                return;
            ClientData.Current.ChatMessaging.Ack(ClientData.Current.CurrentRoom.RoomId);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: method pointer
            UICore.UpdateUIThread(AttendeePanel.\u003C\u003Ec.\u003C\u003E9__10_0 ?? (AttendeePanel.\u003C\u003Ec.\u003C\u003E9__10_0 = new DispatchedHandler((object)AttendeePanel.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CPeerSynElapsedHandler\u003Eb__10_0))), ((DependencyObject)this).Dispatcher);
        }

        protected async void Attendee_PeerListUpdated(object sender, PeerEventArgs e)
        {
            // ISSUE: method pointer
            UICore.UpdateUIThread(new DispatchedHandler((object)this, __methodptr(\u003CAttendee_PeerListUpdated\u003Eb__11_0)), ((DependencyObject)this).Dispatcher);
        }
              
    }
}

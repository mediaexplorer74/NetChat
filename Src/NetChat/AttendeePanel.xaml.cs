using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.CodeDom.Compiler;
using System.Diagnostics;
using weekysoft.store.ChatRoom;
using weekysoft.store.Messaging;
using weekysoft.store.Storage;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml.Markup;

namespace IGM.UI
{
    public partial class AttendeePanel : UserControl//, IComponentConnector
    {
        public static readonly DependencyProperty PeerCountProperty 
            = DependencyProperty.Register(nameof(PeerCount), typeof(int),
                typeof(AttendeePanel), (PropertyMetadata)null);

        private ThreadPoolTimer _PeriodicTimer;
        
     
        public int PeerCount => ((ICollection<object>)((ItemsControl)this.lbPeers).Items).Count;

        public AttendeePanel()
        {
            this.InitializeComponent();
            // Replacing method pointer with lambda expression
            this._PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(async (timer) =>
            {
                PeerSynElapsedHandler(timer);
            }, TimeSpan.FromSeconds((double)Member.RenewTime));

            // TODO
            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                ClientData.Current.CurrentRoom.Enter(ClientData.Current.MySelf);
                this.UpdateRoomSettings();
                ClientData.Current.CurrentSite.RoomSwitched += new EventHandler<RoomEventArgs>(this.RoomSwitched);
            }
            else
            {
                // Handle the null case, e.g., log an error or throw a more informative exception
                Debug.WriteLine("[error] AttendeePanel: ClientData.Current is null");
            }
        }

        private async void UpdateRoomSettings()
        {
            ((FrameworkElement)this).DataContext = (object)ClientData.Current.CurrentRoom.ActivePeers;
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
            // Replacing compiler-generated type and method pointer with lambda expression
            UICore.UpdateUIThread(() =>
            {
                // Process the received message sync event
                if (e != null && e.Message != null)
                {
                    // Handle the message sync logic here
                }
            }, this.Dispatcher);
        }

        private async void Room_ReceivedMessageNak(object sender, MessageEventArgs e)
        {
            // Replacing compiler-generated type and method pointer with lambda expression
            UICore.UpdateUIThread(() =>
            {
                // Process the received message NAK event
                if (e != null && e.Message != null)
                {
                    // Handle the message NAK logic here
                }
            }, this.Dispatcher);
        }

        private async void Room_ReceivedMessageAck(object sender, MessageEventArgs e)
        {
            // Replacing compiler-generated type and method pointer with lambda expression
            UICore.UpdateUIThread(() =>
            {
                // Process the received message ACK event
                if (e != null && e.Message != null)
                {
                    // Handle the message ACK logic here
                }
            }, this.Dispatcher);
        }

        protected async void PeerSynElapsedHandler(ThreadPoolTimer timer)
        {
            // TODO
            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                if (!ClientData.Current.ChatMessaging.IsBroadcastSetup)
                    return;
                ClientData.Current.ChatMessaging.Ack(ClientData.Current.CurrentRoom.RoomId);
            }

            UICore.UpdateUIThread(() =>
            {
                // Handle peer sync elapsed logic here
            }, this.Dispatcher);
        }

        protected async void Attendee_PeerListUpdated(object sender, PeerEventArgs e)
        {
            // Replacing method pointer with lambda expression
            UICore.UpdateUIThread(() =>
            {
                // Handle peer list updated logic here
            }, this.Dispatcher);
        }

       
    }
}
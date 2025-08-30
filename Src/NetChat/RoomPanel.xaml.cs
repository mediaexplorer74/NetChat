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
using weekysoft.store.Chatting;
using weekysoft.store.Messaging;
using weekysoft.store.Serializer;
using weekysoft.store.Storage;
using Windows.System.Threading;
using Windows.UI.Core;

using Windows.UI.Xaml.Markup;

namespace IGM.UI
{
    public partial class RoomPanel : UserControl
    {
        private ThreadPoolTimer _PeriodicTimer;

       
        public RoomPanel()
        {
            this.InitializeComponent();

            // Replacing method pointer with lambda expression
            this._PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(async (timer) =>
            {
                SynElapsedHandler(timer);
            }, TimeSpan.FromSeconds((double)Member.RenewTime));

            // TODO: del if ... else (nulled ClientData.Current problem, heh!)
            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                this.DataContext = (object)ClientData.Current.CurrentSite.ActiveRooms;

                ClientData.Current.ChatMessaging.SiteMessageReceived
                    += new EventHandler<MessageEventArgs>(this.SiteMessageReceived);

                this.btnNewTemporaryRoom.Content = (object)ClientData.Current.ChatLabel.NewTemporaryRoomLabel;
            }
            else
            {
                // Handle the null case, e.g., log an error or throw a more informative exception
                Debug.WriteLine("[error] RoomPanel: ClientData.Current is null");
            }
        }

        private async void SiteMessageReceived(object sender, MessageEventArgs e)
        {
            ChatMessage message = e.Message;
            if (message.Header.MessageType == MessageType.ChannelAdvertise)
            {
                try
                {
                    // Replacing compiler-generated type and method pointer with lambda expression
                    UICore.UpdateUIThread(() =>
                    {
                        Room room = JsonSerialization.JsonToObject<Room>(message.Body);
                        // Handle the room advertisement logic here
                    }, ((DependencyObject)this).Dispatcher);
                }
                catch (Exception ex)
                {
                    Util.LogEvent(ex.Message);
                    if (!Setting.Current.IsDebugMode)
                        return;
                    ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.System, ex));
                    ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.System, 
                        new Exception(message.Body), "1"));
                }
            }
            else
            {
                if (message.Header.MessageType != MessageType.ChannelUpdate)
                    return;
                try
                {
                    // Replacing compiler-generated type with direct implementation
                    Room room = JsonSerialization.JsonToObject<Room>(message.Body);
                    Room existingRoom = ClientData.Current.CurrentSite.ActiveRooms.FirstOrDefault<Room>(r => r.RoomId == room.RoomId);
                    
                    // Replacing method pointer with lambda expression
                    UICore.UpdateUIThread(() =>
                    {
                        // Handle the room update logic here
                        if (existingRoom != null)
                        {
                            // Update existing room
                        }
                        else
                        {
                            // Add new room
                        }
                    }, this.Dispatcher);
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
            ((Selector)this.lbRooms).SelectedItem = (object)temporaryRoom;
            if (!ClientData.Current.CurrentSite.ReachedTempRoomLimit())
                return;
            ((Control)this.btnNewTemporaryRoom).IsEnabled = false;
            ((ContentControl)this.btnNewTemporaryRoom).Content = (object)ClientData.Current.ChatLabel.MaxRoomLabel;
        }

        protected async void SynElapsedHandler(ThreadPoolTimer timer)
        {
            //TODO
            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                if (!ClientData.Current.ChatMessaging.IsBroadcastSetup)
                    return;

                ClientData.Current.CurrentSite.AdvertiseRooms();
            }
            
            UICore.UpdateUIThread(() =>
            {
                // Handle sync elapsed logic here
            }, ((DependencyObject)this).Dispatcher);

            //TODO
            if (ClientData.Current != null && ClientData.Current.CurrentRoom != null && ClientData.Current.MySelf != null)
            {
                if (ClientData.Current.CurrentRoom.Host == null 
                    || !(ClientData.Current.CurrentRoom.Host.IPAddress == ClientData.Current.MySelf.IPAddress))
                    return;

                ClientData.Current.CurrentRoom.SendRoomUpdate();
            }
        }

        private async void lbRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(((Selector)this.lbRooms).SelectedItem is Room selectedItem) || ClientData.Current.CurrentRoom.Equals((object)selectedItem))
                return;
            ClientData.Current.CurrentSite.SwitchRoom(selectedItem, ClientData.Current.MySelf);
        }
     
    }
}
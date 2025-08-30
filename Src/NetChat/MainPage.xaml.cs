using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using weekysoft.store.ChatRoom;
using weekysoft.store.Storage;


namespace IGM.UI
{
    public sealed partial class MainPage
    {
        
        public MainPage()
        {
            this.InitializeComponent();
                        
            this.SetupRoom(ClientData.Current.CurrentRoom);
            this.piRooms.DataContext = (object)ClientData.Current.CurrentSite.ActiveRooms;
            ClientData.Current.CurrentSite.RoomSwitching += new EventHandler<RoomEventArgs>(this.RoomSwitching);
            
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void SetupRoom(Room room)
        {
            // Replacing compiler-generated type with direct implementation
            if (!ClientData.Current.CurrentRoom.Equals((object)room))
            {
                ClientData.Current.CurrentRoom.Leave(ClientData.Current.MySelf);
                ClientData.Current.CurrentRoom = room;
            }
            this.piPeers.DataContext = (object)ClientData.Current.CurrentRoom.ActivePeers;
            
            // Replacing method pointer with lambda expression
            UICore.UpdateUIThread(() =>
            {
                // Handle setup room UI updates here
            }, this.Dispatcher);
        }

        private async void RoomSwitching(object sender, RoomEventArgs e)
        {
            this.pvRoom.SelectedIndex = 0;
            this.SetupRoom(e.ActiveMember);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

       
    }
}
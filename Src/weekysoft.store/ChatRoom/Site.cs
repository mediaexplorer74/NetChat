// Decompiled with JetBrains decompiler
// Type: weekysoft.store.ChatRoom.Site
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;
using weekysoft.store.Messaging;
using weekysoft.store.Serializer;


namespace weekysoft.store.ChatRoom
{
  public class Site : INotifyPropertyChanged
  {
    public ObservableCollection<Room> ActiveRooms = new ObservableCollection<Room>();

    public string SiteId { get; private set; }

    public IMessaging ChatMessaging { get; private set; }

    public EventHandler<RoomEventArgs> RoomListUpdated { get; set; }

    public EventHandler<RoomEventArgs> RoomSwitched { get; set; }

    public EventHandler<RoomEventArgs> RoomSwitching { get; set; }

    public int RoomCount { get; private set; }

    public Site(string siteId, IMessaging messaging)
    {
      this.SiteId = siteId;
      this.ChatMessaging = messaging;
      this.RoomCount = 0;
    }

    public int CreatedRoomCount(RoomType type)
    {
      return this.ActiveRooms.Where<Room>((Func<Room, bool>) (s => s.Type == type && s.Owner.IPAddress == this.ChatMessaging.Host)).Count<Room>();
    }

    public bool ReachedTempRoomLimit() => this.CreatedRoomCount(RoomType.Temp) >= 2;

    public async void SwitchRoom(Room r, Peer myself)
    {
      this.OnRoomSwitching(new RoomEventArgs(r, MemberAction.Switch));
      r.Enter(myself);
      r.ChatMessaging.Channel = r.RoomId;
      this.OnRoomSwitched(new RoomEventArgs(r, MemberAction.Switch));
    }

    private void OnRoomSwitching(RoomEventArgs e)
    {
      EventHandler<RoomEventArgs> roomSwitching = this.RoomSwitching;
      if (roomSwitching == null)
        return;
      roomSwitching((object) this, e);
    }

    private async void OnRoomSwitched(RoomEventArgs e)
    {
      EventHandler<RoomEventArgs> roomSwitched = this.RoomSwitched;
      if (roomSwitched == null)
        return;
      roomSwitched((object) this, e);
    }

    public async void RefreshSignals()
    {
      foreach (Room activeRoom in (Collection<Room>) this.ActiveRooms)
        activeRoom.CalculateSignal(Member.TimeOut, Member.RenewTime, activeRoom.Owner.IPAddress == this.ChatMessaging.Host);
    }

    public async void RemoveInactiveRooms()
    {
      lock (this.ActiveRooms)
      {
        if (!this.ActiveRooms.Any<Room>((Func<Room, bool>) (s => s.ActiveTime < DateTime.Now.AddSeconds((double) -Member.TimeOut) && s.Owner.IPAddress != this.ChatMessaging.Host)))
          return;
        foreach (Room room in this.ActiveRooms.Where<Room>((Func<Room, bool>) (s => s.ActiveTime < DateTime.Now.AddSeconds((double) -Member.TimeOut) && s.Owner.IPAddress != this.ChatMessaging.Host)).ToList<Room>())
        {
          this.ActiveRooms.Remove(room);
          this.OnRoomListUpdated(new RoomEventArgs(room, MemberAction.Leave));
        }
      }
    }

    protected async void OnRoomListUpdated(RoomEventArgs e)
    {
      EventHandler<RoomEventArgs> roomListUpdated = this.RoomListUpdated;
      if (roomListUpdated != null)
        roomListUpdated((object) this, e);
      this.RoomCount = this.ActiveRooms.Count<Room>();
      this.NotifyPropertyChanged("RoomCount");
      this.SyncRoomSignal(e);
    }

    private void SyncRoomSignal(RoomEventArgs e)
    {
      if (e.Action == MemberAction.Enter)
      {
        e.ActiveMember.RestoreSignalStat(e.ActiveMember.Host?.IPAddress == this.ChatMessaging.Host);
      }
      else
      {
        if (e.Action != MemberAction.Leave)
          return;
        e.ActiveMember.UpdateSignalStat();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    public void LobbyBotEnter(Peer bot)
    {
      this.ActiveRooms.FirstOrDefault<Room>((Func<Room, bool>) (s => s.RoomId == SuperChannel.Lobby.GetKey()))?.Enter(bot);
    }

    public void LobbyBotLeave(Peer bot)
    {
      this.ActiveRooms.FirstOrDefault<Room>((Func<Room, bool>) (s => s.RoomId == SuperChannel.Lobby.GetKey()))?.Leave(bot);
    }

    public async void Enter(Room room)
    {
      lock (this.ChatMessaging)
      {
        Room room1 = this.ActiveRooms.FirstOrDefault<Room>((Func<Room, bool>) (s => s.Equals((object) room)));
        if (room1 == null)
        {
          room.ActiveTime = DateTime.Now;
          room.ChatMessaging = this.ChatMessaging;
          this.ActiveRooms.Add(room);
          this.OnRoomListUpdated(new RoomEventArgs(room, MemberAction.Enter));
        }
        else if (room1.ActiveTime <= DateTime.Now.AddSeconds((double) -Member.TimeOut))
        {
          room1.ActiveTime = DateTime.Now;
          this.OnRoomListUpdated(new RoomEventArgs(room1, MemberAction.Enter));
          this.NotifyPropertyChanged("ActiveRooms");
        }
        else
          room1.ActiveTime = DateTime.Now;
      }
    }

    public async void Leave(Room room)
    {
      lock (this.ChatMessaging)
      {
        Room room1 = this.ActiveRooms.FirstOrDefault<Room>((Func<Room, bool>) (s => s.Equals((object) room)));
        if (room1 == null)
          return;
        this.OnRoomListUpdated(new RoomEventArgs(room1, MemberAction.Leave));
        this.ActiveRooms.Remove(room1);
      }
    }

    public async Task<ChatMessage> SendMessage(string msg)
    {
      ChatMessage content;
      if (this.ChatMessaging.IsBroadcastSetup)
      {
        content = new ChatMessage(this.ChatMessaging.ProtocolVersion, this.SiteId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg);
        this.ChatMessaging.SendMessage(content);
      }
      else
      {
        content = new ChatMessage(this.ChatMessaging.ProtocolVersion, this.SiteId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg);
        this.ChatMessaging.SendMessage(content);
      }
      return content;
    }

    public async void AdvertiseRooms()
    {
      lock (this.ActiveRooms)
      {
        foreach (Room r in this.ActiveRooms.Where<Room>((Func<Room, bool>) (s => s.Owner.IPAddress == this.ChatMessaging.Host && s.RoomId != SuperChannel.Lobby.GetKey())))
          this.AdvertiseRoom(r);
      }
    }

    public async void AdvertiseRoom(Room r)
    {
      this.ChatMessaging.SendMessage(new ChatMessage(this.ChatMessaging.ProtocolVersion, this.SiteId, MessageType.ChannelAdvertise, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, JsonSerialization.ObjectToJson<Room>(r)));
    }

    public async void Greet(Room room) => this.Enter(room);

    public ChatMessage CreateProtocolMismatchMessage()
    {
      return this.CreateMessage("Protocol Mismatch. Please update your app to the latest version. If problem persists, please uninstall and reinstall your app.");
    }

    public ChatMessage CreateMessage(string msg)
    {
      return new ChatMessage(this.ChatMessaging.ProtocolVersion, this.SiteId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg);
    }
  }
}

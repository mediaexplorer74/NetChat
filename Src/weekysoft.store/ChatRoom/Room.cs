// Decompiled with JetBrains decompiler
// Type: weekysoft.store.ChatRoom.Room
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;
using weekysoft.store.Messaging;
using weekysoft.store.Serializer;
using weekysoft.store.Util;


namespace weekysoft.store.ChatRoom
{
  [DataContract]
  public class Room : Member
  {
    private ObservableCollection<Peer> _ActivePeers;

    protected override string Id => this.RoomId;

    private DateTime _AckTime { get; set; }

    [DataMember(Name = "I")]
    public string RoomId { get; protected set; }

    [DataMember(Name = "N")]
    public string RoomName { get; protected set; }

    private string _Key { get; set; }

    [DataMember(Name = "M")]
    protected int MaxAttendees { get; set; }

    [DataMember(Name = "O")]
    public Peer Owner { get; protected set; }

    public Peer Host
    {
      get
      {
        return this.ActivePeers.OrderBy<Peer, string>((Func<Peer, string>) (s => s.IPAddress)).FirstOrDefault<Peer>();
      }
    }

    [DataMember(Name = "A")]
    public bool IsActive { get; set; }

    public static Room CreateTemporaryRoom(IMessaging messaging)
    {
      string uniqueId = Base64Util.GenerateUniqueId(messaging.Host);
      return new Room(uniqueId, string.Format("{0}.{1}.temp", (object) uniqueId, (object) messaging.UserName?.Replace(" ", "")), "", 2, messaging, RoomType.Temp);
    }

    [DataMember(Name = "T")]
    public RoomType Type { get; protected set; }

    public IMessaging ChatMessaging { get; set; }

    public EventHandler<PeerEventArgs> PeerListUpdated { get; set; }

    [DataMember(Name = "C")]
    public int PeerCount { get; protected set; }

    public Room(
      string roomId,
      string roomName,
      string key,
      int maxAttendees,
      IMessaging messaging,
      RoomType type = RoomType.Public)
    {
      this.RoomId = roomId;
      this.RoomName = roomName;
      this._Key = key;
      this.MaxAttendees = maxAttendees;
      this._AckTime = DateTime.Now;
      this.Type = type;
      this.ChatMessaging = messaging;
      this.ChatMessaging.Channel = this.RoomId;
      this.Owner = new Peer(messaging.Host, messaging.UserName);
      this.IsSpeakEnabled = false;
      this.PeerCount = 0;
      this.ActiveTime = DateTime.Now;
      this.CalculateSignal(Member.TimeOut, Member.RenewTime, true);
    }

    public bool Has(Peer peer)
    {
      return this.ActivePeers.Any<Peer>((Func<Peer, bool>) (s => s.Equals((object) peer)));
    }

    public Room() => this.PeerCount = 0;

    public void UpdatePeerCount(int peerCount)
    {
      if (this.PeerCount == peerCount)
        return;
      this.PeerCount = peerCount;
      this.NotifyPropertyChanged("PeerCount");
    }

    public async void RefreshSignals()
    {
      foreach (Peer activePeer in (Collection<Peer>) this.ActivePeers)
        activePeer.CalculateSignal(Member.TimeOut, Member.RenewTime, activePeer.IPAddress == this.ChatMessaging.Host || activePeer.IsBot);
    }

    public async void RemoveInactivePeers()
    {
      lock (this.ActivePeers)
      {
        if (!this.ActivePeers.Any<Peer>((Func<Peer, bool>) (s => s.ActiveTime < DateTime.Now.AddSeconds((double) -Member.TimeOut) && s.IPAddress != this.ChatMessaging.Host && !s.IsBot)))
          return;
        foreach (Peer peer in this.ActivePeers.Where<Peer>((Func<Peer, bool>) (s => s.ActiveTime < DateTime.Now.AddSeconds((double) -Member.TimeOut) && s.IPAddress != this.ChatMessaging.Host && !s.IsBot)).ToList<Peer>())
        {
          this.ActivePeers.Remove(peer);
          this.OnPeerListUpdated(new PeerEventArgs(peer, MemberAction.Leave));
        }
      }
    }

    protected async void OnPeerListUpdated(PeerEventArgs e)
    {
      EventHandler<PeerEventArgs> peerListUpdated = this.PeerListUpdated;
      if (peerListUpdated != null)
        peerListUpdated((object) this, e);
      this.PeerCount = this.ActivePeers.Count<Peer>();
      this.NotifyPropertyChanged("PeerCount");
      this.SyncPeerSignal(e);
      if (this.Host != null)
        return;
      this.SendRoomUpdate();
    }

    private void SyncPeerSignal(PeerEventArgs e)
    {
      if (e.Action == MemberAction.Enter)
      {
        e.ActivePeer.RestoreSignalStat(e.ActivePeer.IPAddress == this.ChatMessaging.Host);
      }
      else
      {
        if (e.Action != MemberAction.Leave)
          return;
        e.ActivePeer.UpdateSignalStat();
      }
    }

    public int RecipientCount()
    {
      return this.ActivePeers.Where<Peer>((Func<Peer, bool>) (s => !s.IsBot && s.IPAddress != this.ChatMessaging.Host)).Count<Peer>();
    }

    public ObservableCollection<Peer> ActivePeers
    {
      get
      {
        if (this._ActivePeers == null)
          this._ActivePeers = new ObservableCollection<Peer>();
        return this._ActivePeers;
      }
      set => this._ActivePeers = value;
    }

    public async void Enter(Peer peer)
    {
      lock (this.ChatMessaging)
      {
        Peer peer1 = this.ActivePeers.FirstOrDefault<Peer>((Func<Peer, bool>) (s => s.Equals((object) peer)));
        if (peer1 == null)
        {
          if (peer.IPAddress == this.ChatMessaging.Host)
          {
            this.ChatMessaging.Syn(this.RoomId);
            this.IsActive = true;
          }
          peer.ActiveTime = DateTime.Now;
          this.ActivePeers.Add(peer);
          this.OnPeerListUpdated(new PeerEventArgs(peer, MemberAction.Enter));
        }
        else if (peer1.ActiveTime <= DateTime.Now.AddSeconds((double) -Member.TimeOut))
        {
          peer1.ActiveTime = DateTime.Now;
          this.OnPeerListUpdated(new PeerEventArgs(peer1, MemberAction.Enter));
          this.NotifyPropertyChanged("ActivePeers");
        }
        else
          peer1.ActiveTime = DateTime.Now;
      }
    }

    public async void Leave(Peer peer)
    {
      lock (this.ChatMessaging)
      {
        Peer peer1 = this.ActivePeers.FirstOrDefault<Peer>((Func<Peer, bool>) (s => s.Equals((object) peer)));
        if (peer1 == null)
          return;
        if (peer1.IPAddress == this.ChatMessaging.Host)
        {
          this.ChatMessaging.Nak(this.RoomId);
          this.IsActive = false;
        }
        this.ActivePeers.Remove(peer1);
        this.OnPeerListUpdated(new PeerEventArgs(peer1, MemberAction.Leave));
      }
    }

    public async void SendRoomUpdate()
    {
      this.ChatMessaging.SendMessage(new ChatMessage(this.ChatMessaging.ProtocolVersion, SuperChannel.Site.GetKey(), MessageType.ChannelUpdate, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, JsonSerialization.ObjectToJson<Room>(this)));
    }

    public async Task<ChatMessage> SendMessage(string msg)
    {
      ChatMessage content;
      if (this.ChatMessaging.IsBroadcastSetup)
      {
        content = new ChatMessage(this.ChatMessaging.ProtocolVersion, this.RoomId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg, expectedRecipients: this.RecipientCount());
        this.ChatMessaging.SendMessage(content);
      }
      else
      {
        content = new ChatMessage(this.ChatMessaging.ProtocolVersion, this.RoomId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg);
        this.ChatMessaging.SendMessage(content);
      }
      return content;
    }

    public async void Greet(Peer peer) => this.Enter(peer);

    public ChatMessage CreateProtocolMismatchMessage()
    {
      return this.CreateMessage("Protocol Mismatch. Please update your app to the latest version. If problem persists, please uninstall and reinstall your app.");
    }

    public ChatMessage CreateBotMessage(string msg, Peer bot, Gender gender)
    {
      return new ChatMessage(this.ChatMessaging.ProtocolVersion, this.RoomId, MessageType.Text, bot.IPAddress, bot.DisplayName, DateTime.Now, msg)
      {
        Header = {
          SenderGender = gender.GetKey()
        }
      };
    }

    public ChatMessage CreateMessage(string msg)
    {
      return new ChatMessage(this.ChatMessaging.ProtocolVersion, this.RoomId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg);
    }

    public ChatMessage CreateErrorMessage(string msg)
    {
      ChatMessage errorMessage = new ChatMessage(this.ChatMessaging.ProtocolVersion, this.RoomId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg);
      errorMessage.IsErrorMessage = true;
      errorMessage.Header.AssignErrorMessageId();
      return errorMessage;
    }

    public ChatMessage CreateBannerMessage(string msg)
    {
      return new ChatMessage(this.ChatMessaging.ProtocolVersion, this.RoomId, MessageType.Text, this.ChatMessaging.Host, this.ChatMessaging.UserName, DateTime.Now, msg)
      {
        IsBanner = true
      };
    }

    public bool IsSpeakEnabled { get; set; }

    public override bool Equals(object obj) => this.RoomId == ((Room) obj).RoomId;
  }
}

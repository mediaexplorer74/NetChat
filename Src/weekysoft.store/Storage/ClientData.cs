// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Storage.ClientData
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using weekysoft.store.Bots;
using weekysoft.store.ChatRoom;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;
using weekysoft.store.Interfaces;
using weekysoft.store.Messaging;

#nullable disable
namespace weekysoft.store.Storage
{
  public class ClientData
  {
    private Room _CurrentRoom;
    private Peer _LobbyBot;
    private Site _CurrentSite;
    private Peer _MySelf;
    private IBot _Assistant;
    private List<string> _CommentTypes;
    private ChatLabel _ChatLabel;
    private ObservableCollection<ChatMessage> _Messages;

    public ClientData(IMessaging messaging) => this.ChatMessaging = messaging;

    public static ClientData Current { get; set; }

    public Room CurrentRoom
    {
      get
      {
        if (this._CurrentRoom == null)
        {
          this._CurrentRoom = new Room(SuperChannel.Lobby.GetKey(), this.ChatLabel.LobbyLabel, "secured", 250, this.ChatMessaging);
          this.CurrentSite.Enter(this._CurrentRoom);
          if (Setting.Current.IsAssistantEnabled)
            this._CurrentRoom.Enter(this.LobbyBot);
        }
        return this._CurrentRoom;
      }
      set => this._CurrentRoom = value;
    }

    public Peer LobbyBot
    {
      get
      {
        if (this._LobbyBot == null)
          this._LobbyBot = new Peer("127.0.0.2", this.ChatLabel.ReceptionistLabel + " (Bot)", true);
        return this._LobbyBot;
      }
    }

    public Site CurrentSite
    {
      get
      {
        if (this._CurrentSite == null)
          this._CurrentSite = new Site(SuperChannel.Site.GetKey(), this.ChatMessaging);
        return this._CurrentSite;
      }
      set => this._CurrentSite = value;
    }

    public Peer MySelf
    {
      get
      {
        if (this._MySelf == null)
        {
          this._MySelf = new Peer(this.ChatMessaging.Host, this.ChatMessaging.UserName);
          this._MySelf.CalculateSignal(Member.TimeOut, Member.RenewTime, true);
        }
        return this._MySelf;
      }
      set => this._MySelf = value;
    }

    public IBot Assistant
    {
      get
      {
        if (this._Assistant == null)
          this._Assistant = (IBot) new ReceptionistBot();
        return this._Assistant;
      }
      set => this._Assistant = value;
    }

    public Action<string> UpdateTitle { get; set; }

    public IMessaging ChatMessaging { get; set; }

    public List<string> CommentTypes
    {
      get
      {
        if (this._CommentTypes == null)
          this._CommentTypes = EnumHelper.Members<CommentType>().Select<CommentType, string>((Func<CommentType, string>) (s => s.GetDisplayName())).ToList<string>();
        return this._CommentTypes;
      }
    }

    public IIPAddressManager IPManager { get; set; }

    public ITextToSpeech TextToSpeech { get; set; }

    public IRateApp RateApp { get; set; }

    public ChatLabel ChatLabel
    {
      get
      {
        if (this._ChatLabel == null)
          this._ChatLabel = new ChatLabel(Language.English);
        return this._ChatLabel;
      }
      set => this._ChatLabel = value;
    }

    public ObservableCollection<ChatMessage> Messages
    {
      get
      {
        if (this._Messages == null)
          this._Messages = new ObservableCollection<ChatMessage>();
        else if (this._Messages.Count > 60)
        {
          for (int index = 0; index < 20; ++index)
            this._Messages.RemoveAt(0);
        }
        return this._Messages;
      }
    }
  }
}

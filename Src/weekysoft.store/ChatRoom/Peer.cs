// Decompiled with JetBrains decompiler
// Type: weekysoft.store.ChatRoom.Peer
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Runtime.Serialization;


namespace weekysoft.store.ChatRoom
{
  [DataContract]
  public class Peer : Member
  {
    private string _Host;
    private string _displayName;

    public bool IsBot { get; private set; }

    protected override string Id => this.IPAddress;

    [DataMember(Name = "I")]
    public string IPAddress
    {
      get => this._Host;
      set
      {
        this._Host = value;
        this.NotifyPropertyChanged(nameof (IPAddress));
      }
    }

    [DataMember(Name = "N")]
    public string DisplayName
    {
      get => this._displayName;
      set
      {
        this._displayName = value;
        this.NotifyPropertyChanged(nameof (DisplayName));
      }
    }

    public Peer(string host, string displayName, bool isBot = false)
    {
      this.IPAddress = host;
      this.DisplayName = displayName;
      this.ActiveTime = DateTime.Now;
      this.IsBot = isBot;
    }

    public Peer()
    {
    }

    public override bool Equals(object obj) => this.IPAddress == ((Peer) obj).IPAddress;
  }
}

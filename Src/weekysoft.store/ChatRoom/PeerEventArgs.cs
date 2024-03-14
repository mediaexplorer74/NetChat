// Decompiled with JetBrains decompiler
// Type: weekysoft.store.ChatRoom.PeerEventArgs
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;

#nullable disable
namespace weekysoft.store.ChatRoom
{
  public class PeerEventArgs : EventArgs
  {
    public PeerEventArgs(Peer peer, MemberAction action)
    {
      this.ActivePeer = peer;
      this.Action = action;
    }

    public Peer ActivePeer { get; private set; }

    public MemberAction Action { get; private set; }
  }
}

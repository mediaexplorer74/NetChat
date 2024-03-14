// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.MessageEventArgs
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Chatting;

#nullable disable
namespace weekysoft.store.Messaging
{
  public class MessageEventArgs : DatagramEventArgs
  {
    public MessageEventArgs()
    {
      this.IsValidProtocol = true;
      this.IsValidChannel = true;
      this.IsAlreadyReceived = false;
      this.IsNewerProtocol = false;
    }

    public bool IsValid
    {
      get
      {
        return this.IsValidProtocol && (this.IsValidChannel || this.IsSuperChannel) && !this.IsAlreadyReceived;
      }
    }

    public bool IsValidProtocol { get; set; }

    public bool IsNewerProtocol { get; set; }

    public bool IsValidChannel { get; set; }

    public bool IsAlreadyReceived { get; set; }

    public bool IsSuperChannel { get; set; }

    public ChatMessage Message { get; set; }
  }
}

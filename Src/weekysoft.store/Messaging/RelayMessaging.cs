// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.RelayMessaging
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System.Threading.Tasks;
using weekysoft.store.Chatting;

#nullable disable
namespace weekysoft.store.Messaging
{
  public class RelayMessaging : ReliableMessaging
  {
    public RelayMessaging(
      string sendingPort,
      string[] receivingPorts,
      string broadcastAddress = "255.255.255.255",
      bool ignoreSelf = true,
      int repeatCount = 1,
      int sendBuffer = 60,
      int receiveBuffer = 60,
      int deliveryTimeoutMilSec = 1000,
      int messageDelay = 45,
      bool reconfirm = false)
      : base(sendingPort, receivingPorts, broadcastAddress, ignoreSelf, repeatCount, sendBuffer, receiveBuffer, deliveryTimeoutMilSec, messageDelay, reconfirm)
    {
    }

    protected override async Task HandlePeerConfirmMessage(ChatMessage originalMessage)
    {
      MessageEventArgs e = new MessageEventArgs();
      e.Message = originalMessage;
      e.Sender = originalMessage.Header.SenderIP;
      this.ProcessMessage(e);
      base.HandlePeerConfirmMessage(originalMessage);
    }
  }
}

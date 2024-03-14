// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.IMessaging
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using weekysoft.store.Chatting;
using weekysoft.store.Interfaces;


namespace weekysoft.store.Messaging
{
  public interface IMessaging
  {
    void CleanUp();

    EventHandler<MessageEventArgs> MessageReceived { get; set; }

    bool DetectNetworkChanges(IIPAddressManager manager);

    bool IsListening { get; }

    bool IsBroadcastSetup { get; }

    Task Initialize(IIPAddressManager manager);

    string UserName { get; set; }

    string Channel { get; set; }

    Task SendMessage(ChatMessage content);

    IEnumerable<string> IPAddresses { get; }

    IEnumerable<string> HostNames { get; }

    string Host { get; }

    Task Ack(string roomName);

    Task Syn(string roomName);

    Task Nak(string roomName);

    EventHandler<MessageEventArgs> MessageValidating { get; set; }

    EventHandler<MessageEventArgs> MessageValidated { get; set; }

    EventHandler<MessageEventArgs> MessageConfirmed { get; set; }

    EventHandler<MessageEventArgs> MessageFullyConfirmed { get; set; }

    EventHandler<MessageEventArgs> MessageReconfirmed { get; set; }

    EventHandler<MessageEventArgs> MessageLost { get; set; }

    EventHandler<MessageEventArgs> ConfirmMessageLost { get; set; }

    EventHandler<ErrorEventArgs> MessageReceivedError { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageAck { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageNak { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageSync { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageConfirm { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageText { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageReconfirm { get; set; }

    EventHandler<MessageEventArgs> ReceivedMessageRequest { get; set; }

    EventHandler<MessageEventArgs> ReceivingMessageConfirm { get; set; }

    EventHandler<MessageEventArgs> ReceivingMessageText { get; set; }

    EventHandler<MessageEventArgs> ReceivingMessageReconfirm { get; set; }

    EventHandler<MessageEventArgs> ReceivingMessageRequest { get; set; }

    EventHandler<MessageEventArgs> SiteMessageReceived { get; set; }

    Version ProtocolVersion { get; }

    Task RaiseError(ErrorEventArgs e);
  }
}

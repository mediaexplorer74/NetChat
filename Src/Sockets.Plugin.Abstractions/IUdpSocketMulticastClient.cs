// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.IUdpSocketMulticastClient
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

using System;
using System.Threading.Tasks;


namespace Sockets.Plugin.Abstractions
{
  public interface IUdpSocketMulticastClient : IDisposable
  {
    Task JoinMulticastGroupAsync(string multicastAddress, int port, ICommsInterface multicastOn);

    Task DisconnectAsync();

    Task SendMulticastAsync(byte[] data);

    Task SendMulticastAsync(byte[] data, int length);

    int TTL { get; set; }

    event EventHandler<UdpSocketMessageReceivedEventArgs> MessageReceived;
  }
}

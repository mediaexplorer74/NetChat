// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.IUdpSocketClient
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

using System;
using System.Threading.Tasks;

#nullable disable
namespace Sockets.Plugin.Abstractions
{
  public interface IUdpSocketClient : IDisposable
  {
    Task ConnectAsync(string address, int port);

    Task DisconnectAsync();

    Task SendAsync(byte[] data);

    Task SendAsync(byte[] data, int length);

    Task SendToAsync(byte[] data, string address, int port);

    Task SendToAsync(byte[] data, int length, string address, int port);

    event EventHandler<UdpSocketMessageReceivedEventArgs> MessageReceived;
  }
}

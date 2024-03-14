// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.ITcpSocketClient
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Sockets.Plugin.Abstractions
{
  public interface ITcpSocketClient : IDisposable
  {
    Task ConnectAsync(string address, int port, bool secure = false, CancellationToken cancellationToken = default (CancellationToken));

    Task ConnectAsync(
      string address,
      string service,
      bool secure = false,
      CancellationToken cancellationToken = default (CancellationToken));

    Task DisconnectAsync();

    Task<ICommsInterface> GetConnectedInterfaceAsync();

    Stream ReadStream { get; }

    Stream WriteStream { get; }

    string RemoteAddress { get; }

    int RemotePort { get; }
  }
}

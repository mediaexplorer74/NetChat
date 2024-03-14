﻿// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.ITcpSocketListener
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

using System;
using System.Threading.Tasks;

#nullable disable
namespace Sockets.Plugin.Abstractions
{
  public interface ITcpSocketListener : IDisposable
  {
    Task StartListeningAsync(int port, ICommsInterface listenOn);

    Task StopListeningAsync();

    int LocalPort { get; }

    event EventHandler<TcpSocketListenerConnectEventArgs> ConnectionReceived;
  }
}

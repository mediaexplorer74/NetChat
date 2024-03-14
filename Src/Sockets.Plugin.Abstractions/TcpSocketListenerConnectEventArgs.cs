// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.TcpSocketListenerConnectEventArgs
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

using System;


namespace Sockets.Plugin.Abstractions
{
  public class TcpSocketListenerConnectEventArgs : EventArgs
  {
    private readonly ITcpSocketClient _socketClient;

    public ITcpSocketClient SocketClient => this._socketClient;

    public TcpSocketListenerConnectEventArgs(ITcpSocketClient socketClient)
    {
      this._socketClient = socketClient;
    }
  }
}

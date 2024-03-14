// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.TcpSocketClient
// Assembly: Sockets.Plugin, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 763BC536-8B9B-4259-94CB-494A5A2E7457
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.dll

using Sockets.Plugin.Abstractions;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Sockets.Plugin
{
  public class TcpSocketClient : ITcpSocketClient, IDisposable, IExposeBackingSocket
  {
    public TcpSocketClient()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public TcpSocketClient(int bufferSize)
      : this()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task ConnectAsync(
      string address,
      int port,
      bool secure = false,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task ConnectAsync(
      string address,
      string service,
      bool secure = false,
      CancellationToken cancellationToken = default (CancellationToken))
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task DisconnectAsync()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task<ICommsInterface> GetConnectedInterfaceAsync()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Stream ReadStream
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public Stream WriteStream
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public string RemoteAddress
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public int RemotePort
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public void Dispose()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    object IExposeBackingSocket.Socket
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }
  }
}

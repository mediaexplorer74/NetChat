// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.UdpSocketClient
// Assembly: Sockets.Plugin, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 763BC536-8B9B-4259-94CB-494A5A2E7457
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.dll

using Sockets.Plugin.Abstractions;
using System;
using System.Threading.Tasks;

#nullable disable
namespace Sockets.Plugin
{
  public class UdpSocketClient : UdpSocketBase, IUdpSocketClient, IDisposable
  {
    public Task ConnectAsync(string address, int port)
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task DisconnectAsync()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task SendAsync(byte[] data)
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task SendAsync(byte[] data, int length)
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task SendToAsync(byte[] data, string address, int port)
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public Task SendToAsync(byte[] data, int length, string address, int port)
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
    }

    public event EventHandler<UdpSocketMessageReceivedEventArgs> MessageReceived
    {
      add
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
      remove
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }
  }
}

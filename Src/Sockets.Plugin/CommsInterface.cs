// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.CommsInterface
// Assembly: Sockets.Plugin, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 763BC536-8B9B-4259-94CB-494A5A2E7457
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.dll

using Sockets.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Sockets.Plugin
{
  public class CommsInterface : ICommsInterface
  {
    public string NativeInterfaceId
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
      set
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public string Name
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public string IpAddress
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public string GatewayAddress
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public string BroadcastAddress
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public CommsInterfaceStatus ConnectionStatus
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public bool IsUsable
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public bool IsLoopback
    {
      get
      {
        throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
            "Ensure you have added the Sockets nuget package to each of your platform projects.");
      }
    }

    public static Task<List<CommsInterface>> GetAllInterfacesAsync()
    {
      throw new NotImplementedException("The empty PCL implementation for Sockets was loaded. " +
          "Ensure you have added the Sockets nuget package to each of your platform projects.");
    }
  }
}

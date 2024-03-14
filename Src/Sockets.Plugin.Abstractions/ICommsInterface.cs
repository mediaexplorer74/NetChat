// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.ICommsInterface
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

#nullable disable
namespace Sockets.Plugin.Abstractions
{
  public interface ICommsInterface
  {
    string NativeInterfaceId { get; }

    string Name { get; }

    string IpAddress { get; }

    string GatewayAddress { get; }

    string BroadcastAddress { get; }

    CommsInterfaceStatus ConnectionStatus { get; }

    bool IsUsable { get; }

    bool IsLoopback { get; }
  }
}

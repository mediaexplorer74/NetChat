// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.UdpSocketMessageReceivedEventArgs
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll


namespace Sockets.Plugin.Abstractions
{
  public class UdpSocketMessageReceivedEventArgs
  {
    private readonly string _remotePort;
    private readonly string _remoteAddress;
    private readonly byte[] _byteData;

    public UdpSocketMessageReceivedEventArgs(
      string remoteAddress,
      string remotePort,
      byte[] byteData)
    {
      this._remoteAddress = remoteAddress;
      this._remotePort = remotePort;
      this._byteData = byteData;
    }

    public string RemoteAddress => this._remoteAddress;

    public string RemotePort => this._remotePort;

    public byte[] ByteData => this._byteData;
  }
}

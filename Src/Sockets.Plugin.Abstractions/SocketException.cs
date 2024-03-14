// Decompiled with JetBrains decompiler
// Type: Sockets.Plugin.Abstractions.SocketException
// Assembly: Sockets.Plugin.Abstractions, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null
// MVID: E3B4C827-259B-48F9-BD21-8E2899B308A6
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Sockets.Plugin.Abstractions.dll

using System;

#nullable disable
namespace Sockets.Plugin.Abstractions
{
  public sealed class SocketException : Exception
  {
    public SocketException(Exception innerException)
      : base(innerException.Message, innerException)
    {
    }
  }
}

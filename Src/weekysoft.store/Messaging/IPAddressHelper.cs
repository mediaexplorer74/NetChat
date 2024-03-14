// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Messaging.IPAddressHelper
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace weekysoft.store.Messaging
{
  public static class IPAddressHelper
  {
    public static string[] PrivateAddresses = new string[18]
    {
      "10.",
      "192.168.",
      "172.16.",
      "172.17.",
      "172.18.",
      "172.19.",
      "172.20.",
      "172.21.",
      "172.22.",
      "172.23.",
      "172.24.",
      "172.25.",
      "172.26.",
      "172.27.",
      "172.28.",
      "172.29.",
      "172.30.",
      "172.31."
    };

    public static string GetNetworkAddress(string ip, int maskLen)
    {
      return string.Join("", ((IEnumerable<string>) ip.Split('.')).Select<string, string>((Func<string, string>) (x => Convert.ToString(int.Parse(x), 2).PadLeft(8, '0'))).ToArray<string>()).Substring(0, maskLen);
    }
  }
}

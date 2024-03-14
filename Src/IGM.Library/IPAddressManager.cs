// Decompiled with JetBrains decompiler
// Type: IGM.Library.IPAddressManager
// Assembly: IGM.Library, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 843F6794-B124-487F-905F-30809B16B79B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.Library.dll

using System;
using System.Collections.Generic;
using System.Linq;
using weekysoft.store.Interfaces;
using weekysoft.store.Messaging;
using Windows.Networking;
using Windows.Networking.Connectivity;

#nullable disable
namespace IGM.Library
{
  public class IPAddressManager : IIPAddressManager
  {
    private IEnumerable<string> _IPAddress;

    public IPAddressManager() => this._IPAddress = this.LoadNetworkInterfaces();

    public string Username => throw new NotImplementedException();

    public IEnumerable<string> GetIPAddresses()
    {
      if (this._IPAddress == null)
        this._IPAddress = this.LoadNetworkInterfaces();
      return this._IPAddress;
    }

    public IEnumerable<string> LoadNetworkInterfaces(bool uniqueNetworks = true)
    {
      List<HostName> source1 = new List<HostName>();
      IReadOnlyList<HostName> hostNames = NetworkInformation.GetHostNames();
      List<HostName> hostNameList;
      if (hostNames == null)
      {
        hostNameList = (List<HostName>) null;
      }
      else
      {
        IEnumerable<HostName> source2 = hostNames.Where<HostName>((Func<HostName, bool>) (h => h.IPInformation != null && h.IPInformation?.NetworkAdapter != null && h.Type == 1 && ((IEnumerable<string>) IPAddressHelper.PrivateAddresses).SingleOrDefault<string>((Func<string, bool>) (s => s == h.CanonicalName?.Substring(0, s.Length))) != null));
        hostNameList = source2 != null ? source2.ToList<HostName>() : (List<HostName>) null;
      }
      IEnumerable<HostName> source3 = (IEnumerable<HostName>) hostNameList;
      if (uniqueNetworks)
      {
        foreach (HostName hostName1 in source3)
        {
          string canonicalName = hostName1.CanonicalName;
          IPInformation ipInformation1 = hostName1.IPInformation;
          byte? nullable1;
          byte? nullable2;
          if (ipInformation1 == null)
          {
            nullable1 = new byte?();
            nullable2 = nullable1;
          }
          else
            nullable2 = ipInformation1.PrefixLength;
          nullable1 = nullable2;
          int maskLen = (int) nullable1.Value;
          string network = IPAddressHelper.GetNetworkAddress(canonicalName, maskLen);
          ulong? maxBitsPerSecond1 = hostName1.IPInformation?.NetworkAdapter?.InboundMaxBitsPerSecond;
          HostName hostName2 = source1.FirstOrDefault<HostName>((Func<HostName, bool>) (s => IPAddressHelper.GetNetworkAddress(s.CanonicalName, (int) ((byte?) s.IPInformation?.PrefixLength).Value) == network));
          if (hostName2 == null)
          {
            source1.Add(hostName1);
          }
          else
          {
            IPInformation ipInformation2 = hostName2.IPInformation;
            int num;
            if (ipInformation2 == null)
            {
              num = 0;
            }
            else
            {
              ulong? maxBitsPerSecond2 = ipInformation2.NetworkAdapter?.InboundMaxBitsPerSecond;
              ulong? nullable3 = maxBitsPerSecond1;
              num = maxBitsPerSecond2.GetValueOrDefault() < nullable3.GetValueOrDefault() ? (maxBitsPerSecond2.HasValue & nullable3.HasValue ? 1 : 0) : 0;
            }
            if (num != 0)
              ;
          }
        }
      }
      else
        source1 = source3 != null ? source3.ToList<HostName>() : (List<HostName>) null;
      return source1 == null ? (IEnumerable<string>) null : source1.Select<HostName, string>((Func<HostName, string>) (s => s.CanonicalName));
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBAccessTokenDataStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(3000412687, 44811, 12568, 186, 249, 87, 161, 13, 159, 37, 65)]
  [ExclusiveTo(typeof (FBAccessTokenData))]
  [Version(1)]
  internal interface __IFBAccessTokenDataStatics
  {
    FBAccessTokenData FromUri([In] Uri Response);
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBAccessTokenDataFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [ExclusiveTo(typeof (FBAccessTokenData))]
  [Guid(1562528183, 40160, 16081, 138, 198, 141, 170, 192, 170, 171, 45)]
  internal interface __IFBAccessTokenDataFactory
  {
    [Overload("CreateInstance1")]
    FBAccessTokenData CreateInstance([In] string AccessToken, [In] DateTime Expiration);
  }
}

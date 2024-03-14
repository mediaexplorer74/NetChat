// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBAccessTokenData
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [MarshalingBehavior]
  [Static(typeof (__IFBAccessTokenDataStatics), 1)]
  [Threading]
  [Version(1)]
  [Activatable(typeof (__IFBAccessTokenDataFactory), 1)]
  public sealed class FBAccessTokenData : __IFBAccessTokenDataPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBAccessTokenData FromUri([In] Uri Response);

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBAccessTokenData([In] string AccessToken, [In] DateTime Expiration);

    public extern string AccessToken { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern DateTime ExpirationDate { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern FBPermissions GrantedPermissions { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern FBPermissions DeclinedPermissions { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern bool IsExpired();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void SetPermissions([In] IVectorView<object> perms);
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBSession
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Storage;
using winsdkfb.Graph;

#nullable disable
namespace winsdkfb
{
  [Threading]
  [Version(1)]
  [Static(typeof (__IFBSessionStatics), 1)]
  [MarshalingBehavior]
  public sealed class FBSession : __IFBSessionPublicNonVirtuals
  {
    public extern string FBAppId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string WinAppId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string AppResponse { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool LoggedIn { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern FBAccessTokenData AccessTokenData { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern int APIMajorVersion { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int APIMinorVersion { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern FBUser User { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string WebViewRedirectDomain { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string WebViewRedirectPath { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public static extern FBSession ActiveSession { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public static extern ApplicationDataContainer DataContainer { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncAction LogoutAsync();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowFeedDialogAsync([In] PropertySet Parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowRequestsDialogAsync([In] PropertySet Parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowSendDialogAsync([In] PropertySet Parameters);

    [Overload("LoginAsync1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> LoginAsync(
      [In] FBPermissions Permissions,
      [In] SessionLoginBehavior behavior);

    [Overload("LoginAsync2")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> LoginAsync([In] FBPermissions Permissions);

    [Overload("LoginAsync3")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> LoginAsync();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void SetAPIVersion([In] int MajorVersion, [In] int MinorVersion);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void SetWebViewRedirectUrl([In] string domain, [In] string path);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> TryRefreshAccessToken();
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBSessionPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using winsdkfb.Graph;

#nullable disable
namespace winsdkfb
{
  [Guid(57878180, 57889, 13576, 171, 218, 251, 243, 120, 30, 237, 57)]
  [ExclusiveTo(typeof (FBSession))]
  [Version(1)]
  internal interface __IFBSessionPublicNonVirtuals
  {
    string FBAppId { get; [param: In] set; }

    string WinAppId { get; [param: In] set; }

    string AppResponse { get; }

    bool LoggedIn { get; }

    FBAccessTokenData AccessTokenData { get; [param: In] set; }

    int APIMajorVersion { get; }

    int APIMinorVersion { get; }

    FBUser User { get; }

    string WebViewRedirectDomain { get; }

    string WebViewRedirectPath { get; }

    IAsyncAction LogoutAsync();

    IAsyncOperation<FBResult> ShowFeedDialogAsync([In] PropertySet Parameters);

    IAsyncOperation<FBResult> ShowRequestsDialogAsync([In] PropertySet Parameters);

    IAsyncOperation<FBResult> ShowSendDialogAsync([In] PropertySet Parameters);

    [Overload("LoginAsync3")]
    IAsyncOperation<FBResult> LoginAsync();

    [Overload("LoginAsync2")]
    IAsyncOperation<FBResult> LoginAsync([In] FBPermissions Permissions);

    [Overload("LoginAsync1")]
    IAsyncOperation<FBResult> LoginAsync([In] FBPermissions Permissions, [In] SessionLoginBehavior behavior);

    void SetAPIVersion([In] int MajorVersion, [In] int MinorVersion);

    void SetWebViewRedirectUrl([In] string domain, [In] string path);

    IAsyncOperation<FBResult> TryRefreshAccessToken();
  }
}

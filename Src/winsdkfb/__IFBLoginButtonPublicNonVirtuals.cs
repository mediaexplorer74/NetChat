// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBLoginButtonPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBLoginButton))]
  [Version(1)]
  [Guid(1454772680, 21832, 13696, 169, 108, 121, 95, 212, 83, 206, 59)]
  internal interface __IFBLoginButtonPublicNonVirtuals
  {
    FBPermissions Permissions { get; [param: In] set; }

    void InitWithPermissions([In] FBPermissions permissions);

    event FBLoginErrorHandler FBLoginError;

    event FetchedUserInfoHandler FetchedUserInfo;

    event ShowingLoggedInUserHandler ShowingLoggedInUser;

    event ShowingLoggedOutUserHandler ShowingLoggedOutUser;
  }
}

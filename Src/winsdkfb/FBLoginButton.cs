// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBLoginButton
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace winsdkfb
{
  [WebHostHidden]
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  [Activatable(1)]
  public sealed class FBLoginButton : 
    Button,
    __IFBLoginButtonPublicNonVirtuals,
    __IFBLoginButtonProtectedNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBLoginButton();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void OnApplyTemplate();

    public extern FBPermissions Permissions { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void InitWithPermissions([In] FBPermissions permissions);

    public extern event FBLoginErrorHandler FBLoginError;

    public extern event FetchedUserInfoHandler FetchedUserInfo;

    public extern event ShowingLoggedInUserHandler ShowingLoggedInUser;

    public extern event ShowingLoggedOutUserHandler ShowingLoggedOutUser;
  }
}

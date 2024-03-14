// Decompiled with JetBrains decompiler
// Type: winsdkfb.FacebookDialog
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace winsdkfb
{
  [WebHostHidden]
  [Static(typeof (__IFacebookDialogStatics), 1)]
  [Activatable(1)]
  [Threading]
  [Version(1)]
  [MarshalingBehavior]
  public sealed class FacebookDialog : 
    UserControl,
    IClosable,
    IComponentConnector,
    IComponentConnector2,
    __IFacebookDialogPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void InitializeComponent();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Connect([In] int connectionId, [In] object target);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IComponentConnector GetBindingConnector([In] int connectionId, [In] object target);

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FacebookDialog();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void InitDialog();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void UninitDialog();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern string GetFBServerUrl();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowLoginDialog([In] PropertySet Parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowFeedDialog([In] PropertySet Parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowRequestsDialog([In] PropertySet Parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> ShowSendDialog([In] PropertySet Parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern void DeleteCookies();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Close();
  }
}

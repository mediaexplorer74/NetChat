// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBAppRequest
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
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  [Static(typeof (__IFBAppRequestStatics), 1)]
  public sealed class FBAppRequest : __IFBAppRequestPublicNonVirtuals
  {
    public extern string RequestId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern IVectorView<string> RecipientIds { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBAppRequest FromRequestDialogResponse([In] Uri Response);
  }
}

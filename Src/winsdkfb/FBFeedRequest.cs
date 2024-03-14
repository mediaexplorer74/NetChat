// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBFeedRequest
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Static(typeof (__IFBFeedRequestStatics), 1)]
  [Threading]
  [Version(1)]
  [MarshalingBehavior]
  public sealed class FBFeedRequest : __IFBFeedRequestPublicNonVirtuals
  {
    public extern string PostId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBFeedRequest FromFeedDialogResponse([In] Uri Response);
  }
}

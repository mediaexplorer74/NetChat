// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBSDKAppEvents
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Activatable(1)]
  [MarshalingBehavior]
  [Threading]
  [Static(typeof (__IFBSDKAppEventsStatics), 1)]
  [Version(1)]
  public sealed class FBSDKAppEvents : __IFBSDKAppEventsPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern void ActivateApp();

    public static extern bool UseSimulator { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBSDKAppEvents();
  }
}

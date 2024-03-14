// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBResult
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Threading]
  [Version(1)]
  [MarshalingBehavior]
  [Activatable(typeof (__IFBResultFactory), 1)]
  public sealed class FBResult : __IFBResultPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBResult([In] object Object);

    public extern bool Succeeded { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern object Object { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern FBError ErrorInfo { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

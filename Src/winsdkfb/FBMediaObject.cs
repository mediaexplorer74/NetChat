// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBMediaObject
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
  [MarshalingBehavior]
  [Version(1)]
  [Activatable(1)]
  public sealed class FBMediaObject : __IFBMediaObjectPublicNonVirtuals
  {
    public extern string ContentType { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern string FileName { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBMediaObject SetValue([In] byte[] value);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern byte[] GetValue();

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBMediaObject();
  }
}

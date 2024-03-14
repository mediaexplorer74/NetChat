// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBMediaStream
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;

#nullable disable
namespace winsdkfb
{
  [Threading]
  [Version(1)]
  [Activatable(typeof (__IFBMediaStreamFactory), 1)]
  [MarshalingBehavior]
  public sealed class FBMediaStream : __IFBMediaStreamPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBMediaStream([In] string FileName, [In] IRandomAccessStreamWithContentType Stream);

    public extern IRandomAccessStreamWithContentType Stream { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string FileName { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

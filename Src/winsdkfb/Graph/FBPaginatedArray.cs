// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.FBPaginatedArray
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Version(1)]
  [Activatable(typeof (__IFBPaginatedArrayFactory), 1)]
  [MarshalingBehavior]
  [Threading]
  public sealed class FBPaginatedArray : __IFBPaginatedArrayPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBPaginatedArray(
      [In] string Request,
      [In] PropertySet Parameters,
      [In] FBJsonClassFactory ObjectFactory);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> FirstAsync();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> NextAsync();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> PreviousAsync();

    public extern IVectorView<object> Current { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool HasCurrent { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool HasNext { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern bool HasPrevious { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IVectorView<object> ObjectArrayFromWebResponse(
      [In] string Response,
      [In] FBJsonClassFactory classFactory);
  }
}

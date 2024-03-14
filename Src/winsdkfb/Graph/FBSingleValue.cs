// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.FBSingleValue
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
  [Threading]
  [Version(1)]
  [MarshalingBehavior]
  [Activatable(typeof (__IFBSingleValueFactory), 1)]
  public sealed class FBSingleValue : __IFBSingleValuePublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBSingleValue(
      [In] string Request,
      [In] PropertySet Parameters,
      [In] FBJsonClassFactory ObjectFactory);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> GetAsync();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> PostAsync();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<FBResult> DeleteAsync();
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.HttpManager
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
  [Version(1)]
  [MarshalingBehavior]
  [Static(typeof (__IHttpManagerStatics), 1)]
  public sealed class HttpManager : IHttpClient, __IHttpManagerPublicNonVirtuals
  {
    public static extern HttpManager Instance { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void SetHttpClient([In] IHttpClient httpClient);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<string> GetTaskAsync([In] string path, [In] PropertySet parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<string> PostTaskAsync([In] string path, [In] PropertySet parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IAsyncOperation<string> DeleteTaskAsync([In] string path, [In] PropertySet parameters);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern string ParametersToQueryString([In] PropertySet Parameters);
  }
}

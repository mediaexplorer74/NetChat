// Decompiled with JetBrains decompiler
// Type: winsdkfb.IHttpClient
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(1619076905, 63929, 15003, 147, 189, 171, 50, 225, 110, 199, 209)]
  [Version(1)]
  public interface IHttpClient
  {
    IAsyncOperation<string> GetTaskAsync([In] string path, [In] PropertySet parameters);

    IAsyncOperation<string> PostTaskAsync([In] string path, [In] PropertySet parameters);

    IAsyncOperation<string> DeleteTaskAsync([In] string path, [In] PropertySet parameters);

    string ParametersToQueryString([In] PropertySet Parameters);
  }
}

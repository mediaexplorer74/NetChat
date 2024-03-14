// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IHttpManagerPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [ExclusiveTo(typeof (HttpManager))]
  [Guid(3468884042, 16551, 12888, 139, 222, 18, 83, 141, 236, 219, 17)]
  internal interface __IHttpManagerPublicNonVirtuals
  {
    void SetHttpClient([In] IHttpClient httpClient);
  }
}

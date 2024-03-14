// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IHttpManagerStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(840495558, 6265, 15301, 157, 177, 135, 91, 249, 111, 79, 132)]
  [ExclusiveTo(typeof (HttpManager))]
  [Version(1)]
  internal interface __IHttpManagerStatics
  {
    HttpManager Instance { get; }
  }
}

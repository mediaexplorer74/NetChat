// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBMediaStreamFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBMediaStream))]
  [Guid(3521704406, 3805, 13375, 159, 123, 140, 39, 12, 109, 9, 211)]
  [Version(1)]
  internal interface __IFBMediaStreamFactory
  {
    [Overload("CreateInstance1")]
    FBMediaStream CreateInstance([In] string FileName, [In] IRandomAccessStreamWithContentType Stream);
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBMediaStreamPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;
using Windows.Storage.Streams;

#nullable disable
namespace winsdkfb
{
  [Guid(3785397324, 49814, 12309, 168, 197, 177, 150, 69, 89, 132, 186)]
  [Version(1)]
  [ExclusiveTo(typeof (FBMediaStream))]
  internal interface __IFBMediaStreamPublicNonVirtuals
  {
    IRandomAccessStreamWithContentType Stream { get; }

    string FileName { get; }
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBProfilePictureDataPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(1234466977, 1159, 14325, 138, 123, 189, 98, 34, 223, 167, 17)]
  [Version(1)]
  [ExclusiveTo(typeof (FBProfilePictureData))]
  internal interface __IFBProfilePictureDataPublicNonVirtuals
  {
    FBProfilePicture Data { get; [param: In] set; }
  }
}

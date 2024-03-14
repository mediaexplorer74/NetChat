// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBProfilePicturePublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBProfilePicture))]
  [Version(1)]
  [Guid(3321474663, 3188, 15223, 169, 108, 118, 116, 169, 242, 101, 25)]
  internal interface __IFBProfilePicturePublicNonVirtuals
  {
    int Height { get; [param: In] set; }

    bool IsSilhouette { get; [param: In] set; }

    string Url { get; [param: In] set; }

    int Width { get; [param: In] set; }
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBProfilePictureStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Version(1)]
  [ExclusiveTo(typeof (FBProfilePicture))]
  [Guid(2911007249, 15671, 13302, 133, 94, 55, 216, 190, 96, 49, 154)]
  internal interface __IFBProfilePictureStatics
  {
    object FromJson([In] string JsonText);
  }
}

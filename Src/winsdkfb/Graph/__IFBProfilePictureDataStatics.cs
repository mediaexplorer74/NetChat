// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBProfilePictureDataStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBProfilePictureData))]
  [Version(1)]
  [Guid(2794306309, 19248, 14103, 176, 86, 51, 162, 215, 190, 69, 167)]
  internal interface __IFBProfilePictureDataStatics
  {
    object FromJson([In] string JsonText);
  }
}

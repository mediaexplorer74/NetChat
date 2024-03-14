// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPermissionStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(1422699526, 27946, 13111, 177, 244, 24, 236, 151, 134, 105, 109)]
  [Version(1)]
  [ExclusiveTo(typeof (FBPermission))]
  internal interface __IFBPermissionStatics
  {
    object FromJson([In] string JsonText);
  }
}

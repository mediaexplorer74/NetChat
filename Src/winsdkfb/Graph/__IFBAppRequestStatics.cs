// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBAppRequestStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(4181607022, 56008, 16156, 153, 238, 96, 49, 242, 141, 63, 8)]
  [Version(1)]
  [ExclusiveTo(typeof (FBAppRequest))]
  internal interface __IFBAppRequestStatics
  {
    object FromJson([In] string JsonText);
  }
}

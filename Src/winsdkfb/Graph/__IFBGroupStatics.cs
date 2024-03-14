// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBGroupStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBGroup))]
  [Version(1)]
  [Guid(1251107933, 54150, 13341, 190, 220, 161, 48, 115, 96, 87, 139)]
  internal interface __IFBGroupStatics
  {
    object FromJson([In] string JsonText);
  }
}

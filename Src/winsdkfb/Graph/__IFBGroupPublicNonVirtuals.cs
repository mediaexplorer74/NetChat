// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBGroupPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBGroup))]
  [Guid(2228860953, 35139, 15504, 146, 124, 149, 28, 7, 3, 7, 94)]
  [Version(1)]
  internal interface __IFBGroupPublicNonVirtuals
  {
    string Id { get; [param: In] set; }

    string Description { get; [param: In] set; }

    string Email { get; [param: In] set; }

    string Icon { get; [param: In] set; }

    string Link { get; [param: In] set; }

    string Name { get; [param: In] set; }

    string Privacy { get; [param: In] set; }
  }
}

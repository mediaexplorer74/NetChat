// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPagePublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBPage))]
  [Version(1)]
  [Guid(83358351, 9275, 15697, 172, 140, 83, 102, 71, 127, 62, 236)]
  internal interface __IFBPagePublicNonVirtuals
  {
    string Id { get; [param: In] set; }

    string Category { get; [param: In] set; }

    int Checkins { get; [param: In] set; }

    string Description { get; [param: In] set; }

    int Likes { get; [param: In] set; }

    string Link { get; [param: In] set; }

    string Name { get; [param: In] set; }
  }
}

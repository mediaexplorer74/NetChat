// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPagingPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(1699995405, 14813, 14991, 151, 101, 4, 235, 94, 95, 58, 152)]
  [ExclusiveTo(typeof (FBPaging))]
  [Version(1)]
  internal interface __IFBPagingPublicNonVirtuals
  {
    FBCursors Cursors { get; [param: In] set; }

    string Next { get; [param: In] set; }

    string Previous { get; [param: In] set; }
  }
}

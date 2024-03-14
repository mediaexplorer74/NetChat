// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBCursorsPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBCursors))]
  [Guid(697638091, 20805, 13927, 191, 107, 114, 190, 251, 103, 60, 110)]
  [Version(1)]
  internal interface __IFBCursorsPublicNonVirtuals
  {
    string After { get; [param: In] set; }

    string Before { get; [param: In] set; }
  }
}

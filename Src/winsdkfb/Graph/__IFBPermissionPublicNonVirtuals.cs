// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPermissionPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBPermission))]
  [Version(1)]
  [Guid(1736950361, 28036, 15265, 148, 132, 246, 148, 118, 36, 211, 207)]
  internal interface __IFBPermissionPublicNonVirtuals
  {
    string Permission { get; [param: In] set; }

    string Status { get; [param: In] set; }
  }
}

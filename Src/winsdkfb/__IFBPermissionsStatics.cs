// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBPermissionsStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBPermissions))]
  [Guid(2550035026, 13177, 15901, 134, 197, 158, 249, 157, 179, 36, 46)]
  [Version(1)]
  internal interface __IFBPermissionsStatics
  {
    FBPermissions FromString([In] string Permissions);

    FBPermissions Difference([In] FBPermissions Minuend, [In] FBPermissions Subtrahend);
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBPermissionsFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(2082694926, 26510, 14255, 145, 212, 64, 98, 250, 199, 55, 49)]
  [ExclusiveTo(typeof (FBPermissions))]
  [Version(1)]
  internal interface __IFBPermissionsFactory
  {
    [Overload("CreateInstance1")]
    FBPermissions CreateInstance([In] IVectorView<string> Permissions);
  }
}

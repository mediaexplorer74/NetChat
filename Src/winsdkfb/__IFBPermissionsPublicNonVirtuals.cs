// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBPermissionsPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBPermissions))]
  [Guid(503190959, 34173, 14495, 188, 205, 248, 74, 35, 177, 35, 60)]
  [Version(1)]
  internal interface __IFBPermissionsPublicNonVirtuals
  {
    IVectorView<string> Values { get; }
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IProfilePictureControlPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [WebHostHidden]
  [Guid(2119423625, 33555, 14947, 182, 7, 92, 53, 100, 151, 23, 112)]
  [Version(1)]
  [ExclusiveTo(typeof (ProfilePictureControl))]
  internal interface __IProfilePictureControlPublicNonVirtuals
  {
    void InitializeComponent();

    string UserId { get; [param: In] set; }

    CroppingType CropMode { get; [param: In] set; }
  }
}

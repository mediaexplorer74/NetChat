// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBResultPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [Guid(656045903, 50260, 13971, 133, 163, 253, 224, 13, 49, 61, 23)]
  [ExclusiveTo(typeof (FBResult))]
  internal interface __IFBResultPublicNonVirtuals
  {
    bool Succeeded { get; }

    object Object { get; }

    FBError ErrorInfo { get; }
  }
}

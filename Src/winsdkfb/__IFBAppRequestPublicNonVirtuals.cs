// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBAppRequestPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(1251282087, 21726, 14436, 161, 44, 237, 139, 102, 116, 186, 179)]
  [Version(1)]
  [ExclusiveTo(typeof (FBAppRequest))]
  internal interface __IFBAppRequestPublicNonVirtuals
  {
    string RequestId { get; }

    IVectorView<string> RecipientIds { get; }
  }
}

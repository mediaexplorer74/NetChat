// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBAccessTokenDataPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(890898720, 50435, 15793, 186, 225, 12, 228, 215, 183, 165, 95)]
  [Version(1)]
  [ExclusiveTo(typeof (FBAccessTokenData))]
  internal interface __IFBAccessTokenDataPublicNonVirtuals
  {
    string AccessToken { get; }

    DateTime ExpirationDate { get; }

    FBPermissions GrantedPermissions { get; }

    FBPermissions DeclinedPermissions { get; }

    bool IsExpired();

    void SetPermissions([In] IVectorView<object> perms);
  }
}

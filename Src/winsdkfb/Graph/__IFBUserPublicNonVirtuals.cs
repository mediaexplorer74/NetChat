// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBUserPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Version(1)]
  [Guid(3866864714, 19734, 13686, 178, 149, 113, 47, 168, 192, 21, 132)]
  [ExclusiveTo(typeof (FBUser))]
  internal interface __IFBUserPublicNonVirtuals
  {
    string Id { get; [param: In] set; }

    string FirstName { get; [param: In] set; }

    string Gender { get; [param: In] set; }

    string LastName { get; [param: In] set; }

    string Email { get; [param: In] set; }

    string Link { get; [param: In] set; }

    string Locale { get; [param: In] set; }

    FBPage Location { get; [param: In] set; }

    string Name { get; [param: In] set; }

    FBProfilePictureData Picture { get; [param: In] set; }

    int Timezone { get; [param: In] set; }

    string UpdatedTime { get; [param: In] set; }

    bool Verified { get; [param: In] set; }
  }
}

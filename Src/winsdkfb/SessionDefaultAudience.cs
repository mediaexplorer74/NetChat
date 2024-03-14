// Decompiled with JetBrains decompiler
// Type: winsdkfb.SessionDefaultAudience
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  public enum SessionDefaultAudience
  {
    SessionDefaultAudienceNone = 0,
    SessionDefaultAudienceOnlyMe = 10, // 0x0000000A
    SessionDefaultAudienceFriends = 20, // 0x00000014
    SessionDefaultAudienceEveryone = 30, // 0x0000001E
  }
}

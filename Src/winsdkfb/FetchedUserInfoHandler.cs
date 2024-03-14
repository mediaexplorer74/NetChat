// Decompiled with JetBrains decompiler
// Type: winsdkfb.FetchedUserInfoHandler
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using winsdkfb.Graph;

#nullable disable
namespace winsdkfb
{
  [Guid(3343689062, 9530, 15589, 156, 125, 26, 13, 4, 7, 240, 78)]
  [Version(1)]
  public delegate void FetchedUserInfoHandler([In] FBLoginButton sender, [In] FBUser userInfo);
}

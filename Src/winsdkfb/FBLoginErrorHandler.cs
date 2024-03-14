// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBLoginErrorHandler
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [Guid(517302184, 58663, 13845, 141, 1, 112, 229, 144, 111, 143, 228)]
  public delegate void FBLoginErrorHandler([In] FBLoginButton sender, [In] FBError error);
}

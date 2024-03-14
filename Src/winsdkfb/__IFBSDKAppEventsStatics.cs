// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBSDKAppEventsStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [Guid(3751625579, 28946, 12731, 145, 45, 111, 200, 45, 204, 52, 8)]
  [ExclusiveTo(typeof (FBSDKAppEvents))]
  internal interface __IFBSDKAppEventsStatics
  {
    void ActivateApp();

    bool UseSimulator { get; [param: In] set; }
  }
}

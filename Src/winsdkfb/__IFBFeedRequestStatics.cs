// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBFeedRequestStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBFeedRequest))]
  [Guid(1951676114, 65489, 13241, 179, 208, 58, 53, 146, 101, 136, 234)]
  [Version(1)]
  internal interface __IFBFeedRequestStatics
  {
    FBFeedRequest FromFeedDialogResponse([In] Uri Response);
  }
}

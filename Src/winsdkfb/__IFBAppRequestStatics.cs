// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBAppRequestStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(2845255195, 55231, 16164, 178, 158, 147, 218, 189, 191, 142, 53)]
  [ExclusiveTo(typeof (FBAppRequest))]
  [Version(1)]
  internal interface __IFBAppRequestStatics
  {
    FBAppRequest FromRequestDialogResponse([In] Uri Response);
  }
}

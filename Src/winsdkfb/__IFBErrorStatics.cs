// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBErrorStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(2767111341, 38241, 15359, 138, 224, 103, 5, 149, 223, 80, 119)]
  [ExclusiveTo(typeof (FBError))]
  [Version(1)]
  internal interface __IFBErrorStatics
  {
    FBError FromUri([In] Uri ResponseUri);

    FBError FromJson([In] string JsonText);
  }
}

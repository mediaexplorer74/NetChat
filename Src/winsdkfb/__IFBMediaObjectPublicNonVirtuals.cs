// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBMediaObjectPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBMediaObject))]
  [Version(1)]
  [Guid(3780180305, 28989, 14487, 182, 128, 86, 171, 143, 255, 15, 110)]
  internal interface __IFBMediaObjectPublicNonVirtuals
  {
    string ContentType { get; [param: In] set; }

    string FileName { get; [param: In] set; }

    FBMediaObject SetValue([In] byte[] value);

    byte[] GetValue();
  }
}

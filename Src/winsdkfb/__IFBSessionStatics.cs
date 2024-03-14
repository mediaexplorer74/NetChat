// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBSessionStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;
using Windows.Storage;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBSession))]
  [Version(1)]
  [Guid(281816567, 57400, 12562, 135, 83, 255, 107, 195, 95, 119, 193)]
  internal interface __IFBSessionStatics
  {
    FBSession ActiveSession { get; }

    ApplicationDataContainer DataContainer { get; }
  }
}

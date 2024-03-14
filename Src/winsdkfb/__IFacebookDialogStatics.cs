// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFacebookDialogStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FacebookDialog))]
  [Version(1)]
  [Guid(3635607076, 17362, 14879, 144, 195, 132, 137, 92, 22, 37, 196)]
  [WebHostHidden]
  internal interface __IFacebookDialogStatics
  {
    string GetFBServerUrl();

    void DeleteCookies();
  }
}

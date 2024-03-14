// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBErrorPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [ExclusiveTo(typeof (FBError))]
  [Guid(1765293301, 54547, 12315, 137, 142, 137, 233, 250, 191, 247, 3)]
  internal interface __IFBErrorPublicNonVirtuals
  {
    string Message { get; }

    string Type { get; }

    int Code { get; }

    int Subcode { get; }

    string ErrorUserTitle { get; }

    string ErrorUserMessage { get; }
  }
}

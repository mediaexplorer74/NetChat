// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBAppRequestPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(1317261068, 30005, 13483, 164, 244, 108, 185, 67, 32, 0, 191)]
  [ExclusiveTo(typeof (FBAppRequest))]
  [Version(1)]
  internal interface __IFBAppRequestPublicNonVirtuals
  {
    string ActionType { get; [param: In] set; }

    string CreatedTime { get; [param: In] set; }

    string Data { get; [param: In] set; }

    FBUser From { get; [param: In] set; }

    string Id { get; [param: In] set; }

    string Message { get; [param: In] set; }

    FBUser To { get; [param: In] set; }
  }
}

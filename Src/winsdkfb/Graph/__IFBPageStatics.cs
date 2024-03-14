// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPageStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Version(1)]
  [ExclusiveTo(typeof (FBPage))]
  [Guid(3009822500, 38947, 12769, 188, 246, 38, 247, 81, 146, 138, 58)]
  internal interface __IFBPageStatics
  {
    object FromJson([In] string JsonText);
  }
}

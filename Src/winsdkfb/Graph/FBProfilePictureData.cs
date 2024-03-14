// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.FBProfilePictureData
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Threading]
  [Static(typeof (__IFBProfilePictureDataStatics), 1)]
  [MarshalingBehavior]
  [Version(1)]
  public sealed class FBProfilePictureData : __IFBProfilePictureDataPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern object FromJson([In] string JsonText);

    public extern FBProfilePicture Data { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
  }
}

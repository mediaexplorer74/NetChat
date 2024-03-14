// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPagingStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBPaging))]
  [Version(1)]
  [Guid(2520603303, 46793, 15792, 132, 35, 147, 112, 81, 4, 165, 74)]
  internal interface __IFBPagingStatics
  {
    object FromJson([In] string JsonText);
  }
}

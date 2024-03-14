// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBResultFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Guid(2338504608, 30802, 13935, 190, 50, 52, 211, 134, 64, 68, 191)]
  [Version(1)]
  [ExclusiveTo(typeof (FBResult))]
  internal interface __IFBResultFactory
  {
    [Overload("CreateInstance1")]
    FBResult CreateInstance([In] object Object);
  }
}

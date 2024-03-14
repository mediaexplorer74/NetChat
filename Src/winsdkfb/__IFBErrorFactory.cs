// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFBErrorFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [ExclusiveTo(typeof (FBError))]
  [Guid(476991763, 43305, 15144, 156, 246, 55, 202, 179, 192, 63, 67)]
  [Version(1)]
  internal interface __IFBErrorFactory
  {
    [Overload("CreateInstance1")]
    FBError CreateInstance([In] int Code, [In] string Type, [In] string Message);
  }
}

// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPaginatedArrayFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Version(1)]
  [Guid(4101803693, 34041, 13657, 191, 13, 159, 137, 104, 11, 200, 186)]
  [ExclusiveTo(typeof (FBPaginatedArray))]
  internal interface __IFBPaginatedArrayFactory
  {
    [Overload("CreateInstance1")]
    FBPaginatedArray CreateInstance(
      [In] string Request,
      [In] PropertySet Parameters,
      [In] FBJsonClassFactory ObjectFactory);
  }
}

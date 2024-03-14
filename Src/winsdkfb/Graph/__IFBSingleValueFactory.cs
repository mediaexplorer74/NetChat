// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBSingleValueFactory
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(1349730222, 24153, 12979, 129, 193, 213, 54, 235, 65, 121, 89)]
  [Version(1)]
  [ExclusiveTo(typeof (FBSingleValue))]
  internal interface __IFBSingleValueFactory
  {
    [Overload("CreateInstance1")]
    FBSingleValue CreateInstance(
      [In] string Request,
      [In] PropertySet Parameters,
      [In] FBJsonClassFactory ObjectFactory);
  }
}

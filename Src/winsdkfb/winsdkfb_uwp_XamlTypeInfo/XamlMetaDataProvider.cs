// Decompiled with JetBrains decompiler
// Type: winsdkfb.winsdkfb_uwp_XamlTypeInfo.XamlMetaDataProvider
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Interop;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace winsdkfb.winsdkfb_uwp_XamlTypeInfo
{
  [Threading]
  [MarshalingBehavior]
  [Version(1)]
  [Activatable(1)]
  [WebHostHidden]
  public sealed class XamlMetaDataProvider : 
    IXamlMetadataProvider,
    __IXamlMetaDataProviderPublicNonVirtuals
  {
    [Overload("GetXamlTypeByFullName")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IXamlType GetXamlType([In] string fullName);

    [DefaultOverload]
    [Overload("GetXamlType")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IXamlType GetXamlType([In] TypeName type);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern XmlnsDefinition[] GetXmlnsDefinitions();

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern XamlMetaDataProvider();
  }
}

// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo.XamlMetaDataProvider
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.CodeDom.Compiler;
using Windows.UI.Xaml.Markup;


namespace Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  public sealed class XamlMetaDataProvider : IXamlMetadataProvider
  {
    private XamlTypeInfoProvider _provider;

    public IXamlType GetXamlType(Type type)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByType(type);
    }

    public IXamlType GetXamlType(string fullName)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByName(fullName);
    }

    public XmlnsDefinition[] GetXmlnsDefinitions() => new XmlnsDefinition[0];
  }
}

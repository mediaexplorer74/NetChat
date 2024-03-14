// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo.XamlSystemBaseType
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlSystemBaseType : IXamlType
  {
    private string _fullName;
    private Type _underlyingType;

    public XamlSystemBaseType(string fullName, Type underlyingType)
    {
      this._fullName = fullName;
      this._underlyingType = underlyingType;
    }

    public string FullName => this._fullName;

    public Type UnderlyingType => this._underlyingType;

    public virtual IXamlType BaseType => throw new NotImplementedException();

    public virtual IXamlMember ContentProperty => throw new NotImplementedException();

    public virtual IXamlMember GetMember(string name) => throw new NotImplementedException();

    public virtual bool IsArray => throw new NotImplementedException();

    public virtual bool IsCollection => throw new NotImplementedException();

    public virtual bool IsConstructible => throw new NotImplementedException();

    public virtual bool IsDictionary => throw new NotImplementedException();

    public virtual bool IsMarkupExtension => throw new NotImplementedException();

    public virtual bool IsBindable => throw new NotImplementedException();

    public virtual bool IsReturnTypeStub => throw new NotImplementedException();

    public virtual bool IsLocalType => throw new NotImplementedException();

    public virtual IXamlType ItemType => throw new NotImplementedException();

    public virtual IXamlType KeyType => throw new NotImplementedException();

    public virtual object ActivateInstance() => throw new NotImplementedException();

    public virtual void AddToMap(object instance, object key, object item)
    {
      throw new NotImplementedException();
    }

    public virtual void AddToVector(object instance, object item)
    {
      throw new NotImplementedException();
    }

    public virtual void RunInitializer() => throw new NotImplementedException();

    public virtual object CreateFromString(string input) => throw new NotImplementedException();
  }
}

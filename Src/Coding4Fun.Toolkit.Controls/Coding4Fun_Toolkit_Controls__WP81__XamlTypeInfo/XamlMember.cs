// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo.XamlMember
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
  internal class XamlMember : IXamlMember
  {
    private XamlTypeInfoProvider _provider;
    private string _name;
    private bool _isAttachable;
    private bool _isDependencyProperty;
    private bool _isReadOnly;
    private string _typeName;
    private string _targetTypeName;

    public XamlMember(XamlTypeInfoProvider provider, string name, string typeName)
    {
      this._name = name;
      this._typeName = typeName;
      this._provider = provider;
    }

    public string Name => this._name;

    public IXamlType Type => this._provider.GetXamlTypeByName(this._typeName);

    public void SetTargetTypeName(string targetTypeName) => this._targetTypeName = targetTypeName;

    public IXamlType TargetType => this._provider.GetXamlTypeByName(this._targetTypeName);

    public void SetIsAttachable() => this._isAttachable = true;

    public bool IsAttachable => this._isAttachable;

    public void SetIsDependencyProperty() => this._isDependencyProperty = true;

    public bool IsDependencyProperty => this._isDependencyProperty;

    public void SetIsReadOnly() => this._isReadOnly = true;

    public bool IsReadOnly => this._isReadOnly;

    public Getter Getter { get; set; }

    public object GetValue(object instance)
    {
      if (this.Getter != null)
        return this.Getter(instance);
      throw new InvalidOperationException(nameof (GetValue));
    }

    public Setter Setter { get; set; }

    public void SetValue(object instance, object value)
    {
      if (this.Setter == null)
        throw new InvalidOperationException(nameof (SetValue));
      this.Setter(instance, value);
    }
  }
}

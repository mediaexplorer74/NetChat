// Decompiled with JetBrains decompiler
// Type: IGM.UI.IGM_UI_WindowsPhone_XamlTypeInfo.XamlTypeInfoProvider
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace IGM.UI.IGM_UI_WindowsPhone_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlTypeInfoProvider
  {
    private Dictionary<string, IXamlType> _xamlTypeCacheByName = new Dictionary<string, IXamlType>();
    private Dictionary<Type, IXamlType> _xamlTypeCacheByType = new Dictionary<Type, IXamlType>();
    private Dictionary<string, IXamlMember> _xamlMembers = new Dictionary<string, IXamlMember>();
    private string[] _typeNameTable;
    private Type[] _typeTable;
    private List<IXamlMetadataProvider> _otherProviders;

    public IXamlType GetXamlTypeByType(Type type)
    {
      IXamlType xamlTypeByType;
      if (this._xamlTypeCacheByType.TryGetValue(type, out xamlTypeByType))
        return xamlTypeByType;
      int typeIndex = this.LookupTypeIndexByType(type);
      if (typeIndex != -1)
        xamlTypeByType = this.CreateXamlType(typeIndex);
      XamlUserType xamlUserType = xamlTypeByType as XamlUserType;
      if (xamlTypeByType == null || xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType)
      {
        IXamlType ixamlType = this.CheckOtherMetadataProvidersForType(type);
        if (ixamlType != null && (ixamlType.IsConstructible || xamlTypeByType == null))
          xamlTypeByType = ixamlType;
      }
      if (xamlTypeByType != null)
      {
        this._xamlTypeCacheByName.Add(xamlTypeByType.FullName, xamlTypeByType);
        this._xamlTypeCacheByType.Add(xamlTypeByType.UnderlyingType, xamlTypeByType);
      }
      return xamlTypeByType;
    }

    public IXamlType GetXamlTypeByName(string typeName)
    {
      if (string.IsNullOrEmpty(typeName))
        return (IXamlType) null;
      IXamlType xamlTypeByName;
      if (this._xamlTypeCacheByName.TryGetValue(typeName, out xamlTypeByName))
        return xamlTypeByName;
      int typeIndex = this.LookupTypeIndexByName(typeName);
      if (typeIndex != -1)
        xamlTypeByName = this.CreateXamlType(typeIndex);
      XamlUserType xamlUserType = xamlTypeByName as XamlUserType;
      if (xamlTypeByName == null || xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType)
      {
        IXamlType ixamlType = this.CheckOtherMetadataProvidersForName(typeName);
        if (ixamlType != null && (ixamlType.IsConstructible || xamlTypeByName == null))
          xamlTypeByName = ixamlType;
      }
      if (xamlTypeByName != null)
      {
        this._xamlTypeCacheByName.Add(xamlTypeByName.FullName, xamlTypeByName);
        this._xamlTypeCacheByType.Add(xamlTypeByName.UnderlyingType, xamlTypeByName);
      }
      return xamlTypeByName;
    }

    public IXamlMember GetMemberByLongName(string longMemberName)
    {
      if (string.IsNullOrEmpty(longMemberName))
        return (IXamlMember) null;
      IXamlMember memberByLongName;
      if (this._xamlMembers.TryGetValue(longMemberName, out memberByLongName))
        return memberByLongName;
      IXamlMember xamlMember = this.CreateXamlMember(longMemberName);
      if (xamlMember != null)
        this._xamlMembers.Add(longMemberName, xamlMember);
      return xamlMember;
    }

    private void InitTypeTables()
    {
      this._typeNameTable = new string[12];
      this._typeNameTable[0] = "IGM.UI.StringFormatConverter";
      this._typeNameTable[1] = "Object";
      this._typeNameTable[2] = "IGM.UI.About";
      this._typeNameTable[3] = "Windows.UI.Xaml.Controls.UserControl";
      this._typeNameTable[4] = "IGM.UI.FeedbackUC";
      this._typeNameTable[5] = "IGM.UI.RoomPanel";
      this._typeNameTable[6] = "IGM.UI.AttendeePanel";
      this._typeNameTable[7] = "Int32";
      this._typeNameTable[8] = "IGM.UI.ChatBubblePanel";
      this._typeNameTable[9] = "IGM.UI.MainPage";
      this._typeNameTable[10] = "Windows.UI.Xaml.Controls.Page";
      this._typeNameTable[11] = "IGM.UI.ChatPanel";
      this._typeTable = new Type[12];
      this._typeTable[0] = typeof (StringFormatConverter);
      this._typeTable[1] = typeof (object);
      this._typeTable[2] = typeof (About);
      this._typeTable[3] = typeof (UserControl);
      this._typeTable[4] = typeof (FeedbackUC);
      this._typeTable[5] = typeof (RoomPanel);
      this._typeTable[6] = typeof (AttendeePanel);
      this._typeTable[7] = typeof (int);
      this._typeTable[8] = typeof (ChatBubblePanel);
      this._typeTable[9] = typeof (MainPage);
      this._typeTable[10] = typeof (Page);
      this._typeTable[11] = typeof (ChatPanel);
    }

    private int LookupTypeIndexByName(string typeName)
    {
      if (this._typeNameTable == null)
        this.InitTypeTables();
      for (int index = 0; index < this._typeNameTable.Length; ++index)
      {
        if (string.CompareOrdinal(this._typeNameTable[index], typeName) == 0)
          return index;
      }
      return -1;
    }

    private int LookupTypeIndexByType(Type type)
    {
      if (this._typeTable == null)
        this.InitTypeTables();
      for (int index = 0; index < this._typeTable.Length; ++index)
      {
        if (type == this._typeTable[index])
          return index;
      }
      return -1;
    }

    private object Activate_0_StringFormatConverter() => (object) new StringFormatConverter();

    private object Activate_2_About() => (object) new About();

    private object Activate_4_FeedbackUC() => (object) new FeedbackUC();

    private object Activate_5_RoomPanel() => (object) new RoomPanel();

    private object Activate_6_AttendeePanel() => (object) new AttendeePanel();

    private object Activate_8_ChatBubblePanel() => (object) new ChatBubblePanel();

    private object Activate_9_MainPage() => (object) new MainPage();

    private object Activate_11_ChatPanel() => (object) new ChatPanel();

    private IXamlType CreateXamlType(int typeIndex)
    {
      XamlSystemBaseType xamlType = (XamlSystemBaseType) null;
      string fullName = this._typeNameTable[typeIndex];
      Type type = this._typeTable[typeIndex];
      switch (typeIndex)
      {
        case 0:
          XamlUserType xamlUserType1 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType1.Activator = new Activator(this.Activate_0_StringFormatConverter);
          xamlUserType1.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType1;
          break;
        case 1:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 2:
          XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType2.Activator = new Activator(this.Activate_2_About);
          xamlUserType2.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType2;
          break;
        case 3:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 4:
          XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType3.Activator = new Activator(this.Activate_4_FeedbackUC);
          xamlUserType3.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType3;
          break;
        case 5:
          XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType4.Activator = new Activator(this.Activate_5_RoomPanel);
          xamlUserType4.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType4;
          break;
        case 6:
          XamlUserType xamlUserType5 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType5.Activator = new Activator(this.Activate_6_AttendeePanel);
          xamlUserType5.AddMemberName("PeerCount");
          xamlUserType5.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType5;
          break;
        case 7:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 8:
          XamlUserType xamlUserType6 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType6.Activator = new Activator(this.Activate_8_ChatBubblePanel);
          xamlUserType6.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType6;
          break;
        case 9:
          XamlUserType xamlUserType7 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType7.Activator = new Activator(this.Activate_9_MainPage);
          xamlUserType7.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType7;
          break;
        case 10:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 11:
          XamlUserType xamlUserType8 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
          xamlUserType8.Activator = new Activator(this.Activate_11_ChatPanel);
          xamlUserType8.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType8;
          break;
      }
      return (IXamlType) xamlType;
    }

    private List<IXamlMetadataProvider> OtherProviders
    {
      get
      {
        if (this._otherProviders == null)
        {
          this._otherProviders = new List<IXamlMetadataProvider>();
          this._otherProviders.Add((IXamlMetadataProvider) new XamlMetaDataProvider());
        }
        return this._otherProviders;
      }
    }

    private IXamlType CheckOtherMetadataProvidersForName(string typeName)
    {
      IXamlType ixamlType = (IXamlType) null;
      foreach (IXamlMetadataProvider otherProvider in this.OtherProviders)
      {
        IXamlType xamlType = otherProvider.GetXamlType(typeName);
        if (xamlType != null)
        {
          if (xamlType.IsConstructible)
            return xamlType;
          ixamlType = xamlType;
        }
      }
      return ixamlType;
    }

    private IXamlType CheckOtherMetadataProvidersForType(Type type)
    {
      IXamlType ixamlType = (IXamlType) null;
      foreach (IXamlMetadataProvider otherProvider in this.OtherProviders)
      {
        IXamlType xamlType = otherProvider.GetXamlType(type);
        if (xamlType != null)
        {
          if (xamlType.IsConstructible)
            return xamlType;
          ixamlType = xamlType;
        }
      }
      return ixamlType;
    }

    private object get_0_AttendeePanel_PeerCount(object instance)
    {
      return (object) ((AttendeePanel) instance).PeerCount;
    }

    private IXamlMember CreateXamlMember(string longMemberName)
    {
      XamlMember xamlMember = (XamlMember) null;
      if (longMemberName == "IGM.UI.AttendeePanel.PeerCount")
      {
        XamlUserType xamlTypeByName = (XamlUserType) this.GetXamlTypeByName("IGM.UI.AttendeePanel");
        xamlMember = new XamlMember(this, "PeerCount", "Int32");
        xamlMember.SetIsDependencyProperty();
        xamlMember.Getter = new Getter(this.get_0_AttendeePanel_PeerCount);
        xamlMember.SetIsReadOnly();
      }
      return (IXamlMember) xamlMember;
    }
  }
}

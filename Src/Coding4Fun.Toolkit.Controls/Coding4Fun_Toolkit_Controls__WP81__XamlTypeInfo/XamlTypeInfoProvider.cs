// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo.XamlTypeInfoProvider
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Converters;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;


namespace Coding4Fun.Toolkit.Controls.Coding4Fun_Toolkit_Controls__WP81__XamlTypeInfo
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

    public IXamlType GetXamlTypeByType(Type type)
    {
      IXamlType xamlType;
      if (this._xamlTypeCacheByType.TryGetValue(type, out xamlType))
        return xamlType;
      int typeIndex = this.LookupTypeIndexByType(type);
      if (typeIndex != -1)
        xamlType = this.CreateXamlType(typeIndex);
      if (xamlType != null)
      {
        this._xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
        this._xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
      }
      return xamlType;
    }

    public IXamlType GetXamlTypeByName(string typeName)
    {
      if (string.IsNullOrEmpty(typeName))
        return (IXamlType) null;
      IXamlType xamlType;
      if (this._xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
        return xamlType;
      int typeIndex = this.LookupTypeIndexByName(typeName);
      if (typeIndex != -1)
        xamlType = this.CreateXamlType(typeIndex);
      if (xamlType != null)
      {
        this._xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
        this._xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
      }
      return xamlType;
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
      this._typeNameTable = new string[72];
      this._typeNameTable[0] = "Coding4Fun.Toolkit.Controls.Converters.SolidColorBrushToColorConverter";
      this._typeNameTable[1] = "Coding4Fun.Toolkit.Controls.Converters.ValueConverter";
      this._typeNameTable[2] = "Object";
      this._typeNameTable[3] = "Coding4Fun.Toolkit.Controls.ProgressOverlay";
      this._typeNameTable[4] = "Windows.UI.Xaml.Controls.ContentControl";
      this._typeNameTable[5] = "Coding4Fun.Toolkit.Controls.ColorPicker";
      this._typeNameTable[6] = "Coding4Fun.Toolkit.Controls.ColorBaseControl";
      this._typeNameTable[7] = "Windows.UI.Xaml.Controls.Control";
      this._typeNameTable[8] = "Windows.UI.Color";
      this._typeNameTable[9] = "System.ValueType";
      this._typeNameTable[10] = "Windows.UI.Xaml.Media.SolidColorBrush";
      this._typeNameTable[11] = "Coding4Fun.Toolkit.Controls.ColorSliderThumb";
      this._typeNameTable[12] = "Coding4Fun.Toolkit.Controls.SuperSlider";
      this._typeNameTable[13] = "Windows.UI.Xaml.Controls.Orientation";
      this._typeNameTable[14] = "Double";
      this._typeNameTable[15] = "String";
      this._typeNameTable[16] = "Coding4Fun.Toolkit.Controls.ColorSlider";
      this._typeNameTable[17] = "Boolean";
      this._typeNameTable[18] = "Coding4Fun.Toolkit.Controls.MetroFlowItem";
      this._typeNameTable[19] = "Windows.UI.Xaml.Media.ImageSource";
      this._typeNameTable[20] = "Windows.UI.Xaml.Visibility";
      this._typeNameTable[21] = "Int32";
      this._typeNameTable[22] = "Coding4Fun.Toolkit.Controls.MetroFlow";
      this._typeNameTable[23] = "Windows.UI.Xaml.Controls.ItemsControl";
      this._typeNameTable[24] = "TimeSpan";
      this._typeNameTable[25] = "Coding4Fun.Toolkit.Controls.OpacityToggleButton";
      this._typeNameTable[26] = "Coding4Fun.Toolkit.Controls.ToggleButtonBase";
      this._typeNameTable[27] = "Windows.UI.Xaml.Controls.CheckBox";
      this._typeNameTable[28] = "Windows.UI.Xaml.Duration";
      this._typeNameTable[29] = "Windows.UI.Xaml.Media.Brush";
      this._typeNameTable[30] = "Coding4Fun.Toolkit.Controls.RectangularButton";
      this._typeNameTable[31] = "Coding4Fun.Toolkit.Controls.ButtonBase";
      this._typeNameTable[32] = "Windows.UI.Xaml.Controls.Button";
      this._typeNameTable[33] = "Coding4Fun.Toolkit.Controls.RoundButton";
      this._typeNameTable[34] = "Coding4Fun.Toolkit.Controls.RoundToggleButton";
      this._typeNameTable[35] = "Coding4Fun.Toolkit.Controls.ChatBubble";
      this._typeNameTable[36] = "Coding4Fun.Toolkit.Controls.ChatBubbleDirection";
      this._typeNameTable[37] = "System.Enum";
      this._typeNameTable[38] = "Coding4Fun.Toolkit.Controls.ChatBubbleTextBox";
      this._typeNameTable[39] = "Windows.UI.Xaml.Controls.TextBox";
      this._typeNameTable[40] = "Windows.UI.Xaml.Style";
      this._typeNameTable[41] = "Coding4Fun.Toolkit.Controls.ColorHexagonPicker";
      this._typeNameTable[42] = "Coding4Fun.Toolkit.Controls.ImageTile";
      this._typeNameTable[43] = "System.Collections.Generic.List`1<System.Uri>";
      this._typeNameTable[44] = "System.Uri";
      this._typeNameTable[45] = "System.UriHostNameType";
      this._typeNameTable[46] = "String[]";
      this._typeNameTable[47] = "System.Array";
      this._typeNameTable[48] = "Coding4Fun.Toolkit.Controls.ImageTileAnimationTypes";
      this._typeNameTable[49] = "Coding4Fun.Toolkit.Controls.SuperImage";
      this._typeNameTable[50] = "Windows.UI.Xaml.Media.Stretch";
      this._typeNameTable[51] = "System.Collections.ObjectModel.ObservableCollection`1<Coding4Fun.Toolkit.Controls.SuperImageSource>";
      this._typeNameTable[52] = "System.Collections.ObjectModel.Collection`1<Coding4Fun.Toolkit.Controls.SuperImageSource>";
      this._typeNameTable[53] = "Coding4Fun.Toolkit.Controls.SuperImageSource";
      this._typeNameTable[54] = "Windows.UI.Xaml.DependencyObject";
      this._typeNameTable[55] = "Coding4Fun.Toolkit.Controls.Tile";
      this._typeNameTable[56] = "Windows.UI.Xaml.TextWrapping";
      this._typeNameTable[57] = "Coding4Fun.Toolkit.Controls.TileNotification";
      this._typeNameTable[58] = "Coding4Fun.Toolkit.Controls.PasswordInputPrompt";
      this._typeNameTable[59] = "Coding4Fun.Toolkit.Controls.InputPrompt";
      this._typeNameTable[60] = "Coding4Fun.Toolkit.Controls.UserPrompt";
      this._typeNameTable[61] = "Coding4Fun.Toolkit.Controls.ActionPopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>";
      this._typeNameTable[62] = "Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>";
      this._typeNameTable[63] = "Char";
      this._typeNameTable[64] = "Windows.UI.Xaml.Input.InputScope";
      this._typeNameTable[65] = "System.Collections.Generic.List`1<Windows.UI.Xaml.Controls.Button>";
      this._typeNameTable[66] = "Coding4Fun.Toolkit.Controls.ToastPrompt";
      this._typeNameTable[67] = "Coding4Fun.Toolkit.Controls.AboutPrompt";
      this._typeNameTable[68] = "Coding4Fun.Toolkit.Controls.ActionPopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>";
      this._typeNameTable[69] = "Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>";
      this._typeNameTable[70] = "Coding4Fun.Toolkit.Controls.AboutPromptItem";
      this._typeNameTable[71] = "Coding4Fun.Toolkit.Controls.MessagePrompt";
      this._typeTable = new Type[72];
      this._typeTable[0] = typeof (SolidColorBrushToColorConverter);
      this._typeTable[1] = typeof (ValueConverter);
      this._typeTable[2] = typeof (object);
      this._typeTable[3] = typeof (ProgressOverlay);
      this._typeTable[4] = typeof (ContentControl);
      this._typeTable[5] = typeof (ColorPicker);
      this._typeTable[6] = typeof (ColorBaseControl);
      this._typeTable[7] = typeof (Control);
      this._typeTable[8] = typeof (Color);
      this._typeTable[9] = typeof (ValueType);
      this._typeTable[10] = typeof (SolidColorBrush);
      this._typeTable[11] = typeof (ColorSliderThumb);
      this._typeTable[12] = typeof (SuperSlider);
      this._typeTable[13] = typeof (Orientation);
      this._typeTable[14] = typeof (double);
      this._typeTable[15] = typeof (string);
      this._typeTable[16] = typeof (ColorSlider);
      this._typeTable[17] = typeof (bool);
      this._typeTable[18] = typeof (MetroFlowItem);
      this._typeTable[19] = typeof (ImageSource);
      this._typeTable[20] = typeof (Visibility);
      this._typeTable[21] = typeof (int);
      this._typeTable[22] = typeof (MetroFlow);
      this._typeTable[23] = typeof (ItemsControl);
      this._typeTable[24] = typeof (TimeSpan);
      this._typeTable[25] = typeof (OpacityToggleButton);
      this._typeTable[26] = typeof (ToggleButtonBase);
      this._typeTable[27] = typeof (CheckBox);
      this._typeTable[28] = typeof (Duration);
      this._typeTable[29] = typeof (Brush);
      this._typeTable[30] = typeof (RectangularButton);
      this._typeTable[31] = typeof (ButtonBase);
      this._typeTable[32] = typeof (Button);
      this._typeTable[33] = typeof (RoundButton);
      this._typeTable[34] = typeof (RoundToggleButton);
      this._typeTable[35] = typeof (ChatBubble);
      this._typeTable[36] = typeof (ChatBubbleDirection);
      this._typeTable[37] = typeof (Enum);
      this._typeTable[38] = typeof (ChatBubbleTextBox);
      this._typeTable[39] = typeof (TextBox);
      this._typeTable[40] = typeof (Style);
      this._typeTable[41] = typeof (ColorHexagonPicker);
      this._typeTable[42] = typeof (ImageTile);
      this._typeTable[43] = typeof (List<Uri>);
      this._typeTable[44] = typeof (Uri);
      this._typeTable[45] = typeof (UriHostNameType);
      this._typeTable[46] = typeof (string[]);
      this._typeTable[47] = typeof (Array);
      this._typeTable[48] = typeof (ImageTileAnimationTypes);
      this._typeTable[49] = typeof (SuperImage);
      this._typeTable[50] = typeof (Stretch);
      this._typeTable[51] = typeof (ObservableCollection<SuperImageSource>);
      this._typeTable[52] = typeof (Collection<SuperImageSource>);
      this._typeTable[53] = typeof (SuperImageSource);
      this._typeTable[54] = typeof (DependencyObject);
      this._typeTable[55] = typeof (Tile);
      this._typeTable[56] = typeof (TextWrapping);
      this._typeTable[57] = typeof (TileNotification);
      this._typeTable[58] = typeof (PasswordInputPrompt);
      this._typeTable[59] = typeof (InputPrompt);
      this._typeTable[60] = typeof (UserPrompt);
      this._typeTable[61] = typeof (ActionPopUp<string, PopUpResult>);
      this._typeTable[62] = typeof (PopUp<string, PopUpResult>);
      this._typeTable[63] = typeof (char);
      this._typeTable[64] = typeof (InputScope);
      this._typeTable[65] = typeof (List<Button>);
      this._typeTable[66] = typeof (ToastPrompt);
      this._typeTable[67] = typeof (AboutPrompt);
      this._typeTable[68] = typeof (ActionPopUp<object, PopUpResult>);
      this._typeTable[69] = typeof (PopUp<object, PopUpResult>);
      this._typeTable[70] = typeof (AboutPromptItem);
      this._typeTable[71] = typeof (MessagePrompt);
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

    private object Activate_0_SolidColorBrushToColorConverter()
    {
      return (object) new SolidColorBrushToColorConverter();
    }

    private object Activate_3_ProgressOverlay() => (object) new ProgressOverlay();

    private object Activate_5_ColorPicker() => (object) new ColorPicker();

    private object Activate_11_ColorSliderThumb() => (object) new ColorSliderThumb();

    private object Activate_12_SuperSlider() => (object) new SuperSlider();

    private object Activate_16_ColorSlider() => (object) new ColorSlider();

    private object Activate_18_MetroFlowItem() => (object) new MetroFlowItem();

    private object Activate_22_MetroFlow() => (object) new MetroFlow();

    private object Activate_25_OpacityToggleButton() => (object) new OpacityToggleButton();

    private object Activate_30_RectangularButton() => (object) new RectangularButton();

    private object Activate_33_RoundButton() => (object) new RoundButton();

    private object Activate_34_RoundToggleButton() => (object) new RoundToggleButton();

    private object Activate_35_ChatBubble() => (object) new ChatBubble();

    private object Activate_38_ChatBubbleTextBox() => (object) new ChatBubbleTextBox();

    private object Activate_41_ColorHexagonPicker() => (object) new ColorHexagonPicker();

    private object Activate_42_ImageTile() => (object) new ImageTile();

    private object Activate_43_List() => (object) new List<Uri>();

    private object Activate_49_SuperImage() => (object) new SuperImage();

    private object Activate_51_ObservableCollection()
    {
      return (object) new ObservableCollection<SuperImageSource>();
    }

    private object Activate_52_Collection() => (object) new Collection<SuperImageSource>();

    private object Activate_53_SuperImageSource() => (object) new SuperImageSource();

    private object Activate_55_Tile() => (object) new Tile();

    private object Activate_57_TileNotification() => (object) new TileNotification();

    private object Activate_58_PasswordInputPrompt() => (object) new PasswordInputPrompt();

    private object Activate_59_InputPrompt() => (object) new InputPrompt();

    private object Activate_61_ActionPopUp() => (object) new ActionPopUp<string, PopUpResult>();

    private object Activate_65_List() => (object) new List<Button>();

    private object Activate_66_ToastPrompt() => (object) new ToastPrompt();

    private object Activate_67_AboutPrompt() => (object) new AboutPrompt();

    private object Activate_68_ActionPopUp() => (object) new ActionPopUp<object, PopUpResult>();

    private object Activate_70_AboutPromptItem() => (object) new AboutPromptItem();

    private object Activate_71_MessagePrompt() => (object) new MessagePrompt();

    private void VectorAdd_43_List(object instance, object item)
    {
      ((ICollection<Uri>) instance).Add((Uri) item);
    }

    private void VectorAdd_51_ObservableCollection(object instance, object item)
    {
      ((ICollection<SuperImageSource>) instance).Add((SuperImageSource) item);
    }

    private void VectorAdd_52_Collection(object instance, object item)
    {
      ((ICollection<SuperImageSource>) instance).Add((SuperImageSource) item);
    }

    private void VectorAdd_65_List(object instance, object item)
    {
      ((ICollection<Button>) instance).Add((Button) item);
    }

    private IXamlType CreateXamlType(int typeIndex)
    {
      XamlSystemBaseType xamlType = (XamlSystemBaseType) null;
      string fullName = this._typeNameTable[typeIndex];
      Type type = this._typeTable[typeIndex];
      switch (typeIndex)
      {
        case 0:
          XamlUserType xamlUserType1 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.Converters.ValueConverter"));
          xamlUserType1.Activator = new Activator(this.Activate_0_SolidColorBrushToColorConverter);
          xamlUserType1.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType1;
          break;
        case 1:
          XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType2.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType2;
          break;
        case 2:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 3:
          XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentControl"));
          xamlUserType3.Activator = new Activator(this.Activate_3_ProgressOverlay);
          xamlUserType3.AddMemberName("ProgressControl");
          xamlUserType3.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType3;
          break;
        case 4:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 5:
          XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorBaseControl"));
          xamlUserType4.Activator = new Activator(this.Activate_5_ColorPicker);
          xamlUserType4.AddMemberName("Thumb");
          xamlUserType4.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType4;
          break;
        case 6:
          XamlUserType xamlUserType5 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType5.AddMemberName("Color");
          xamlUserType5.AddMemberName("SolidColorBrush");
          xamlUserType5.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType5;
          break;
        case 7:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 8:
          XamlUserType xamlUserType6 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          xamlUserType6.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType6;
          break;
        case 9:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          break;
        case 10:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 11:
          XamlUserType xamlUserType7 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType7.Activator = new Activator(this.Activate_11_ColorSliderThumb);
          xamlUserType7.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType7;
          break;
        case 12:
          XamlUserType xamlUserType8 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType8.Activator = new Activator(this.Activate_12_SuperSlider);
          xamlUserType8.AddMemberName("Orientation");
          xamlUserType8.AddMemberName("Minimum");
          xamlUserType8.AddMemberName("Maximum");
          xamlUserType8.AddMemberName("Thumb");
          xamlUserType8.AddMemberName("BarHeight");
          xamlUserType8.AddMemberName("BarWidth");
          xamlUserType8.AddMemberName("Title");
          xamlUserType8.AddMemberName("BackgroundSize");
          xamlUserType8.AddMemberName("ProgressSize");
          xamlUserType8.AddMemberName("Value");
          xamlUserType8.AddMemberName("StepFrequency");
          xamlUserType8.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType8;
          break;
        case 13:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 14:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 15:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 16:
          XamlUserType xamlUserType9 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorBaseControl"));
          xamlUserType9.Activator = new Activator(this.Activate_16_ColorSlider);
          xamlUserType9.AddMemberName("IsColorVisible");
          xamlUserType9.AddMemberName("Thumb");
          xamlUserType9.AddMemberName("Orientation");
          xamlUserType9.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType9;
          break;
        case 17:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 18:
          XamlUserType xamlUserType10 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType10.Activator = new Activator(this.Activate_18_MetroFlowItem);
          xamlUserType10.SetContentPropertyName("Coding4Fun.Toolkit.Controls.MetroFlowItem.Title");
          xamlUserType10.AddMemberName("Title");
          xamlUserType10.AddMemberName("ImageSource");
          xamlUserType10.AddMemberName("ImageVisibility");
          xamlUserType10.AddMemberName("ImageOpacity");
          xamlUserType10.AddMemberName("ItemIndexString");
          xamlUserType10.AddMemberName("ItemIndex");
          xamlUserType10.AddMemberName("ItemIndexVisibility");
          xamlUserType10.AddMemberName("ItemIndexOpacity");
          xamlUserType10.AddMemberName("TitleVisibility");
          xamlUserType10.AddMemberName("TitleOpacity");
          xamlUserType10.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType10;
          break;
        case 19:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 20:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 21:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 22:
          XamlUserType xamlUserType11 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.ItemsControl"));
          xamlUserType11.Activator = new Activator(this.Activate_22_MetroFlow);
          xamlUserType11.AddMemberName("AnimationDuration");
          xamlUserType11.AddMemberName("SelectedColumnIndex");
          xamlUserType11.AddMemberName("ExpandingWidth");
          xamlUserType11.AddMemberName("CollapsingWidth");
          xamlUserType11.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType11;
          break;
        case 23:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 24:
          XamlUserType xamlUserType12 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          xamlUserType12.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType12;
          break;
        case 25:
          XamlUserType xamlUserType13 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase"));
          xamlUserType13.Activator = new Activator(this.Activate_25_OpacityToggleButton);
          xamlUserType13.AddMemberName("AnimationDuration");
          xamlUserType13.AddMemberName("UncheckedOpacity");
          xamlUserType13.AddMemberName("CheckedOpacity");
          xamlUserType13.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType13;
          break;
        case 26:
          XamlUserType xamlUserType14 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.CheckBox"));
          xamlUserType14.AddMemberName("ButtonWidth");
          xamlUserType14.AddMemberName("ButtonHeight");
          xamlUserType14.AddMemberName("Label");
          xamlUserType14.AddMemberName("CheckedBrush");
          xamlUserType14.AddMemberName("Orientation");
          xamlUserType14.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType14;
          break;
        case 27:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 28:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 29:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 30:
          XamlUserType xamlUserType15 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ButtonBase"));
          xamlUserType15.Activator = new Activator(this.Activate_30_RectangularButton);
          xamlUserType15.AddMemberName("PressedBrush");
          xamlUserType15.AddMemberName("ButtonWidth");
          xamlUserType15.AddMemberName("ButtonHeight");
          xamlUserType15.AddMemberName("Orientation");
          xamlUserType15.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType15;
          break;
        case 31:
          XamlUserType xamlUserType16 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Button"));
          xamlUserType16.AddMemberName("Label");
          xamlUserType16.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType16;
          break;
        case 32:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 33:
          XamlUserType xamlUserType17 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ButtonBase"));
          xamlUserType17.Activator = new Activator(this.Activate_33_RoundButton);
          xamlUserType17.AddMemberName("PressedBrush");
          xamlUserType17.AddMemberName("ButtonWidth");
          xamlUserType17.AddMemberName("ButtonHeight");
          xamlUserType17.AddMemberName("Orientation");
          xamlUserType17.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType17;
          break;
        case 34:
          XamlUserType xamlUserType18 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase"));
          xamlUserType18.Activator = new Activator(this.Activate_34_RoundToggleButton);
          xamlUserType18.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType18;
          break;
        case 35:
          XamlUserType xamlUserType19 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentControl"));
          xamlUserType19.Activator = new Activator(this.Activate_35_ChatBubble);
          xamlUserType19.AddMemberName("ChatBubbleDirection");
          xamlUserType19.AddMemberName("IsEquallySpaced");
          xamlUserType19.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType19;
          break;
        case 36:
          XamlUserType xamlUserType20 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
          xamlUserType20.AddEnumValue("UpperRight", (object) ChatBubbleDirection.UpperRight);
          xamlUserType20.AddEnumValue("UpperLeft", (object) ChatBubbleDirection.UpperLeft);
          xamlUserType20.AddEnumValue("LowerRight", (object) ChatBubbleDirection.LowerRight);
          xamlUserType20.AddEnumValue("LowerLeft", (object) ChatBubbleDirection.LowerLeft);
          xamlUserType20.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType20;
          break;
        case 37:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          break;
        case 38:
          XamlUserType xamlUserType21 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.TextBox"));
          xamlUserType21.Activator = new Activator(this.Activate_38_ChatBubbleTextBox);
          xamlUserType21.AddMemberName("ChatBubbleDirection");
          xamlUserType21.AddMemberName("Hint");
          xamlUserType21.AddMemberName("HintStyle");
          xamlUserType21.AddMemberName("IsEquallySpaced");
          xamlUserType21.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType21;
          break;
        case 39:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 40:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 41:
          XamlUserType xamlUserType22 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorBaseControl"));
          xamlUserType22.Activator = new Activator(this.Activate_41_ColorHexagonPicker);
          xamlUserType22.AddMemberName("SelectedStrokeColor");
          xamlUserType22.AddMemberName("ColorDarknessSteps");
          xamlUserType22.AddMemberName("ColorBrightnessSteps");
          xamlUserType22.AddMemberName("GreyScaleSteps");
          xamlUserType22.AddMemberName("ColorSize");
          xamlUserType22.AddMemberName("ColorBody");
          xamlUserType22.AddMemberName("GreyScaleBody");
          xamlUserType22.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType22;
          break;
        case 42:
          XamlUserType xamlUserType23 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ButtonBase"));
          xamlUserType23.Activator = new Activator(this.Activate_42_ImageTile);
          xamlUserType23.AddMemberName("Columns");
          xamlUserType23.AddMemberName("Rows");
          xamlUserType23.AddMemberName("LargeTileColumns");
          xamlUserType23.AddMemberName("LargeTileRows");
          xamlUserType23.AddMemberName("ItemsSource");
          xamlUserType23.AddMemberName("AnimationType");
          xamlUserType23.AddMemberName("IsFrozen");
          xamlUserType23.AddMemberName("AnimationDuration");
          xamlUserType23.AddMemberName("ImageCycleInterval");
          xamlUserType23.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType23;
          break;
        case 43:
          XamlUserType xamlUserType24 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType24.CollectionAdd = new AddToCollection(this.VectorAdd_43_List);
          xamlUserType24.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType24;
          break;
        case 44:
          XamlUserType xamlUserType25 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType25.AddMemberName("AbsolutePath");
          xamlUserType25.AddMemberName("AbsoluteUri");
          xamlUserType25.AddMemberName("Authority");
          xamlUserType25.AddMemberName("DnsSafeHost");
          xamlUserType25.AddMemberName("Fragment");
          xamlUserType25.AddMemberName("Host");
          xamlUserType25.AddMemberName("HostNameType");
          xamlUserType25.AddMemberName("IsAbsoluteUri");
          xamlUserType25.AddMemberName("IsDefaultPort");
          xamlUserType25.AddMemberName("IsFile");
          xamlUserType25.AddMemberName("IsLoopback");
          xamlUserType25.AddMemberName("IsUnc");
          xamlUserType25.AddMemberName("LocalPath");
          xamlUserType25.AddMemberName("OriginalString");
          xamlUserType25.AddMemberName("PathAndQuery");
          xamlUserType25.AddMemberName("Port");
          xamlUserType25.AddMemberName("Query");
          xamlUserType25.AddMemberName("Scheme");
          xamlUserType25.AddMemberName("Segments");
          xamlUserType25.AddMemberName("UserEscaped");
          xamlUserType25.AddMemberName("UserInfo");
          xamlType = (XamlSystemBaseType) xamlUserType25;
          break;
        case 45:
          XamlUserType xamlUserType26 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
          xamlUserType26.AddEnumValue("Unknown", (object) UriHostNameType.Unknown);
          xamlUserType26.AddEnumValue("Basic", (object) UriHostNameType.Basic);
          xamlUserType26.AddEnumValue("Dns", (object) UriHostNameType.Dns);
          xamlUserType26.AddEnumValue("IPv4", (object) UriHostNameType.IPv4);
          xamlUserType26.AddEnumValue("IPv6", (object) UriHostNameType.IPv6);
          xamlType = (XamlSystemBaseType) xamlUserType26;
          break;
        case 46:
          XamlUserType xamlUserType27 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Array"));
          xamlUserType27.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType27;
          break;
        case 47:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          break;
        case 48:
          XamlUserType xamlUserType28 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
          xamlUserType28.AddEnumValue("Fade", (object) ImageTileAnimationTypes.Fade);
          xamlUserType28.AddEnumValue("HorizontalExpand", (object) ImageTileAnimationTypes.HorizontalExpand);
          xamlUserType28.AddEnumValue("VerticalExpand", (object) ImageTileAnimationTypes.VerticalExpand);
          xamlUserType28.AddEnumValue("None", (object) ImageTileAnimationTypes.None);
          xamlUserType28.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType28;
          break;
        case 49:
          XamlUserType xamlUserType29 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType29.Activator = new Activator(this.Activate_49_SuperImage);
          xamlUserType29.AddMemberName("Stretch");
          xamlUserType29.AddMemberName("Sources");
          xamlUserType29.AddMemberName("PlaceholderImageSource");
          xamlUserType29.AddMemberName("PlaceholderOpacity");
          xamlUserType29.AddMemberName("Source");
          xamlUserType29.AddMemberName("PlaceholderBackground");
          xamlUserType29.AddMemberName("PlaceholderImageStretch");
          xamlUserType29.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType29;
          break;
        case 50:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 51:
          XamlUserType xamlUserType30 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<Coding4Fun.Toolkit.Controls.SuperImageSource>"));
          xamlUserType30.CollectionAdd = new AddToCollection(this.VectorAdd_51_ObservableCollection);
          xamlUserType30.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType30;
          break;
        case 52:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
          {
            Activator = new Activator(this.Activate_52_Collection),
            CollectionAdd = new AddToCollection(this.VectorAdd_52_Collection)
          };
          break;
        case 53:
          XamlUserType xamlUserType31 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.DependencyObject"));
          xamlUserType31.Activator = new Activator(this.Activate_53_SuperImageSource);
          xamlUserType31.AddMemberName("MinScale");
          xamlUserType31.AddMemberName("MaxScale");
          xamlUserType31.AddMemberName("Source");
          xamlUserType31.AddMemberName("IsDefault");
          xamlUserType31.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType31;
          break;
        case 54:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 55:
          XamlUserType xamlUserType32 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ButtonBase"));
          xamlUserType32.Activator = new Activator(this.Activate_55_Tile);
          xamlUserType32.AddMemberName("TextWrapping");
          xamlUserType32.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType32;
          break;
        case 56:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 57:
          XamlUserType xamlUserType33 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.ContentControl"));
          xamlUserType33.Activator = new Activator(this.Activate_57_TileNotification);
          xamlUserType33.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType33;
          break;
        case 58:
          XamlUserType xamlUserType34 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.InputPrompt"));
          xamlUserType34.Activator = new Activator(this.Activate_58_PasswordInputPrompt);
          xamlUserType34.AddMemberName("PasswordChar");
          xamlUserType34.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType34;
          break;
        case 59:
          XamlUserType xamlUserType35 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.UserPrompt"));
          xamlUserType35.Activator = new Activator(this.Activate_59_InputPrompt);
          xamlUserType35.AddMemberName("IsSubmitOnEnterKey");
          xamlUserType35.AddMemberName("MessageTextWrapping");
          xamlUserType35.AddMemberName("InputScope");
          xamlUserType35.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType35;
          break;
        case 60:
          XamlUserType xamlUserType36 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ActionPopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>"));
          xamlUserType36.AddMemberName("IsCancelVisible");
          xamlUserType36.AddMemberName("Value");
          xamlUserType36.AddMemberName("Title");
          xamlUserType36.AddMemberName("Message");
          xamlUserType36.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType36;
          break;
        case 61:
          XamlUserType xamlUserType37 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>"));
          xamlUserType37.Activator = new Activator(this.Activate_61_ActionPopUp);
          xamlUserType37.AddMemberName("ActionPopUpButtons");
          xamlUserType37.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType37;
          break;
        case 62:
          XamlUserType xamlUserType38 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType38.AddMemberName("Overlay");
          xamlUserType38.AddMemberName("IsOpen");
          xamlUserType38.AddMemberName("IsAppBarVisible");
          xamlUserType38.AddMemberName("IsOverlayApplied");
          xamlUserType38.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType38;
          break;
        case 63:
          XamlUserType xamlUserType39 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          xamlUserType39.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType39;
          break;
        case 64:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 65:
          XamlUserType xamlUserType40 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType40.CollectionAdd = new AddToCollection(this.VectorAdd_65_List);
          xamlUserType40.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType40;
          break;
        case 66:
          XamlUserType xamlUserType41 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>"));
          xamlUserType41.Activator = new Activator(this.Activate_66_ToastPrompt);
          xamlUserType41.AddMemberName("MillisecondsUntilHidden");
          xamlUserType41.AddMemberName("IsTimerEnabled");
          xamlUserType41.AddMemberName("Title");
          xamlUserType41.AddMemberName("Message");
          xamlUserType41.AddMemberName("ImageSource");
          xamlUserType41.AddMemberName("Stretch");
          xamlUserType41.AddMemberName("ImageWidth");
          xamlUserType41.AddMemberName("ImageHeight");
          xamlUserType41.AddMemberName("TextOrientation");
          xamlUserType41.AddMemberName("TextWrapping");
          xamlUserType41.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType41;
          break;
        case 67:
          XamlUserType xamlUserType42 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ActionPopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>"));
          xamlUserType42.Activator = new Activator(this.Activate_67_AboutPrompt);
          xamlUserType42.AddMemberName("IsPromptMode");
          xamlUserType42.AddMemberName("WaterMark");
          xamlUserType42.AddMemberName("VersionNumber");
          xamlUserType42.AddMemberName("Body");
          xamlUserType42.AddMemberName("Footer");
          xamlUserType42.AddMemberName("Title");
          xamlUserType42.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType42;
          break;
        case 68:
          XamlUserType xamlUserType43 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>"));
          xamlUserType43.Activator = new Activator(this.Activate_68_ActionPopUp);
          xamlUserType43.AddMemberName("ActionPopUpButtons");
          xamlUserType43.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType43;
          break;
        case 69:
          XamlUserType xamlUserType44 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType44.AddMemberName("Overlay");
          xamlUserType44.AddMemberName("IsOpen");
          xamlUserType44.AddMemberName("IsAppBarVisible");
          xamlUserType44.AddMemberName("IsOverlayApplied");
          xamlUserType44.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType44;
          break;
        case 70:
          XamlUserType xamlUserType45 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType45.Activator = new Activator(this.Activate_70_AboutPromptItem);
          xamlUserType45.AddMemberName("WebSiteUrl");
          xamlUserType45.AddMemberName("Role");
          xamlUserType45.AddMemberName("EmailAddress");
          xamlUserType45.AddMemberName("AuthorName");
          xamlUserType45.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType45;
          break;
        case 71:
          XamlUserType xamlUserType46 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.UserPrompt"));
          xamlUserType46.Activator = new Activator(this.Activate_71_MessagePrompt);
          xamlUserType46.AddMemberName("Body");
          xamlUserType46.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType46;
          break;
      }
      return (IXamlType) xamlType;
    }

    private object get_0_ProgressOverlay_ProgressControl(object instance)
    {
      return ((ProgressOverlay) instance).ProgressControl;
    }

    private void set_0_ProgressOverlay_ProgressControl(object instance, object Value)
    {
      ((ProgressOverlay) instance).ProgressControl = Value;
    }

    private object get_1_ColorPicker_Thumb(object instance) => ((ColorPicker) instance).Thumb;

    private void set_1_ColorPicker_Thumb(object instance, object Value)
    {
      ((ColorPicker) instance).Thumb = Value;
    }

    private object get_2_ColorBaseControl_Color(object instance)
    {
      return (object) ((ColorBaseControl) instance).Color;
    }

    private void set_2_ColorBaseControl_Color(object instance, object Value)
    {
      ((ColorBaseControl) instance).Color = (Color) Value;
    }

    private object get_3_ColorBaseControl_SolidColorBrush(object instance)
    {
      return (object) ((ColorBaseControl) instance).SolidColorBrush;
    }

    private object get_4_SuperSlider_Orientation(object instance)
    {
      return (object) ((SuperSlider) instance).Orientation;
    }

    private void set_4_SuperSlider_Orientation(object instance, object Value)
    {
      ((SuperSlider) instance).Orientation = (Orientation) Value;
    }

    private object get_5_SuperSlider_Minimum(object instance)
    {
      return (object) ((SuperSlider) instance).Minimum;
    }

    private void set_5_SuperSlider_Minimum(object instance, object Value)
    {
      ((SuperSlider) instance).Minimum = (double) Value;
    }

    private object get_6_SuperSlider_Maximum(object instance)
    {
      return (object) ((SuperSlider) instance).Maximum;
    }

    private void set_6_SuperSlider_Maximum(object instance, object Value)
    {
      ((SuperSlider) instance).Maximum = (double) Value;
    }

    private object get_7_SuperSlider_Thumb(object instance) => ((SuperSlider) instance).Thumb;

    private void set_7_SuperSlider_Thumb(object instance, object Value)
    {
      ((SuperSlider) instance).Thumb = Value;
    }

    private object get_8_SuperSlider_BarHeight(object instance)
    {
      return (object) ((SuperSlider) instance).BarHeight;
    }

    private void set_8_SuperSlider_BarHeight(object instance, object Value)
    {
      ((SuperSlider) instance).BarHeight = (double) Value;
    }

    private object get_9_SuperSlider_BarWidth(object instance)
    {
      return (object) ((SuperSlider) instance).BarWidth;
    }

    private void set_9_SuperSlider_BarWidth(object instance, object Value)
    {
      ((SuperSlider) instance).BarWidth = (double) Value;
    }

    private object get_10_SuperSlider_Title(object instance)
    {
      return (object) ((SuperSlider) instance).Title;
    }

    private void set_10_SuperSlider_Title(object instance, object Value)
    {
      ((SuperSlider) instance).Title = (string) Value;
    }

    private object get_11_SuperSlider_BackgroundSize(object instance)
    {
      return (object) ((SuperSlider) instance).BackgroundSize;
    }

    private void set_11_SuperSlider_BackgroundSize(object instance, object Value)
    {
      ((SuperSlider) instance).BackgroundSize = (double) Value;
    }

    private object get_12_SuperSlider_ProgressSize(object instance)
    {
      return (object) ((SuperSlider) instance).ProgressSize;
    }

    private void set_12_SuperSlider_ProgressSize(object instance, object Value)
    {
      ((SuperSlider) instance).ProgressSize = (double) Value;
    }

    private object get_13_SuperSlider_Value(object instance)
    {
      return (object) ((SuperSlider) instance).Value;
    }

    private void set_13_SuperSlider_Value(object instance, object Value)
    {
      ((SuperSlider) instance).Value = (double) Value;
    }

    private object get_14_SuperSlider_StepFrequency(object instance)
    {
      return (object) ((SuperSlider) instance).StepFrequency;
    }

    private void set_14_SuperSlider_StepFrequency(object instance, object Value)
    {
      ((SuperSlider) instance).StepFrequency = (double) Value;
    }

    private object get_15_ColorSlider_IsColorVisible(object instance)
    {
      return (object) ((ColorSlider) instance).IsColorVisible;
    }

    private void set_15_ColorSlider_IsColorVisible(object instance, object Value)
    {
      ((ColorSlider) instance).IsColorVisible = (bool) Value;
    }

    private object get_16_ColorSlider_Thumb(object instance) => ((ColorSlider) instance).Thumb;

    private void set_16_ColorSlider_Thumb(object instance, object Value)
    {
      ((ColorSlider) instance).Thumb = Value;
    }

    private object get_17_ColorSlider_Orientation(object instance)
    {
      return (object) ((ColorSlider) instance).Orientation;
    }

    private void set_17_ColorSlider_Orientation(object instance, object Value)
    {
      ((ColorSlider) instance).Orientation = (Orientation) Value;
    }

    private object get_18_MetroFlowItem_Title(object instance)
    {
      return (object) ((MetroFlowItem) instance).Title;
    }

    private void set_18_MetroFlowItem_Title(object instance, object Value)
    {
      ((MetroFlowItem) instance).Title = (string) Value;
    }

    private object get_19_MetroFlowItem_ImageSource(object instance)
    {
      return (object) ((MetroFlowItem) instance).ImageSource;
    }

    private void set_19_MetroFlowItem_ImageSource(object instance, object Value)
    {
      ((MetroFlowItem) instance).ImageSource = (ImageSource) Value;
    }

    private object get_20_MetroFlowItem_ImageVisibility(object instance)
    {
      return (object) ((MetroFlowItem) instance).ImageVisibility;
    }

    private void set_20_MetroFlowItem_ImageVisibility(object instance, object Value)
    {
      ((MetroFlowItem) instance).ImageVisibility = (Visibility) Value;
    }

    private object get_21_MetroFlowItem_ImageOpacity(object instance)
    {
      return (object) ((MetroFlowItem) instance).ImageOpacity;
    }

    private void set_21_MetroFlowItem_ImageOpacity(object instance, object Value)
    {
      ((MetroFlowItem) instance).ImageOpacity = (double) Value;
    }

    private object get_22_MetroFlowItem_ItemIndexString(object instance)
    {
      return (object) ((MetroFlowItem) instance).ItemIndexString;
    }

    private object get_23_MetroFlowItem_ItemIndex(object instance)
    {
      return (object) ((MetroFlowItem) instance).ItemIndex;
    }

    private void set_23_MetroFlowItem_ItemIndex(object instance, object Value)
    {
      ((MetroFlowItem) instance).ItemIndex = (int) Value;
    }

    private object get_24_MetroFlowItem_ItemIndexVisibility(object instance)
    {
      return (object) ((MetroFlowItem) instance).ItemIndexVisibility;
    }

    private void set_24_MetroFlowItem_ItemIndexVisibility(object instance, object Value)
    {
      ((MetroFlowItem) instance).ItemIndexVisibility = (Visibility) Value;
    }

    private object get_25_MetroFlowItem_ItemIndexOpacity(object instance)
    {
      return (object) ((MetroFlowItem) instance).ItemIndexOpacity;
    }

    private void set_25_MetroFlowItem_ItemIndexOpacity(object instance, object Value)
    {
      ((MetroFlowItem) instance).ItemIndexOpacity = (double) Value;
    }

    private object get_26_MetroFlowItem_TitleVisibility(object instance)
    {
      return (object) ((MetroFlowItem) instance).TitleVisibility;
    }

    private void set_26_MetroFlowItem_TitleVisibility(object instance, object Value)
    {
      ((MetroFlowItem) instance).TitleVisibility = (Visibility) Value;
    }

    private object get_27_MetroFlowItem_TitleOpacity(object instance)
    {
      return (object) ((MetroFlowItem) instance).TitleOpacity;
    }

    private void set_27_MetroFlowItem_TitleOpacity(object instance, object Value)
    {
      ((MetroFlowItem) instance).TitleOpacity = (double) Value;
    }

    private object get_28_MetroFlow_AnimationDuration(object instance)
    {
      return (object) ((MetroFlow) instance).AnimationDuration;
    }

    private void set_28_MetroFlow_AnimationDuration(object instance, object Value)
    {
      ((MetroFlow) instance).AnimationDuration = (TimeSpan) Value;
    }

    private object get_29_MetroFlow_SelectedColumnIndex(object instance)
    {
      return (object) ((MetroFlow) instance).SelectedColumnIndex;
    }

    private void set_29_MetroFlow_SelectedColumnIndex(object instance, object Value)
    {
      ((MetroFlow) instance).SelectedColumnIndex = (int) Value;
    }

    private object get_30_MetroFlow_ExpandingWidth(object instance)
    {
      return (object) ((MetroFlow) instance).ExpandingWidth;
    }

    private void set_30_MetroFlow_ExpandingWidth(object instance, object Value)
    {
      ((MetroFlow) instance).ExpandingWidth = (double) Value;
    }

    private object get_31_MetroFlow_CollapsingWidth(object instance)
    {
      return (object) ((MetroFlow) instance).CollapsingWidth;
    }

    private void set_31_MetroFlow_CollapsingWidth(object instance, object Value)
    {
      ((MetroFlow) instance).CollapsingWidth = (double) Value;
    }

    private object get_32_ToggleButtonBase_ButtonWidth(object instance)
    {
      return (object) ((ToggleButtonBase) instance).ButtonWidth;
    }

    private void set_32_ToggleButtonBase_ButtonWidth(object instance, object Value)
    {
      ((ToggleButtonBase) instance).ButtonWidth = (double) Value;
    }

    private object get_33_ToggleButtonBase_ButtonHeight(object instance)
    {
      return (object) ((ToggleButtonBase) instance).ButtonHeight;
    }

    private void set_33_ToggleButtonBase_ButtonHeight(object instance, object Value)
    {
      ((ToggleButtonBase) instance).ButtonHeight = (double) Value;
    }

    private object get_34_OpacityToggleButton_AnimationDuration(object instance)
    {
      return (object) ((OpacityToggleButton) instance).AnimationDuration;
    }

    private void set_34_OpacityToggleButton_AnimationDuration(object instance, object Value)
    {
      ((OpacityToggleButton) instance).AnimationDuration = (Duration) Value;
    }

    private object get_35_OpacityToggleButton_UncheckedOpacity(object instance)
    {
      return (object) ((OpacityToggleButton) instance).UncheckedOpacity;
    }

    private void set_35_OpacityToggleButton_UncheckedOpacity(object instance, object Value)
    {
      ((OpacityToggleButton) instance).UncheckedOpacity = (double) Value;
    }

    private object get_36_OpacityToggleButton_CheckedOpacity(object instance)
    {
      return (object) ((OpacityToggleButton) instance).CheckedOpacity;
    }

    private void set_36_OpacityToggleButton_CheckedOpacity(object instance, object Value)
    {
      ((OpacityToggleButton) instance).CheckedOpacity = (double) Value;
    }

    private object get_37_ToggleButtonBase_Label(object instance)
    {
      return ((ToggleButtonBase) instance).Label;
    }

    private void set_37_ToggleButtonBase_Label(object instance, object Value)
    {
      ((ToggleButtonBase) instance).Label = Value;
    }

    private object get_38_ToggleButtonBase_CheckedBrush(object instance)
    {
      return (object) ((ToggleButtonBase) instance).CheckedBrush;
    }

    private void set_38_ToggleButtonBase_CheckedBrush(object instance, object Value)
    {
      ((ToggleButtonBase) instance).CheckedBrush = (Brush) Value;
    }

    private object get_39_ToggleButtonBase_Orientation(object instance)
    {
      return (object) ((ToggleButtonBase) instance).Orientation;
    }

    private void set_39_ToggleButtonBase_Orientation(object instance, object Value)
    {
      ((ToggleButtonBase) instance).Orientation = (Orientation) Value;
    }

    private object get_40_RectangularButton_PressedBrush(object instance)
    {
      return (object) ((RectangularButton) instance).PressedBrush;
    }

    private void set_40_RectangularButton_PressedBrush(object instance, object Value)
    {
      ((RectangularButton) instance).PressedBrush = (Brush) Value;
    }

    private object get_41_RectangularButton_ButtonWidth(object instance)
    {
      return (object) ((RectangularButton) instance).ButtonWidth;
    }

    private void set_41_RectangularButton_ButtonWidth(object instance, object Value)
    {
      ((RectangularButton) instance).ButtonWidth = (double) Value;
    }

    private object get_42_RectangularButton_ButtonHeight(object instance)
    {
      return (object) ((RectangularButton) instance).ButtonHeight;
    }

    private void set_42_RectangularButton_ButtonHeight(object instance, object Value)
    {
      ((RectangularButton) instance).ButtonHeight = (double) Value;
    }

    private object get_43_RectangularButton_Orientation(object instance)
    {
      return (object) ((RectangularButton) instance).Orientation;
    }

    private void set_43_RectangularButton_Orientation(object instance, object Value)
    {
      ((RectangularButton) instance).Orientation = (Orientation) Value;
    }

    private object get_44_ButtonBase_Label(object instance) => ((ButtonBase) instance).Label;

    private void set_44_ButtonBase_Label(object instance, object Value)
    {
      ((ButtonBase) instance).Label = Value;
    }

    private object get_45_RoundButton_PressedBrush(object instance)
    {
      return (object) ((RoundButton) instance).PressedBrush;
    }

    private void set_45_RoundButton_PressedBrush(object instance, object Value)
    {
      ((RoundButton) instance).PressedBrush = (Brush) Value;
    }

    private object get_46_RoundButton_ButtonWidth(object instance)
    {
      return (object) ((RoundButton) instance).ButtonWidth;
    }

    private void set_46_RoundButton_ButtonWidth(object instance, object Value)
    {
      ((RoundButton) instance).ButtonWidth = (double) Value;
    }

    private object get_47_RoundButton_ButtonHeight(object instance)
    {
      return (object) ((RoundButton) instance).ButtonHeight;
    }

    private void set_47_RoundButton_ButtonHeight(object instance, object Value)
    {
      ((RoundButton) instance).ButtonHeight = (double) Value;
    }

    private object get_48_RoundButton_Orientation(object instance)
    {
      return (object) ((RoundButton) instance).Orientation;
    }

    private void set_48_RoundButton_Orientation(object instance, object Value)
    {
      ((RoundButton) instance).Orientation = (Orientation) Value;
    }

    private object get_49_ChatBubble_ChatBubbleDirection(object instance)
    {
      return (object) ((ChatBubble) instance).ChatBubbleDirection;
    }

    private void set_49_ChatBubble_ChatBubbleDirection(object instance, object Value)
    {
      ((ChatBubble) instance).ChatBubbleDirection = (ChatBubbleDirection) Value;
    }

    private object get_50_ChatBubble_IsEquallySpaced(object instance)
    {
      return (object) ((ChatBubble) instance).IsEquallySpaced;
    }

    private void set_50_ChatBubble_IsEquallySpaced(object instance, object Value)
    {
      ((ChatBubble) instance).IsEquallySpaced = (bool) Value;
    }

    private object get_51_ChatBubbleTextBox_ChatBubbleDirection(object instance)
    {
      return (object) ((ChatBubbleTextBox) instance).ChatBubbleDirection;
    }

    private void set_51_ChatBubbleTextBox_ChatBubbleDirection(object instance, object Value)
    {
      ((ChatBubbleTextBox) instance).ChatBubbleDirection = (ChatBubbleDirection) Value;
    }

    private object get_52_ChatBubbleTextBox_Hint(object instance)
    {
      return (object) ((ChatBubbleTextBox) instance).Hint;
    }

    private void set_52_ChatBubbleTextBox_Hint(object instance, object Value)
    {
      ((ChatBubbleTextBox) instance).Hint = (string) Value;
    }

    private object get_53_ChatBubbleTextBox_HintStyle(object instance)
    {
      return (object) ((ChatBubbleTextBox) instance).HintStyle;
    }

    private void set_53_ChatBubbleTextBox_HintStyle(object instance, object Value)
    {
      ((ChatBubbleTextBox) instance).HintStyle = (Style) Value;
    }

    private object get_54_ChatBubbleTextBox_IsEquallySpaced(object instance)
    {
      return (object) ((ChatBubbleTextBox) instance).IsEquallySpaced;
    }

    private void set_54_ChatBubbleTextBox_IsEquallySpaced(object instance, object Value)
    {
      ((ChatBubbleTextBox) instance).IsEquallySpaced = (bool) Value;
    }

    private object get_55_ColorHexagonPicker_SelectedStrokeColor(object instance)
    {
      return (object) ((ColorHexagonPicker) instance).SelectedStrokeColor;
    }

    private void set_55_ColorHexagonPicker_SelectedStrokeColor(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).SelectedStrokeColor = (Color) Value;
    }

    private object get_56_ColorHexagonPicker_ColorDarknessSteps(object instance)
    {
      return (object) ((ColorHexagonPicker) instance).ColorDarknessSteps;
    }

    private void set_56_ColorHexagonPicker_ColorDarknessSteps(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).ColorDarknessSteps = (int) Value;
    }

    private object get_57_ColorHexagonPicker_ColorBrightnessSteps(object instance)
    {
      return (object) ((ColorHexagonPicker) instance).ColorBrightnessSteps;
    }

    private void set_57_ColorHexagonPicker_ColorBrightnessSteps(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).ColorBrightnessSteps = (int) Value;
    }

    private object get_58_ColorHexagonPicker_GreyScaleSteps(object instance)
    {
      return (object) ((ColorHexagonPicker) instance).GreyScaleSteps;
    }

    private void set_58_ColorHexagonPicker_GreyScaleSteps(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).GreyScaleSteps = (int) Value;
    }

    private object get_59_ColorHexagonPicker_ColorSize(object instance)
    {
      return (object) ((ColorHexagonPicker) instance).ColorSize;
    }

    private void set_59_ColorHexagonPicker_ColorSize(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).ColorSize = (double) Value;
    }

    private object get_60_ColorHexagonPicker_ColorBody(object instance)
    {
      return ((ColorHexagonPicker) instance).ColorBody;
    }

    private void set_60_ColorHexagonPicker_ColorBody(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).ColorBody = Value;
    }

    private object get_61_ColorHexagonPicker_GreyScaleBody(object instance)
    {
      return ((ColorHexagonPicker) instance).GreyScaleBody;
    }

    private void set_61_ColorHexagonPicker_GreyScaleBody(object instance, object Value)
    {
      ((ColorHexagonPicker) instance).GreyScaleBody = Value;
    }

    private object get_62_ImageTile_Columns(object instance)
    {
      return (object) ((ImageTile) instance).Columns;
    }

    private void set_62_ImageTile_Columns(object instance, object Value)
    {
      ((ImageTile) instance).Columns = (int) Value;
    }

    private object get_63_ImageTile_Rows(object instance) => (object) ((ImageTile) instance).Rows;

    private void set_63_ImageTile_Rows(object instance, object Value)
    {
      ((ImageTile) instance).Rows = (int) Value;
    }

    private object get_64_ImageTile_LargeTileColumns(object instance)
    {
      return (object) ((ImageTile) instance).LargeTileColumns;
    }

    private void set_64_ImageTile_LargeTileColumns(object instance, object Value)
    {
      ((ImageTile) instance).LargeTileColumns = (int) Value;
    }

    private object get_65_ImageTile_LargeTileRows(object instance)
    {
      return (object) ((ImageTile) instance).LargeTileRows;
    }

    private void set_65_ImageTile_LargeTileRows(object instance, object Value)
    {
      ((ImageTile) instance).LargeTileRows = (int) Value;
    }

    private object get_66_ImageTile_ItemsSource(object instance)
    {
      return (object) ((ImageTile) instance).ItemsSource;
    }

    private void set_66_ImageTile_ItemsSource(object instance, object Value)
    {
      ((ImageTile) instance).ItemsSource = (List<Uri>) Value;
    }

    private object get_67_Uri_AbsolutePath(object instance)
    {
      return (object) ((Uri) instance).AbsolutePath;
    }

    private object get_68_Uri_AbsoluteUri(object instance) => (object) ((Uri) instance).AbsoluteUri;

    private object get_69_Uri_Authority(object instance) => (object) ((Uri) instance).Authority;

    private object get_70_Uri_DnsSafeHost(object instance) => (object) ((Uri) instance).DnsSafeHost;

    private object get_71_Uri_Fragment(object instance) => (object) ((Uri) instance).Fragment;

    private object get_72_Uri_Host(object instance) => (object) ((Uri) instance).Host;

    private object get_73_Uri_HostNameType(object instance)
    {
      return (object) ((Uri) instance).HostNameType;
    }

    private object get_74_Uri_IsAbsoluteUri(object instance)
    {
      return (object) ((Uri) instance).IsAbsoluteUri;
    }

    private object get_75_Uri_IsDefaultPort(object instance)
    {
      return (object) ((Uri) instance).IsDefaultPort;
    }

    private object get_76_Uri_IsFile(object instance) => (object) ((Uri) instance).IsFile;

    private object get_77_Uri_IsLoopback(object instance) => (object) ((Uri) instance).IsLoopback;

    private object get_78_Uri_IsUnc(object instance) => (object) ((Uri) instance).IsUnc;

    private object get_79_Uri_LocalPath(object instance) => (object) ((Uri) instance).LocalPath;

    private object get_80_Uri_OriginalString(object instance)
    {
      return (object) ((Uri) instance).OriginalString;
    }

    private object get_81_Uri_PathAndQuery(object instance)
    {
      return (object) ((Uri) instance).PathAndQuery;
    }

    private object get_82_Uri_Port(object instance) => (object) ((Uri) instance).Port;

    private object get_83_Uri_Query(object instance) => (object) ((Uri) instance).Query;

    private object get_84_Uri_Scheme(object instance) => (object) ((Uri) instance).Scheme;

    private object get_85_Uri_Segments(object instance) => (object) ((Uri) instance).Segments;

    private object get_86_Uri_UserEscaped(object instance) => (object) ((Uri) instance).UserEscaped;

    private object get_87_Uri_UserInfo(object instance) => (object) ((Uri) instance).UserInfo;

    private object get_88_ImageTile_AnimationType(object instance)
    {
      return (object) ((ImageTile) instance).AnimationType;
    }

    private void set_88_ImageTile_AnimationType(object instance, object Value)
    {
      ((ImageTile) instance).AnimationType = (ImageTileAnimationTypes) Value;
    }

    private object get_89_ImageTile_IsFrozen(object instance)
    {
      return (object) ((ImageTile) instance).IsFrozen;
    }

    private void set_89_ImageTile_IsFrozen(object instance, object Value)
    {
      ((ImageTile) instance).IsFrozen = (bool) Value;
    }

    private object get_90_ImageTile_AnimationDuration(object instance)
    {
      return (object) ((ImageTile) instance).AnimationDuration;
    }

    private void set_90_ImageTile_AnimationDuration(object instance, object Value)
    {
      ((ImageTile) instance).AnimationDuration = (int) Value;
    }

    private object get_91_ImageTile_ImageCycleInterval(object instance)
    {
      return (object) ((ImageTile) instance).ImageCycleInterval;
    }

    private void set_91_ImageTile_ImageCycleInterval(object instance, object Value)
    {
      ((ImageTile) instance).ImageCycleInterval = (int) Value;
    }

    private object get_92_SuperImage_Stretch(object instance)
    {
      return (object) ((SuperImage) instance).Stretch;
    }

    private void set_92_SuperImage_Stretch(object instance, object Value)
    {
      ((SuperImage) instance).Stretch = (Stretch) Value;
    }

    private object get_93_SuperImage_Sources(object instance)
    {
      return (object) ((SuperImage) instance).Sources;
    }

    private void set_93_SuperImage_Sources(object instance, object Value)
    {
      ((SuperImage) instance).Sources = (ObservableCollection<SuperImageSource>) Value;
    }

    private object get_94_SuperImageSource_MinScale(object instance)
    {
      return (object) ((SuperImageSource) instance).MinScale;
    }

    private void set_94_SuperImageSource_MinScale(object instance, object Value)
    {
      ((SuperImageSource) instance).MinScale = (int) Value;
    }

    private object get_95_SuperImageSource_MaxScale(object instance)
    {
      return (object) ((SuperImageSource) instance).MaxScale;
    }

    private void set_95_SuperImageSource_MaxScale(object instance, object Value)
    {
      ((SuperImageSource) instance).MaxScale = (int) Value;
    }

    private object get_96_SuperImageSource_Source(object instance)
    {
      return (object) ((SuperImageSource) instance).Source;
    }

    private void set_96_SuperImageSource_Source(object instance, object Value)
    {
      ((SuperImageSource) instance).Source = (ImageSource) Value;
    }

    private object get_97_SuperImageSource_IsDefault(object instance)
    {
      return (object) ((SuperImageSource) instance).IsDefault;
    }

    private void set_97_SuperImageSource_IsDefault(object instance, object Value)
    {
      ((SuperImageSource) instance).IsDefault = (bool) Value;
    }

    private object get_98_SuperImage_PlaceholderImageSource(object instance)
    {
      return (object) ((SuperImage) instance).PlaceholderImageSource;
    }

    private void set_98_SuperImage_PlaceholderImageSource(object instance, object Value)
    {
      ((SuperImage) instance).PlaceholderImageSource = (ImageSource) Value;
    }

    private object get_99_SuperImage_PlaceholderOpacity(object instance)
    {
      return (object) ((SuperImage) instance).PlaceholderOpacity;
    }

    private void set_99_SuperImage_PlaceholderOpacity(object instance, object Value)
    {
      ((SuperImage) instance).PlaceholderOpacity = (double) Value;
    }

    private object get_100_SuperImage_Source(object instance)
    {
      return (object) ((SuperImage) instance).Source;
    }

    private void set_100_SuperImage_Source(object instance, object Value)
    {
      ((SuperImage) instance).Source = (ImageSource) Value;
    }

    private object get_101_SuperImage_PlaceholderBackground(object instance)
    {
      return (object) ((SuperImage) instance).PlaceholderBackground;
    }

    private void set_101_SuperImage_PlaceholderBackground(object instance, object Value)
    {
      ((SuperImage) instance).PlaceholderBackground = (SolidColorBrush) Value;
    }

    private object get_102_SuperImage_PlaceholderImageStretch(object instance)
    {
      return (object) ((SuperImage) instance).PlaceholderImageStretch;
    }

    private void set_102_SuperImage_PlaceholderImageStretch(object instance, object Value)
    {
      ((SuperImage) instance).PlaceholderImageStretch = (Stretch) Value;
    }

    private object get_103_Tile_TextWrapping(object instance)
    {
      return (object) ((Tile) instance).TextWrapping;
    }

    private void set_103_Tile_TextWrapping(object instance, object Value)
    {
      ((Tile) instance).TextWrapping = (TextWrapping) Value;
    }

    private object get_104_PopUp_Overlay(object instance)
    {
      return (object) ((PopUp<string, PopUpResult>) instance).Overlay;
    }

    private void set_104_PopUp_Overlay(object instance, object Value)
    {
      ((PopUp<string, PopUpResult>) instance).Overlay = (Brush) Value;
    }

    private object get_105_PasswordInputPrompt_PasswordChar(object instance)
    {
      return (object) ((PasswordInputPrompt) instance).PasswordChar;
    }

    private void set_105_PasswordInputPrompt_PasswordChar(object instance, object Value)
    {
      ((PasswordInputPrompt) instance).PasswordChar = (char) Value;
    }

    private object get_106_InputPrompt_IsSubmitOnEnterKey(object instance)
    {
      return (object) ((InputPrompt) instance).IsSubmitOnEnterKey;
    }

    private void set_106_InputPrompt_IsSubmitOnEnterKey(object instance, object Value)
    {
      ((InputPrompt) instance).IsSubmitOnEnterKey = (bool) Value;
    }

    private object get_107_InputPrompt_MessageTextWrapping(object instance)
    {
      return (object) ((InputPrompt) instance).MessageTextWrapping;
    }

    private void set_107_InputPrompt_MessageTextWrapping(object instance, object Value)
    {
      ((InputPrompt) instance).MessageTextWrapping = (TextWrapping) Value;
    }

    private object get_108_InputPrompt_InputScope(object instance)
    {
      return (object) ((InputPrompt) instance).InputScope;
    }

    private void set_108_InputPrompt_InputScope(object instance, object Value)
    {
      ((InputPrompt) instance).InputScope = (InputScope) Value;
    }

    private object get_109_UserPrompt_IsCancelVisible(object instance)
    {
      return (object) ((UserPrompt) instance).IsCancelVisible;
    }

    private void set_109_UserPrompt_IsCancelVisible(object instance, object Value)
    {
      ((UserPrompt) instance).IsCancelVisible = (bool) Value;
    }

    private object get_110_UserPrompt_Value(object instance)
    {
      return (object) ((UserPrompt) instance).Value;
    }

    private void set_110_UserPrompt_Value(object instance, object Value)
    {
      ((UserPrompt) instance).Value = (string) Value;
    }

    private object get_111_UserPrompt_Title(object instance)
    {
      return (object) ((UserPrompt) instance).Title;
    }

    private void set_111_UserPrompt_Title(object instance, object Value)
    {
      ((UserPrompt) instance).Title = (string) Value;
    }

    private object get_112_UserPrompt_Message(object instance)
    {
      return (object) ((UserPrompt) instance).Message;
    }

    private void set_112_UserPrompt_Message(object instance, object Value)
    {
      ((UserPrompt) instance).Message = (string) Value;
    }

    private object get_113_ActionPopUp_ActionPopUpButtons(object instance)
    {
      return (object) ((ActionPopUp<string, PopUpResult>) instance).ActionPopUpButtons;
    }

    private void set_113_ActionPopUp_ActionPopUpButtons(object instance, object Value)
    {
      ((ActionPopUp<string, PopUpResult>) instance).ActionPopUpButtons = (List<Button>) Value;
    }

    private object get_114_PopUp_IsOpen(object instance)
    {
      return (object) ((PopUp<string, PopUpResult>) instance).IsOpen;
    }

    private object get_115_PopUp_IsAppBarVisible(object instance)
    {
      return (object) ((PopUp<string, PopUpResult>) instance).IsAppBarVisible;
    }

    private void set_115_PopUp_IsAppBarVisible(object instance, object Value)
    {
      ((PopUp<string, PopUpResult>) instance).IsAppBarVisible = (bool) Value;
    }

    private object get_116_PopUp_IsOverlayApplied(object instance)
    {
      return (object) ((PopUp<string, PopUpResult>) instance).IsOverlayApplied;
    }

    private void set_116_PopUp_IsOverlayApplied(object instance, object Value)
    {
      ((PopUp<string, PopUpResult>) instance).IsOverlayApplied = (bool) Value;
    }

    private object get_117_ToastPrompt_MillisecondsUntilHidden(object instance)
    {
      return (object) ((ToastPrompt) instance).MillisecondsUntilHidden;
    }

    private void set_117_ToastPrompt_MillisecondsUntilHidden(object instance, object Value)
    {
      ((ToastPrompt) instance).MillisecondsUntilHidden = (int) Value;
    }

    private object get_118_ToastPrompt_IsTimerEnabled(object instance)
    {
      return (object) ((ToastPrompt) instance).IsTimerEnabled;
    }

    private void set_118_ToastPrompt_IsTimerEnabled(object instance, object Value)
    {
      ((ToastPrompt) instance).IsTimerEnabled = (bool) Value;
    }

    private object get_119_ToastPrompt_Title(object instance)
    {
      return (object) ((ToastPrompt) instance).Title;
    }

    private void set_119_ToastPrompt_Title(object instance, object Value)
    {
      ((ToastPrompt) instance).Title = (string) Value;
    }

    private object get_120_ToastPrompt_Message(object instance)
    {
      return (object) ((ToastPrompt) instance).Message;
    }

    private void set_120_ToastPrompt_Message(object instance, object Value)
    {
      ((ToastPrompt) instance).Message = (string) Value;
    }

    private object get_121_ToastPrompt_ImageSource(object instance)
    {
      return (object) ((ToastPrompt) instance).ImageSource;
    }

    private void set_121_ToastPrompt_ImageSource(object instance, object Value)
    {
      ((ToastPrompt) instance).ImageSource = (ImageSource) Value;
    }

    private object get_122_ToastPrompt_Stretch(object instance)
    {
      return (object) ((ToastPrompt) instance).Stretch;
    }

    private void set_122_ToastPrompt_Stretch(object instance, object Value)
    {
      ((ToastPrompt) instance).Stretch = (Stretch) Value;
    }

    private object get_123_ToastPrompt_ImageWidth(object instance)
    {
      return (object) ((ToastPrompt) instance).ImageWidth;
    }

    private void set_123_ToastPrompt_ImageWidth(object instance, object Value)
    {
      ((ToastPrompt) instance).ImageWidth = (double) Value;
    }

    private object get_124_ToastPrompt_ImageHeight(object instance)
    {
      return (object) ((ToastPrompt) instance).ImageHeight;
    }

    private void set_124_ToastPrompt_ImageHeight(object instance, object Value)
    {
      ((ToastPrompt) instance).ImageHeight = (double) Value;
    }

    private object get_125_ToastPrompt_TextOrientation(object instance)
    {
      return (object) ((ToastPrompt) instance).TextOrientation;
    }

    private void set_125_ToastPrompt_TextOrientation(object instance, object Value)
    {
      ((ToastPrompt) instance).TextOrientation = (Orientation) Value;
    }

    private object get_126_ToastPrompt_TextWrapping(object instance)
    {
      return (object) ((ToastPrompt) instance).TextWrapping;
    }

    private void set_126_ToastPrompt_TextWrapping(object instance, object Value)
    {
      ((ToastPrompt) instance).TextWrapping = (TextWrapping) Value;
    }

    private object get_127_PopUp_Overlay(object instance)
    {
      return (object) ((PopUp<object, PopUpResult>) instance).Overlay;
    }

    private void set_127_PopUp_Overlay(object instance, object Value)
    {
      ((PopUp<object, PopUpResult>) instance).Overlay = (Brush) Value;
    }

    private object get_128_AboutPrompt_IsPromptMode(object instance)
    {
      return (object) ((AboutPrompt) instance).IsPromptMode;
    }

    private void set_128_AboutPrompt_IsPromptMode(object instance, object Value)
    {
      ((AboutPrompt) instance).IsPromptMode = (bool) Value;
    }

    private object get_129_AboutPrompt_WaterMark(object instance)
    {
      return ((AboutPrompt) instance).WaterMark;
    }

    private void set_129_AboutPrompt_WaterMark(object instance, object Value)
    {
      ((AboutPrompt) instance).WaterMark = Value;
    }

    private object get_130_AboutPrompt_VersionNumber(object instance)
    {
      return (object) ((AboutPrompt) instance).VersionNumber;
    }

    private void set_130_AboutPrompt_VersionNumber(object instance, object Value)
    {
      ((AboutPrompt) instance).VersionNumber = (string) Value;
    }

    private object get_131_AboutPrompt_Body(object instance) => ((AboutPrompt) instance).Body;

    private void set_131_AboutPrompt_Body(object instance, object Value)
    {
      ((AboutPrompt) instance).Body = Value;
    }

    private object get_132_AboutPrompt_Footer(object instance) => ((AboutPrompt) instance).Footer;

    private void set_132_AboutPrompt_Footer(object instance, object Value)
    {
      ((AboutPrompt) instance).Footer = Value;
    }

    private object get_133_AboutPrompt_Title(object instance)
    {
      return (object) ((AboutPrompt) instance).Title;
    }

    private void set_133_AboutPrompt_Title(object instance, object Value)
    {
      ((AboutPrompt) instance).Title = (string) Value;
    }

    private object get_134_ActionPopUp_ActionPopUpButtons(object instance)
    {
      return (object) ((ActionPopUp<object, PopUpResult>) instance).ActionPopUpButtons;
    }

    private void set_134_ActionPopUp_ActionPopUpButtons(object instance, object Value)
    {
      ((ActionPopUp<object, PopUpResult>) instance).ActionPopUpButtons = (List<Button>) Value;
    }

    private object get_135_PopUp_IsOpen(object instance)
    {
      return (object) ((PopUp<object, PopUpResult>) instance).IsOpen;
    }

    private object get_136_PopUp_IsAppBarVisible(object instance)
    {
      return (object) ((PopUp<object, PopUpResult>) instance).IsAppBarVisible;
    }

    private void set_136_PopUp_IsAppBarVisible(object instance, object Value)
    {
      ((PopUp<object, PopUpResult>) instance).IsAppBarVisible = (bool) Value;
    }

    private object get_137_PopUp_IsOverlayApplied(object instance)
    {
      return (object) ((PopUp<object, PopUpResult>) instance).IsOverlayApplied;
    }

    private void set_137_PopUp_IsOverlayApplied(object instance, object Value)
    {
      ((PopUp<object, PopUpResult>) instance).IsOverlayApplied = (bool) Value;
    }

    private object get_138_AboutPromptItem_WebSiteUrl(object instance)
    {
      return (object) ((AboutPromptItem) instance).WebSiteUrl;
    }

    private void set_138_AboutPromptItem_WebSiteUrl(object instance, object Value)
    {
      ((AboutPromptItem) instance).WebSiteUrl = (string) Value;
    }

    private object get_139_AboutPromptItem_Role(object instance)
    {
      return (object) ((AboutPromptItem) instance).Role;
    }

    private void set_139_AboutPromptItem_Role(object instance, object Value)
    {
      ((AboutPromptItem) instance).Role = (string) Value;
    }

    private object get_140_AboutPromptItem_EmailAddress(object instance)
    {
      return (object) ((AboutPromptItem) instance).EmailAddress;
    }

    private void set_140_AboutPromptItem_EmailAddress(object instance, object Value)
    {
      ((AboutPromptItem) instance).EmailAddress = (string) Value;
    }

    private object get_141_AboutPromptItem_AuthorName(object instance)
    {
      return (object) ((AboutPromptItem) instance).AuthorName;
    }

    private void set_141_AboutPromptItem_AuthorName(object instance, object Value)
    {
      ((AboutPromptItem) instance).AuthorName = (string) Value;
    }

    private object get_142_MessagePrompt_Body(object instance) => ((MessagePrompt) instance).Body;

    private void set_142_MessagePrompt_Body(object instance, object Value)
    {
      ((MessagePrompt) instance).Body = Value;
    }

    private IXamlMember CreateXamlMember(string longMemberName)
    {
      XamlMember xamlMember = (XamlMember) null;
      switch (longMemberName)
      {
        case "Coding4Fun.Toolkit.Controls.AboutPrompt.Body":
          XamlUserType xamlTypeByName1 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPrompt");
          xamlMember = new XamlMember(this, "Body", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_131_AboutPrompt_Body);
          xamlMember.Setter = new Setter(this.set_131_AboutPrompt_Body);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPrompt.Footer":
          XamlUserType xamlTypeByName2 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPrompt");
          xamlMember = new XamlMember(this, "Footer", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_132_AboutPrompt_Footer);
          xamlMember.Setter = new Setter(this.set_132_AboutPrompt_Footer);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPrompt.IsPromptMode":
          XamlUserType xamlTypeByName3 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPrompt");
          xamlMember = new XamlMember(this, "IsPromptMode", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_128_AboutPrompt_IsPromptMode);
          xamlMember.Setter = new Setter(this.set_128_AboutPrompt_IsPromptMode);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPrompt.Title":
          XamlUserType xamlTypeByName4 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPrompt");
          xamlMember = new XamlMember(this, "Title", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_133_AboutPrompt_Title);
          xamlMember.Setter = new Setter(this.set_133_AboutPrompt_Title);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPrompt.VersionNumber":
          XamlUserType xamlTypeByName5 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPrompt");
          xamlMember = new XamlMember(this, "VersionNumber", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_130_AboutPrompt_VersionNumber);
          xamlMember.Setter = new Setter(this.set_130_AboutPrompt_VersionNumber);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPrompt.WaterMark":
          XamlUserType xamlTypeByName6 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPrompt");
          xamlMember = new XamlMember(this, "WaterMark", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_129_AboutPrompt_WaterMark);
          xamlMember.Setter = new Setter(this.set_129_AboutPrompt_WaterMark);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPromptItem.AuthorName":
          XamlUserType xamlTypeByName7 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPromptItem");
          xamlMember = new XamlMember(this, "AuthorName", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_141_AboutPromptItem_AuthorName);
          xamlMember.Setter = new Setter(this.set_141_AboutPromptItem_AuthorName);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPromptItem.EmailAddress":
          XamlUserType xamlTypeByName8 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPromptItem");
          xamlMember = new XamlMember(this, "EmailAddress", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_140_AboutPromptItem_EmailAddress);
          xamlMember.Setter = new Setter(this.set_140_AboutPromptItem_EmailAddress);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPromptItem.Role":
          XamlUserType xamlTypeByName9 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPromptItem");
          xamlMember = new XamlMember(this, "Role", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_139_AboutPromptItem_Role);
          xamlMember.Setter = new Setter(this.set_139_AboutPromptItem_Role);
          break;
        case "Coding4Fun.Toolkit.Controls.AboutPromptItem.WebSiteUrl":
          XamlUserType xamlTypeByName10 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.AboutPromptItem");
          xamlMember = new XamlMember(this, "WebSiteUrl", "String");
          xamlMember.Getter = new Getter(this.get_138_AboutPromptItem_WebSiteUrl);
          xamlMember.Setter = new Setter(this.set_138_AboutPromptItem_WebSiteUrl);
          break;
        case "Coding4Fun.Toolkit.Controls.ActionPopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>.ActionPopUpButtons":
          XamlUserType xamlTypeByName11 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ActionPopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "ActionPopUpButtons", "System.Collections.Generic.List`1<Windows.UI.Xaml.Controls.Button>");
          xamlMember.Getter = new Getter(this.get_134_ActionPopUp_ActionPopUpButtons);
          xamlMember.Setter = new Setter(this.set_134_ActionPopUp_ActionPopUpButtons);
          break;
        case "Coding4Fun.Toolkit.Controls.ActionPopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>.ActionPopUpButtons":
          XamlUserType xamlTypeByName12 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ActionPopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "ActionPopUpButtons", "System.Collections.Generic.List`1<Windows.UI.Xaml.Controls.Button>");
          xamlMember.Getter = new Getter(this.get_113_ActionPopUp_ActionPopUpButtons);
          xamlMember.Setter = new Setter(this.set_113_ActionPopUp_ActionPopUpButtons);
          break;
        case "Coding4Fun.Toolkit.Controls.ButtonBase.Label":
          XamlUserType xamlTypeByName13 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ButtonBase");
          xamlMember = new XamlMember(this, "Label", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_44_ButtonBase_Label);
          xamlMember.Setter = new Setter(this.set_44_ButtonBase_Label);
          break;
        case "Coding4Fun.Toolkit.Controls.ChatBubble.ChatBubbleDirection":
          XamlUserType xamlTypeByName14 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ChatBubble");
          xamlMember = new XamlMember(this, "ChatBubbleDirection", "Coding4Fun.Toolkit.Controls.ChatBubbleDirection");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_49_ChatBubble_ChatBubbleDirection);
          xamlMember.Setter = new Setter(this.set_49_ChatBubble_ChatBubbleDirection);
          break;
        case "Coding4Fun.Toolkit.Controls.ChatBubble.IsEquallySpaced":
          XamlUserType xamlTypeByName15 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ChatBubble");
          xamlMember = new XamlMember(this, "IsEquallySpaced", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_50_ChatBubble_IsEquallySpaced);
          xamlMember.Setter = new Setter(this.set_50_ChatBubble_IsEquallySpaced);
          break;
        case "Coding4Fun.Toolkit.Controls.ChatBubbleTextBox.ChatBubbleDirection":
          XamlUserType xamlTypeByName16 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ChatBubbleTextBox");
          xamlMember = new XamlMember(this, "ChatBubbleDirection", "Coding4Fun.Toolkit.Controls.ChatBubbleDirection");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_51_ChatBubbleTextBox_ChatBubbleDirection);
          xamlMember.Setter = new Setter(this.set_51_ChatBubbleTextBox_ChatBubbleDirection);
          break;
        case "Coding4Fun.Toolkit.Controls.ChatBubbleTextBox.Hint":
          XamlUserType xamlTypeByName17 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ChatBubbleTextBox");
          xamlMember = new XamlMember(this, "Hint", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_52_ChatBubbleTextBox_Hint);
          xamlMember.Setter = new Setter(this.set_52_ChatBubbleTextBox_Hint);
          break;
        case "Coding4Fun.Toolkit.Controls.ChatBubbleTextBox.HintStyle":
          XamlUserType xamlTypeByName18 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ChatBubbleTextBox");
          xamlMember = new XamlMember(this, "HintStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_53_ChatBubbleTextBox_HintStyle);
          xamlMember.Setter = new Setter(this.set_53_ChatBubbleTextBox_HintStyle);
          break;
        case "Coding4Fun.Toolkit.Controls.ChatBubbleTextBox.IsEquallySpaced":
          XamlUserType xamlTypeByName19 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ChatBubbleTextBox");
          xamlMember = new XamlMember(this, "IsEquallySpaced", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_54_ChatBubbleTextBox_IsEquallySpaced);
          xamlMember.Setter = new Setter(this.set_54_ChatBubbleTextBox_IsEquallySpaced);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorBaseControl.Color":
          XamlUserType xamlTypeByName20 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorBaseControl");
          xamlMember = new XamlMember(this, "Color", "Windows.UI.Color");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_2_ColorBaseControl_Color);
          xamlMember.Setter = new Setter(this.set_2_ColorBaseControl_Color);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorBaseControl.SolidColorBrush":
          XamlUserType xamlTypeByName21 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorBaseControl");
          xamlMember = new XamlMember(this, "SolidColorBrush", "Windows.UI.Xaml.Media.SolidColorBrush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_3_ColorBaseControl_SolidColorBrush);
          xamlMember.SetIsReadOnly();
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.ColorBody":
          XamlUserType xamlTypeByName22 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "ColorBody", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_60_ColorHexagonPicker_ColorBody);
          xamlMember.Setter = new Setter(this.set_60_ColorHexagonPicker_ColorBody);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.ColorBrightnessSteps":
          XamlUserType xamlTypeByName23 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "ColorBrightnessSteps", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_57_ColorHexagonPicker_ColorBrightnessSteps);
          xamlMember.Setter = new Setter(this.set_57_ColorHexagonPicker_ColorBrightnessSteps);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.ColorDarknessSteps":
          XamlUserType xamlTypeByName24 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "ColorDarknessSteps", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_56_ColorHexagonPicker_ColorDarknessSteps);
          xamlMember.Setter = new Setter(this.set_56_ColorHexagonPicker_ColorDarknessSteps);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.ColorSize":
          XamlUserType xamlTypeByName25 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "ColorSize", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_59_ColorHexagonPicker_ColorSize);
          xamlMember.Setter = new Setter(this.set_59_ColorHexagonPicker_ColorSize);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.GreyScaleBody":
          XamlUserType xamlTypeByName26 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "GreyScaleBody", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_61_ColorHexagonPicker_GreyScaleBody);
          xamlMember.Setter = new Setter(this.set_61_ColorHexagonPicker_GreyScaleBody);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.GreyScaleSteps":
          XamlUserType xamlTypeByName27 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "GreyScaleSteps", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_58_ColorHexagonPicker_GreyScaleSteps);
          xamlMember.Setter = new Setter(this.set_58_ColorHexagonPicker_GreyScaleSteps);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorHexagonPicker.SelectedStrokeColor":
          XamlUserType xamlTypeByName28 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorHexagonPicker");
          xamlMember = new XamlMember(this, "SelectedStrokeColor", "Windows.UI.Color");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_55_ColorHexagonPicker_SelectedStrokeColor);
          xamlMember.Setter = new Setter(this.set_55_ColorHexagonPicker_SelectedStrokeColor);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorPicker.Thumb":
          XamlUserType xamlTypeByName29 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorPicker");
          xamlMember = new XamlMember(this, "Thumb", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_1_ColorPicker_Thumb);
          xamlMember.Setter = new Setter(this.set_1_ColorPicker_Thumb);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorSlider.IsColorVisible":
          XamlUserType xamlTypeByName30 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorSlider");
          xamlMember = new XamlMember(this, "IsColorVisible", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_15_ColorSlider_IsColorVisible);
          xamlMember.Setter = new Setter(this.set_15_ColorSlider_IsColorVisible);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorSlider.Orientation":
          XamlUserType xamlTypeByName31 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorSlider");
          xamlMember = new XamlMember(this, "Orientation", "Windows.UI.Xaml.Controls.Orientation");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_17_ColorSlider_Orientation);
          xamlMember.Setter = new Setter(this.set_17_ColorSlider_Orientation);
          break;
        case "Coding4Fun.Toolkit.Controls.ColorSlider.Thumb":
          XamlUserType xamlTypeByName32 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ColorSlider");
          xamlMember = new XamlMember(this, "Thumb", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_16_ColorSlider_Thumb);
          xamlMember.Setter = new Setter(this.set_16_ColorSlider_Thumb);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.AnimationDuration":
          XamlUserType xamlTypeByName33 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "AnimationDuration", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_90_ImageTile_AnimationDuration);
          xamlMember.Setter = new Setter(this.set_90_ImageTile_AnimationDuration);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.AnimationType":
          XamlUserType xamlTypeByName34 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "AnimationType", "Coding4Fun.Toolkit.Controls.ImageTileAnimationTypes");
          xamlMember.Getter = new Getter(this.get_88_ImageTile_AnimationType);
          xamlMember.Setter = new Setter(this.set_88_ImageTile_AnimationType);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.Columns":
          XamlUserType xamlTypeByName35 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "Columns", "Int32");
          xamlMember.Getter = new Getter(this.get_62_ImageTile_Columns);
          xamlMember.Setter = new Setter(this.set_62_ImageTile_Columns);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.ImageCycleInterval":
          XamlUserType xamlTypeByName36 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "ImageCycleInterval", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_91_ImageTile_ImageCycleInterval);
          xamlMember.Setter = new Setter(this.set_91_ImageTile_ImageCycleInterval);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.IsFrozen":
          XamlUserType xamlTypeByName37 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "IsFrozen", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_89_ImageTile_IsFrozen);
          xamlMember.Setter = new Setter(this.set_89_ImageTile_IsFrozen);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.ItemsSource":
          XamlUserType xamlTypeByName38 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "ItemsSource", "System.Collections.Generic.List`1<System.Uri>");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_66_ImageTile_ItemsSource);
          xamlMember.Setter = new Setter(this.set_66_ImageTile_ItemsSource);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.LargeTileColumns":
          XamlUserType xamlTypeByName39 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "LargeTileColumns", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_64_ImageTile_LargeTileColumns);
          xamlMember.Setter = new Setter(this.set_64_ImageTile_LargeTileColumns);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.LargeTileRows":
          XamlUserType xamlTypeByName40 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "LargeTileRows", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_65_ImageTile_LargeTileRows);
          xamlMember.Setter = new Setter(this.set_65_ImageTile_LargeTileRows);
          break;
        case "Coding4Fun.Toolkit.Controls.ImageTile.Rows":
          XamlUserType xamlTypeByName41 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ImageTile");
          xamlMember = new XamlMember(this, "Rows", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_63_ImageTile_Rows);
          xamlMember.Setter = new Setter(this.set_63_ImageTile_Rows);
          break;
        case "Coding4Fun.Toolkit.Controls.InputPrompt.InputScope":
          XamlUserType xamlTypeByName42 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.InputPrompt");
          xamlMember = new XamlMember(this, "InputScope", "Windows.UI.Xaml.Input.InputScope");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_108_InputPrompt_InputScope);
          xamlMember.Setter = new Setter(this.set_108_InputPrompt_InputScope);
          break;
        case "Coding4Fun.Toolkit.Controls.InputPrompt.IsSubmitOnEnterKey":
          XamlUserType xamlTypeByName43 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.InputPrompt");
          xamlMember = new XamlMember(this, "IsSubmitOnEnterKey", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_106_InputPrompt_IsSubmitOnEnterKey);
          xamlMember.Setter = new Setter(this.set_106_InputPrompt_IsSubmitOnEnterKey);
          break;
        case "Coding4Fun.Toolkit.Controls.InputPrompt.MessageTextWrapping":
          XamlUserType xamlTypeByName44 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.InputPrompt");
          xamlMember = new XamlMember(this, "MessageTextWrapping", "Windows.UI.Xaml.TextWrapping");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_107_InputPrompt_MessageTextWrapping);
          xamlMember.Setter = new Setter(this.set_107_InputPrompt_MessageTextWrapping);
          break;
        case "Coding4Fun.Toolkit.Controls.MessagePrompt.Body":
          XamlUserType xamlTypeByName45 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MessagePrompt");
          xamlMember = new XamlMember(this, "Body", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_142_MessagePrompt_Body);
          xamlMember.Setter = new Setter(this.set_142_MessagePrompt_Body);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlow.AnimationDuration":
          XamlUserType xamlTypeByName46 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlow");
          xamlMember = new XamlMember(this, "AnimationDuration", "TimeSpan");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_28_MetroFlow_AnimationDuration);
          xamlMember.Setter = new Setter(this.set_28_MetroFlow_AnimationDuration);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlow.CollapsingWidth":
          XamlUserType xamlTypeByName47 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlow");
          xamlMember = new XamlMember(this, "CollapsingWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_31_MetroFlow_CollapsingWidth);
          xamlMember.Setter = new Setter(this.set_31_MetroFlow_CollapsingWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlow.ExpandingWidth":
          XamlUserType xamlTypeByName48 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlow");
          xamlMember = new XamlMember(this, "ExpandingWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_30_MetroFlow_ExpandingWidth);
          xamlMember.Setter = new Setter(this.set_30_MetroFlow_ExpandingWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlow.SelectedColumnIndex":
          XamlUserType xamlTypeByName49 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlow");
          xamlMember = new XamlMember(this, "SelectedColumnIndex", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_29_MetroFlow_SelectedColumnIndex);
          xamlMember.Setter = new Setter(this.set_29_MetroFlow_SelectedColumnIndex);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ImageOpacity":
          XamlUserType xamlTypeByName50 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ImageOpacity", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_21_MetroFlowItem_ImageOpacity);
          xamlMember.Setter = new Setter(this.set_21_MetroFlowItem_ImageOpacity);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ImageSource":
          XamlUserType xamlTypeByName51 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ImageSource", "Windows.UI.Xaml.Media.ImageSource");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_19_MetroFlowItem_ImageSource);
          xamlMember.Setter = new Setter(this.set_19_MetroFlowItem_ImageSource);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ImageVisibility":
          XamlUserType xamlTypeByName52 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ImageVisibility", "Windows.UI.Xaml.Visibility");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_20_MetroFlowItem_ImageVisibility);
          xamlMember.Setter = new Setter(this.set_20_MetroFlowItem_ImageVisibility);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ItemIndex":
          XamlUserType xamlTypeByName53 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ItemIndex", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_23_MetroFlowItem_ItemIndex);
          xamlMember.Setter = new Setter(this.set_23_MetroFlowItem_ItemIndex);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ItemIndexOpacity":
          XamlUserType xamlTypeByName54 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ItemIndexOpacity", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_25_MetroFlowItem_ItemIndexOpacity);
          xamlMember.Setter = new Setter(this.set_25_MetroFlowItem_ItemIndexOpacity);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ItemIndexString":
          XamlUserType xamlTypeByName55 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ItemIndexString", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_22_MetroFlowItem_ItemIndexString);
          xamlMember.SetIsReadOnly();
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.ItemIndexVisibility":
          XamlUserType xamlTypeByName56 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "ItemIndexVisibility", "Windows.UI.Xaml.Visibility");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_24_MetroFlowItem_ItemIndexVisibility);
          xamlMember.Setter = new Setter(this.set_24_MetroFlowItem_ItemIndexVisibility);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.Title":
          XamlUserType xamlTypeByName57 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "Title", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_18_MetroFlowItem_Title);
          xamlMember.Setter = new Setter(this.set_18_MetroFlowItem_Title);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.TitleOpacity":
          XamlUserType xamlTypeByName58 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "TitleOpacity", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_27_MetroFlowItem_TitleOpacity);
          xamlMember.Setter = new Setter(this.set_27_MetroFlowItem_TitleOpacity);
          break;
        case "Coding4Fun.Toolkit.Controls.MetroFlowItem.TitleVisibility":
          XamlUserType xamlTypeByName59 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.MetroFlowItem");
          xamlMember = new XamlMember(this, "TitleVisibility", "Windows.UI.Xaml.Visibility");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_26_MetroFlowItem_TitleVisibility);
          xamlMember.Setter = new Setter(this.set_26_MetroFlowItem_TitleVisibility);
          break;
        case "Coding4Fun.Toolkit.Controls.OpacityToggleButton.AnimationDuration":
          XamlUserType xamlTypeByName60 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.OpacityToggleButton");
          xamlMember = new XamlMember(this, "AnimationDuration", "Windows.UI.Xaml.Duration");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_34_OpacityToggleButton_AnimationDuration);
          xamlMember.Setter = new Setter(this.set_34_OpacityToggleButton_AnimationDuration);
          break;
        case "Coding4Fun.Toolkit.Controls.OpacityToggleButton.CheckedOpacity":
          XamlUserType xamlTypeByName61 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.OpacityToggleButton");
          xamlMember = new XamlMember(this, "CheckedOpacity", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_36_OpacityToggleButton_CheckedOpacity);
          xamlMember.Setter = new Setter(this.set_36_OpacityToggleButton_CheckedOpacity);
          break;
        case "Coding4Fun.Toolkit.Controls.OpacityToggleButton.UncheckedOpacity":
          XamlUserType xamlTypeByName62 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.OpacityToggleButton");
          xamlMember = new XamlMember(this, "UncheckedOpacity", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_35_OpacityToggleButton_UncheckedOpacity);
          xamlMember.Setter = new Setter(this.set_35_OpacityToggleButton_UncheckedOpacity);
          break;
        case "Coding4Fun.Toolkit.Controls.PasswordInputPrompt.PasswordChar":
          XamlUserType xamlTypeByName63 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PasswordInputPrompt");
          xamlMember = new XamlMember(this, "PasswordChar", "Char");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_105_PasswordInputPrompt_PasswordChar);
          xamlMember.Setter = new Setter(this.set_105_PasswordInputPrompt_PasswordChar);
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>.IsAppBarVisible":
          XamlUserType xamlTypeByName64 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "IsAppBarVisible", "Boolean");
          xamlMember.Getter = new Getter(this.get_136_PopUp_IsAppBarVisible);
          xamlMember.Setter = new Setter(this.set_136_PopUp_IsAppBarVisible);
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>.IsOpen":
          XamlUserType xamlTypeByName65 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "IsOpen", "Boolean");
          xamlMember.Getter = new Getter(this.get_135_PopUp_IsOpen);
          xamlMember.SetIsReadOnly();
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>.IsOverlayApplied":
          XamlUserType xamlTypeByName66 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "IsOverlayApplied", "Boolean");
          xamlMember.Getter = new Getter(this.get_137_PopUp_IsOverlayApplied);
          xamlMember.Setter = new Setter(this.set_137_PopUp_IsOverlayApplied);
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>.Overlay":
          XamlUserType xamlTypeByName67 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<Object, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "Overlay", "Windows.UI.Xaml.Media.Brush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_127_PopUp_Overlay);
          xamlMember.Setter = new Setter(this.set_127_PopUp_Overlay);
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>.IsAppBarVisible":
          XamlUserType xamlTypeByName68 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "IsAppBarVisible", "Boolean");
          xamlMember.Getter = new Getter(this.get_115_PopUp_IsAppBarVisible);
          xamlMember.Setter = new Setter(this.set_115_PopUp_IsAppBarVisible);
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>.IsOpen":
          XamlUserType xamlTypeByName69 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "IsOpen", "Boolean");
          xamlMember.Getter = new Getter(this.get_114_PopUp_IsOpen);
          xamlMember.SetIsReadOnly();
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>.IsOverlayApplied":
          XamlUserType xamlTypeByName70 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "IsOverlayApplied", "Boolean");
          xamlMember.Getter = new Getter(this.get_116_PopUp_IsOverlayApplied);
          xamlMember.Setter = new Setter(this.set_116_PopUp_IsOverlayApplied);
          break;
        case "Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>.Overlay":
          XamlUserType xamlTypeByName71 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.PopUp`2<String, Coding4Fun.Toolkit.Controls.PopUpResult>");
          xamlMember = new XamlMember(this, "Overlay", "Windows.UI.Xaml.Media.Brush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_104_PopUp_Overlay);
          xamlMember.Setter = new Setter(this.set_104_PopUp_Overlay);
          break;
        case "Coding4Fun.Toolkit.Controls.ProgressOverlay.ProgressControl":
          XamlUserType xamlTypeByName72 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ProgressOverlay");
          xamlMember = new XamlMember(this, "ProgressControl", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_0_ProgressOverlay_ProgressControl);
          xamlMember.Setter = new Setter(this.set_0_ProgressOverlay_ProgressControl);
          break;
        case "Coding4Fun.Toolkit.Controls.RectangularButton.ButtonHeight":
          XamlUserType xamlTypeByName73 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RectangularButton");
          xamlMember = new XamlMember(this, "ButtonHeight", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_42_RectangularButton_ButtonHeight);
          xamlMember.Setter = new Setter(this.set_42_RectangularButton_ButtonHeight);
          break;
        case "Coding4Fun.Toolkit.Controls.RectangularButton.ButtonWidth":
          XamlUserType xamlTypeByName74 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RectangularButton");
          xamlMember = new XamlMember(this, "ButtonWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_41_RectangularButton_ButtonWidth);
          xamlMember.Setter = new Setter(this.set_41_RectangularButton_ButtonWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.RectangularButton.Orientation":
          XamlUserType xamlTypeByName75 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RectangularButton");
          xamlMember = new XamlMember(this, "Orientation", "Windows.UI.Xaml.Controls.Orientation");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_43_RectangularButton_Orientation);
          xamlMember.Setter = new Setter(this.set_43_RectangularButton_Orientation);
          break;
        case "Coding4Fun.Toolkit.Controls.RectangularButton.PressedBrush":
          XamlUserType xamlTypeByName76 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RectangularButton");
          xamlMember = new XamlMember(this, "PressedBrush", "Windows.UI.Xaml.Media.Brush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_40_RectangularButton_PressedBrush);
          xamlMember.Setter = new Setter(this.set_40_RectangularButton_PressedBrush);
          break;
        case "Coding4Fun.Toolkit.Controls.RoundButton.ButtonHeight":
          XamlUserType xamlTypeByName77 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RoundButton");
          xamlMember = new XamlMember(this, "ButtonHeight", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_47_RoundButton_ButtonHeight);
          xamlMember.Setter = new Setter(this.set_47_RoundButton_ButtonHeight);
          break;
        case "Coding4Fun.Toolkit.Controls.RoundButton.ButtonWidth":
          XamlUserType xamlTypeByName78 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RoundButton");
          xamlMember = new XamlMember(this, "ButtonWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_46_RoundButton_ButtonWidth);
          xamlMember.Setter = new Setter(this.set_46_RoundButton_ButtonWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.RoundButton.Orientation":
          XamlUserType xamlTypeByName79 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RoundButton");
          xamlMember = new XamlMember(this, "Orientation", "Windows.UI.Xaml.Controls.Orientation");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_48_RoundButton_Orientation);
          xamlMember.Setter = new Setter(this.set_48_RoundButton_Orientation);
          break;
        case "Coding4Fun.Toolkit.Controls.RoundButton.PressedBrush":
          XamlUserType xamlTypeByName80 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.RoundButton");
          xamlMember = new XamlMember(this, "PressedBrush", "Windows.UI.Xaml.Media.Brush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_45_RoundButton_PressedBrush);
          xamlMember.Setter = new Setter(this.set_45_RoundButton_PressedBrush);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.PlaceholderBackground":
          XamlUserType xamlTypeByName81 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "PlaceholderBackground", "Windows.UI.Xaml.Media.SolidColorBrush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_101_SuperImage_PlaceholderBackground);
          xamlMember.Setter = new Setter(this.set_101_SuperImage_PlaceholderBackground);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.PlaceholderImageSource":
          XamlUserType xamlTypeByName82 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "PlaceholderImageSource", "Windows.UI.Xaml.Media.ImageSource");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_98_SuperImage_PlaceholderImageSource);
          xamlMember.Setter = new Setter(this.set_98_SuperImage_PlaceholderImageSource);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.PlaceholderImageStretch":
          XamlUserType xamlTypeByName83 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "PlaceholderImageStretch", "Windows.UI.Xaml.Media.Stretch");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_102_SuperImage_PlaceholderImageStretch);
          xamlMember.Setter = new Setter(this.set_102_SuperImage_PlaceholderImageStretch);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.PlaceholderOpacity":
          XamlUserType xamlTypeByName84 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "PlaceholderOpacity", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_99_SuperImage_PlaceholderOpacity);
          xamlMember.Setter = new Setter(this.set_99_SuperImage_PlaceholderOpacity);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.Source":
          XamlUserType xamlTypeByName85 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "Source", "Windows.UI.Xaml.Media.ImageSource");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_100_SuperImage_Source);
          xamlMember.Setter = new Setter(this.set_100_SuperImage_Source);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.Sources":
          XamlUserType xamlTypeByName86 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "Sources", "System.Collections.ObjectModel.ObservableCollection`1<Coding4Fun.Toolkit.Controls.SuperImageSource>");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_93_SuperImage_Sources);
          xamlMember.Setter = new Setter(this.set_93_SuperImage_Sources);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImage.Stretch":
          XamlUserType xamlTypeByName87 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImage");
          xamlMember = new XamlMember(this, "Stretch", "Windows.UI.Xaml.Media.Stretch");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_92_SuperImage_Stretch);
          xamlMember.Setter = new Setter(this.set_92_SuperImage_Stretch);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImageSource.IsDefault":
          XamlUserType xamlTypeByName88 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImageSource");
          xamlMember = new XamlMember(this, "IsDefault", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_97_SuperImageSource_IsDefault);
          xamlMember.Setter = new Setter(this.set_97_SuperImageSource_IsDefault);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImageSource.MaxScale":
          XamlUserType xamlTypeByName89 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImageSource");
          xamlMember = new XamlMember(this, "MaxScale", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_95_SuperImageSource_MaxScale);
          xamlMember.Setter = new Setter(this.set_95_SuperImageSource_MaxScale);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImageSource.MinScale":
          XamlUserType xamlTypeByName90 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImageSource");
          xamlMember = new XamlMember(this, "MinScale", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_94_SuperImageSource_MinScale);
          xamlMember.Setter = new Setter(this.set_94_SuperImageSource_MinScale);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperImageSource.Source":
          XamlUserType xamlTypeByName91 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperImageSource");
          xamlMember = new XamlMember(this, "Source", "Windows.UI.Xaml.Media.ImageSource");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_96_SuperImageSource_Source);
          xamlMember.Setter = new Setter(this.set_96_SuperImageSource_Source);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.BackgroundSize":
          XamlUserType xamlTypeByName92 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "BackgroundSize", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_11_SuperSlider_BackgroundSize);
          xamlMember.Setter = new Setter(this.set_11_SuperSlider_BackgroundSize);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.BarHeight":
          XamlUserType xamlTypeByName93 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "BarHeight", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_8_SuperSlider_BarHeight);
          xamlMember.Setter = new Setter(this.set_8_SuperSlider_BarHeight);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.BarWidth":
          XamlUserType xamlTypeByName94 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "BarWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_9_SuperSlider_BarWidth);
          xamlMember.Setter = new Setter(this.set_9_SuperSlider_BarWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.Maximum":
          XamlUserType xamlTypeByName95 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "Maximum", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_6_SuperSlider_Maximum);
          xamlMember.Setter = new Setter(this.set_6_SuperSlider_Maximum);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.Minimum":
          XamlUserType xamlTypeByName96 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "Minimum", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_5_SuperSlider_Minimum);
          xamlMember.Setter = new Setter(this.set_5_SuperSlider_Minimum);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.Orientation":
          XamlUserType xamlTypeByName97 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "Orientation", "Windows.UI.Xaml.Controls.Orientation");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_4_SuperSlider_Orientation);
          xamlMember.Setter = new Setter(this.set_4_SuperSlider_Orientation);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.ProgressSize":
          XamlUserType xamlTypeByName98 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "ProgressSize", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_12_SuperSlider_ProgressSize);
          xamlMember.Setter = new Setter(this.set_12_SuperSlider_ProgressSize);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.StepFrequency":
          XamlUserType xamlTypeByName99 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "StepFrequency", "Double");
          xamlMember.Getter = new Getter(this.get_14_SuperSlider_StepFrequency);
          xamlMember.Setter = new Setter(this.set_14_SuperSlider_StepFrequency);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.Thumb":
          XamlUserType xamlTypeByName100 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "Thumb", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_7_SuperSlider_Thumb);
          xamlMember.Setter = new Setter(this.set_7_SuperSlider_Thumb);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.Title":
          XamlUserType xamlTypeByName101 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "Title", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_10_SuperSlider_Title);
          xamlMember.Setter = new Setter(this.set_10_SuperSlider_Title);
          break;
        case "Coding4Fun.Toolkit.Controls.SuperSlider.Value":
          XamlUserType xamlTypeByName102 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.SuperSlider");
          xamlMember = new XamlMember(this, "Value", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_13_SuperSlider_Value);
          xamlMember.Setter = new Setter(this.set_13_SuperSlider_Value);
          break;
        case "Coding4Fun.Toolkit.Controls.Tile.TextWrapping":
          XamlUserType xamlTypeByName103 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.Tile");
          xamlMember = new XamlMember(this, "TextWrapping", "Windows.UI.Xaml.TextWrapping");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_103_Tile_TextWrapping);
          xamlMember.Setter = new Setter(this.set_103_Tile_TextWrapping);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.ImageHeight":
          XamlUserType xamlTypeByName104 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "ImageHeight", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_124_ToastPrompt_ImageHeight);
          xamlMember.Setter = new Setter(this.set_124_ToastPrompt_ImageHeight);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.ImageSource":
          XamlUserType xamlTypeByName105 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "ImageSource", "Windows.UI.Xaml.Media.ImageSource");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_121_ToastPrompt_ImageSource);
          xamlMember.Setter = new Setter(this.set_121_ToastPrompt_ImageSource);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.ImageWidth":
          XamlUserType xamlTypeByName106 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "ImageWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_123_ToastPrompt_ImageWidth);
          xamlMember.Setter = new Setter(this.set_123_ToastPrompt_ImageWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.IsTimerEnabled":
          XamlUserType xamlTypeByName107 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "IsTimerEnabled", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_118_ToastPrompt_IsTimerEnabled);
          xamlMember.Setter = new Setter(this.set_118_ToastPrompt_IsTimerEnabled);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.Message":
          XamlUserType xamlTypeByName108 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "Message", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_120_ToastPrompt_Message);
          xamlMember.Setter = new Setter(this.set_120_ToastPrompt_Message);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.MillisecondsUntilHidden":
          XamlUserType xamlTypeByName109 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "MillisecondsUntilHidden", "Int32");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_117_ToastPrompt_MillisecondsUntilHidden);
          xamlMember.Setter = new Setter(this.set_117_ToastPrompt_MillisecondsUntilHidden);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.Stretch":
          XamlUserType xamlTypeByName110 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "Stretch", "Windows.UI.Xaml.Media.Stretch");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_122_ToastPrompt_Stretch);
          xamlMember.Setter = new Setter(this.set_122_ToastPrompt_Stretch);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.TextOrientation":
          XamlUserType xamlTypeByName111 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "TextOrientation", "Windows.UI.Xaml.Controls.Orientation");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_125_ToastPrompt_TextOrientation);
          xamlMember.Setter = new Setter(this.set_125_ToastPrompt_TextOrientation);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.TextWrapping":
          XamlUserType xamlTypeByName112 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "TextWrapping", "Windows.UI.Xaml.TextWrapping");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_126_ToastPrompt_TextWrapping);
          xamlMember.Setter = new Setter(this.set_126_ToastPrompt_TextWrapping);
          break;
        case "Coding4Fun.Toolkit.Controls.ToastPrompt.Title":
          XamlUserType xamlTypeByName113 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToastPrompt");
          xamlMember = new XamlMember(this, "Title", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_119_ToastPrompt_Title);
          xamlMember.Setter = new Setter(this.set_119_ToastPrompt_Title);
          break;
        case "Coding4Fun.Toolkit.Controls.ToggleButtonBase.ButtonHeight":
          XamlUserType xamlTypeByName114 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase");
          xamlMember = new XamlMember(this, "ButtonHeight", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_33_ToggleButtonBase_ButtonHeight);
          xamlMember.Setter = new Setter(this.set_33_ToggleButtonBase_ButtonHeight);
          break;
        case "Coding4Fun.Toolkit.Controls.ToggleButtonBase.ButtonWidth":
          XamlUserType xamlTypeByName115 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase");
          xamlMember = new XamlMember(this, "ButtonWidth", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_32_ToggleButtonBase_ButtonWidth);
          xamlMember.Setter = new Setter(this.set_32_ToggleButtonBase_ButtonWidth);
          break;
        case "Coding4Fun.Toolkit.Controls.ToggleButtonBase.CheckedBrush":
          XamlUserType xamlTypeByName116 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase");
          xamlMember = new XamlMember(this, "CheckedBrush", "Windows.UI.Xaml.Media.Brush");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_38_ToggleButtonBase_CheckedBrush);
          xamlMember.Setter = new Setter(this.set_38_ToggleButtonBase_CheckedBrush);
          break;
        case "Coding4Fun.Toolkit.Controls.ToggleButtonBase.Label":
          XamlUserType xamlTypeByName117 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase");
          xamlMember = new XamlMember(this, "Label", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_37_ToggleButtonBase_Label);
          xamlMember.Setter = new Setter(this.set_37_ToggleButtonBase_Label);
          break;
        case "Coding4Fun.Toolkit.Controls.ToggleButtonBase.Orientation":
          XamlUserType xamlTypeByName118 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.ToggleButtonBase");
          xamlMember = new XamlMember(this, "Orientation", "Windows.UI.Xaml.Controls.Orientation");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_39_ToggleButtonBase_Orientation);
          xamlMember.Setter = new Setter(this.set_39_ToggleButtonBase_Orientation);
          break;
        case "Coding4Fun.Toolkit.Controls.UserPrompt.IsCancelVisible":
          XamlUserType xamlTypeByName119 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.UserPrompt");
          xamlMember = new XamlMember(this, "IsCancelVisible", "Boolean");
          xamlMember.Getter = new Getter(this.get_109_UserPrompt_IsCancelVisible);
          xamlMember.Setter = new Setter(this.set_109_UserPrompt_IsCancelVisible);
          break;
        case "Coding4Fun.Toolkit.Controls.UserPrompt.Message":
          XamlUserType xamlTypeByName120 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.UserPrompt");
          xamlMember = new XamlMember(this, "Message", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_112_UserPrompt_Message);
          xamlMember.Setter = new Setter(this.set_112_UserPrompt_Message);
          break;
        case "Coding4Fun.Toolkit.Controls.UserPrompt.Title":
          XamlUserType xamlTypeByName121 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.UserPrompt");
          xamlMember = new XamlMember(this, "Title", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_111_UserPrompt_Title);
          xamlMember.Setter = new Setter(this.set_111_UserPrompt_Title);
          break;
        case "Coding4Fun.Toolkit.Controls.UserPrompt.Value":
          XamlUserType xamlTypeByName122 = (XamlUserType) this.GetXamlTypeByName("Coding4Fun.Toolkit.Controls.UserPrompt");
          xamlMember = new XamlMember(this, "Value", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_110_UserPrompt_Value);
          xamlMember.Setter = new Setter(this.set_110_UserPrompt_Value);
          break;
        case "System.Uri.AbsolutePath":
          XamlUserType xamlTypeByName123 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "AbsolutePath", "String");
          xamlMember.Getter = new Getter(this.get_67_Uri_AbsolutePath);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.AbsoluteUri":
          XamlUserType xamlTypeByName124 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "AbsoluteUri", "String");
          xamlMember.Getter = new Getter(this.get_68_Uri_AbsoluteUri);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Authority":
          XamlUserType xamlTypeByName125 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Authority", "String");
          xamlMember.Getter = new Getter(this.get_69_Uri_Authority);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.DnsSafeHost":
          XamlUserType xamlTypeByName126 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "DnsSafeHost", "String");
          xamlMember.Getter = new Getter(this.get_70_Uri_DnsSafeHost);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Fragment":
          XamlUserType xamlTypeByName127 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Fragment", "String");
          xamlMember.Getter = new Getter(this.get_71_Uri_Fragment);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Host":
          XamlUserType xamlTypeByName128 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Host", "String");
          xamlMember.Getter = new Getter(this.get_72_Uri_Host);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.HostNameType":
          XamlUserType xamlTypeByName129 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "HostNameType", "System.UriHostNameType");
          xamlMember.Getter = new Getter(this.get_73_Uri_HostNameType);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.IsAbsoluteUri":
          XamlUserType xamlTypeByName130 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "IsAbsoluteUri", "Boolean");
          xamlMember.Getter = new Getter(this.get_74_Uri_IsAbsoluteUri);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.IsDefaultPort":
          XamlUserType xamlTypeByName131 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "IsDefaultPort", "Boolean");
          xamlMember.Getter = new Getter(this.get_75_Uri_IsDefaultPort);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.IsFile":
          XamlUserType xamlTypeByName132 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "IsFile", "Boolean");
          xamlMember.Getter = new Getter(this.get_76_Uri_IsFile);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.IsLoopback":
          XamlUserType xamlTypeByName133 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "IsLoopback", "Boolean");
          xamlMember.Getter = new Getter(this.get_77_Uri_IsLoopback);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.IsUnc":
          XamlUserType xamlTypeByName134 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "IsUnc", "Boolean");
          xamlMember.Getter = new Getter(this.get_78_Uri_IsUnc);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.LocalPath":
          XamlUserType xamlTypeByName135 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "LocalPath", "String");
          xamlMember.Getter = new Getter(this.get_79_Uri_LocalPath);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.OriginalString":
          XamlUserType xamlTypeByName136 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "OriginalString", "String");
          xamlMember.Getter = new Getter(this.get_80_Uri_OriginalString);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.PathAndQuery":
          XamlUserType xamlTypeByName137 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "PathAndQuery", "String");
          xamlMember.Getter = new Getter(this.get_81_Uri_PathAndQuery);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Port":
          XamlUserType xamlTypeByName138 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Port", "Int32");
          xamlMember.Getter = new Getter(this.get_82_Uri_Port);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Query":
          XamlUserType xamlTypeByName139 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Query", "String");
          xamlMember.Getter = new Getter(this.get_83_Uri_Query);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Scheme":
          XamlUserType xamlTypeByName140 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Scheme", "String");
          xamlMember.Getter = new Getter(this.get_84_Uri_Scheme);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.Segments":
          XamlUserType xamlTypeByName141 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "Segments", "String[]");
          xamlMember.Getter = new Getter(this.get_85_Uri_Segments);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.UserEscaped":
          XamlUserType xamlTypeByName142 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "UserEscaped", "Boolean");
          xamlMember.Getter = new Getter(this.get_86_Uri_UserEscaped);
          xamlMember.SetIsReadOnly();
          break;
        case "System.Uri.UserInfo":
          XamlUserType xamlTypeByName143 = (XamlUserType) this.GetXamlTypeByName("System.Uri");
          xamlMember = new XamlMember(this, "UserInfo", "String");
          xamlMember.Getter = new Getter(this.get_87_Uri_UserInfo);
          xamlMember.SetIsReadOnly();
          break;
      }
      return (IXamlMember) xamlMember;
    }
  }
}

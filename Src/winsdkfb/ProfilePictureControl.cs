// Decompiled with JetBrains decompiler
// Type: winsdkfb.ProfilePictureControl
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

#nullable disable
namespace winsdkfb
{
  [Version(1)]
  [MarshalingBehavior]
  [WebHostHidden]
  [Threading]
  [Activatable(1)]
  public sealed class ProfilePictureControl : 
    UserControl,
    IComponentConnector,
    IComponentConnector2,
    __IProfilePictureControlPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void InitializeComponent();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern void Connect([In] int connectionId, [In] object target);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern IComponentConnector GetBindingConnector([In] int connectionId, [In] object target);

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern ProfilePictureControl();

    public extern string UserId { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

    public extern CroppingType CropMode { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
  }
}

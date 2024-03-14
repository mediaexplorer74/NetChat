// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBPermissions
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Static(typeof (__IFBPermissionsStatics), 1)]
  [Activatable(typeof (__IFBPermissionsFactory), 1)]
  [Version(1)]
  [Threading]
  [MarshalingBehavior]
  public sealed class FBPermissions : IStringable, __IFBPermissionsPublicNonVirtuals
  {
    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBPermissions([In] IVectorView<string> Permissions);

    public extern IVectorView<string> Values { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public new extern string ToString();

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBPermissions FromString([In] string Permissions);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBPermissions Difference([In] FBPermissions Minuend, [In] FBPermissions Subtrahend);
  }
}

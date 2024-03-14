// Decompiled with JetBrains decompiler
// Type: winsdkfb.FBError
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [Threading]
  [Version(1)]
  [Static(typeof (__IFBErrorStatics), 1)]
  [Activatable(typeof (__IFBErrorFactory), 1)]
  [MarshalingBehavior]
  public sealed class FBError : __IFBErrorPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBError FromUri([In] Uri ResponseUri);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public static extern FBError FromJson([In] string JsonText);

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern FBError([In] int Code, [In] string Type, [In] string Message);

    public extern string Message { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string Type { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int Code { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern int Subcode { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string ErrorUserTitle { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }

    public extern string ErrorUserMessage { [MethodImpl(MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}

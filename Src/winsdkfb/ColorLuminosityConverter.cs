// Decompiled with JetBrains decompiler
// Type: winsdkfb.ColorLuminosityConverter
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Interop;

#nullable disable
namespace winsdkfb
{
  [MarshalingBehavior]
  [WebHostHidden]
  [Version(1)]
  [Activatable(1)]
  [Threading]
  public sealed class ColorLuminosityConverter : 
    IValueConverter,
    __IColorLuminosityConverterPublicNonVirtuals
  {
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern object Convert(
      [In] object value,
      [In] TypeName targetType,
      [In] object parameter,
      [In] string language);

    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern object ConvertBack(
      [In] object value,
      [In] TypeName targetType,
      [In] object parameter,
      [In] string language);

    [Overload("CreateInstance1")]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    public extern ColorLuminosityConverter();
  }
}

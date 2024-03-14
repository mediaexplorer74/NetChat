// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBCursorsStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Version(1)]
  [Guid(4063676763, 24857, 12760, 187, 227, 252, 7, 81, 45, 148, 216)]
  [ExclusiveTo(typeof (FBCursors))]
  internal interface __IFBCursorsStatics
  {
    object FromJson([In] string JsonText);
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBUserStatics
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBUser))]
  [Guid(613095392, 32885, 15411, 186, 217, 7, 245, 173, 13, 4, 188)]
  [Version(1)]
  internal interface __IFBUserStatics
  {
    object FromJson([In] string JsonText);
  }
}

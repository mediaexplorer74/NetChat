// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBSingleValuePublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using Windows.Foundation;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [ExclusiveTo(typeof (FBSingleValue))]
  [Version(1)]
  [Guid(4014319094, 55468, 12719, 165, 17, 120, 190, 249, 54, 12, 246)]
  internal interface __IFBSingleValuePublicNonVirtuals
  {
    IAsyncOperation<FBResult> GetAsync();

    IAsyncOperation<FBResult> PostAsync();

    IAsyncOperation<FBResult> DeleteAsync();
  }
}

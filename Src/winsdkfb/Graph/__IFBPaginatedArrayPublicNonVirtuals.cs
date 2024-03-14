// Decompiled with JetBrains decompiler
// Type: winsdkfb.Graph.__IFBPaginatedArrayPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb.Graph
{
  [Guid(1353103383, 99, 15136, 182, 170, 23, 107, 84, 124, 44, 195)]
  [ExclusiveTo(typeof (FBPaginatedArray))]
  [Version(1)]
  internal interface __IFBPaginatedArrayPublicNonVirtuals
  {
    IAsyncOperation<FBResult> FirstAsync();

    IAsyncOperation<FBResult> NextAsync();

    IAsyncOperation<FBResult> PreviousAsync();

    IVectorView<object> Current { get; }

    bool HasCurrent { get; }

    bool HasNext { get; }

    bool HasPrevious { get; }

    IVectorView<object> ObjectArrayFromWebResponse([In] string Response, [In] FBJsonClassFactory classFactory);
  }
}

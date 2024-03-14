// Decompiled with JetBrains decompiler
// Type: winsdkfb.__IFacebookDialogPublicNonVirtuals
// Assembly: winsdkfb, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime
// MVID: 105A8F0C-85FF-4317-8917-65B7F19BE5BE
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatW10M\winsdkfb.winmd

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

#nullable disable
namespace winsdkfb
{
  [WebHostHidden]
  [Version(1)]
  [Guid(1266218689, 57459, 15057, 161, 125, 130, 62, 143, 236, 79, 61)]
  [ExclusiveTo(typeof (FacebookDialog))]
  internal interface __IFacebookDialogPublicNonVirtuals
  {
    void InitializeComponent();

    void InitDialog();

    void UninitDialog();

    IAsyncOperation<FBResult> ShowLoginDialog([In] PropertySet Parameters);

    IAsyncOperation<FBResult> ShowFeedDialog([In] PropertySet Parameters);

    IAsyncOperation<FBResult> ShowRequestsDialog([In] PropertySet Parameters);

    IAsyncOperation<FBResult> ShowSendDialog([In] PropertySet Parameters);
  }
}

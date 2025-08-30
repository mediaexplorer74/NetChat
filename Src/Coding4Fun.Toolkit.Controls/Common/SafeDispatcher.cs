// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.SafeDispatcher
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;


namespace Coding4Fun.Toolkit.Controls.Common
{
  public class SafeDispatcher
  {
    public static async Task Run(Action func)
    {
      CoreDispatcher currentDispatcher = ApplicationSpace.CurrentDispatcher;
      if (currentDispatcher == null)
        return;
        
      if (!currentDispatcher.HasThreadAccess)
      {
        await currentDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => func());
      }
      else
      {
        func();
      }
    }

    public static async Task<T> Run<T>(Func<T> func)
    {
      T returnData = default(T);
      CoreDispatcher currentDispatcher = ApplicationSpace.CurrentDispatcher;
      
      if (currentDispatcher == null)
        return returnData;
        
      if (!currentDispatcher.HasThreadAccess)
      {
        AutoResetEvent holdMutex = new AutoResetEvent(true);
        await currentDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
          returnData = func();
        });
        holdMutex.Reset();
        holdMutex.WaitOne();
        holdMutex = null;
      }
      else
      {
        returnData = func();
      }
      
      return returnData;
    }
  }
}

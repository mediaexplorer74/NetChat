// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.SafeDispatcher
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;

#nullable disable
namespace Coding4Fun.Toolkit.Controls.Common
{
  public class SafeDispatcher
  {
    public static async Task Run(Action func)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      SafeDispatcher.\u003C\u003Ec__DisplayClass0_0 cDisplayClass00 = new SafeDispatcher.\u003C\u003Ec__DisplayClass0_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass00.func = func;
      CoreDispatcher currentDispatcher = ApplicationSpace.CurrentDispatcher;
      if (currentDispatcher == null)
        return;
      if (!currentDispatcher.HasThreadAccess)
      {
        // ISSUE: method pointer
        await currentDispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) cDisplayClass00, __methodptr(\u003CRun\u003Eb__0)));
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        cDisplayClass00.func();
      }
    }

    public static async Task<T> Run<T>(Func<T> func)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      SafeDispatcher.\u003C\u003Ec__DisplayClass1_0<T> cDisplayClass10 = new SafeDispatcher.\u003C\u003Ec__DisplayClass1_0<T>();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass10.func = func;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass10.returnData = default (T);
      CoreDispatcher currentDispatcher = ApplicationSpace.CurrentDispatcher;
      if (currentDispatcher == null)
      {
        // ISSUE: reference to a compiler-generated field
        return cDisplayClass10.returnData;
      }
      if (!currentDispatcher.HasThreadAccess)
      {
        AutoResetEvent holdMutex = new AutoResetEvent(true);
        // ISSUE: method pointer
        await currentDispatcher.RunAsync((CoreDispatcherPriority) 0, new DispatchedHandler((object) cDisplayClass10, __methodptr(\u003CRun\u003Eb__0)));
        holdMutex.Reset();
        holdMutex.WaitOne();
        holdMutex = (AutoResetEvent) null;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        cDisplayClass10.returnData = cDisplayClass10.func();
      }
      // ISSUE: reference to a compiler-generated field
      return cDisplayClass10.returnData;
    }
  }
}

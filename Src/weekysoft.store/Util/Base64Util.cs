// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Util.Base64Util
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Linq;


namespace weekysoft.store.Util
{
  public class Base64Util
  {
    private static int _Counter;

    private static int Counter
    {
      get
      {
        if (Base64Util._Counter > 9999)
          Base64Util._Counter = 0;
        return Base64Util._Counter;
      }
      set => Base64Util._Counter = value;
    }

    public static string GenerateUniqueId(string ipAddress)
    {
      string[] strArray = ipAddress.Split('.');
      int num = Convert.ToInt32(strArray[2]) * 256 + Convert.ToInt32(strArray[3]);
      uint uint32 = Convert.ToUInt32(DateTime.Now.Ticks / 10000000L * 10000L % 4000000000L + (long) Base64Util.Counter++);
      return Convert.ToBase64String(((IEnumerable<byte>) BitConverter.GetBytes(Convert.ToUInt16(num))).AsEnumerable<byte>().Concat<byte>(((IEnumerable<byte>) BitConverter.GetBytes(uint32)).AsEnumerable<byte>()).ToArray<byte>());
    }

    public static string GenerateErrorUniqueId() => Base64Util.GenerateUniqueId(60);

    public static string GenerateUniqueId(int frequencyInSeconds)
    {
      DateTime now = DateTime.Now;
      int num1 = now.Hour % 12 * 60 * 60;
      now = DateTime.Now;
      int num2 = now.Minute * 60;
      int num3 = num1 + num2;
      now = DateTime.Now;
      int second = now.Second;
      return Convert.ToBase64String(BitConverter.GetBytes(Convert.ToUInt16((num3 + second) / frequencyInSeconds)));
    }
  }
}

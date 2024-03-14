// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Enums.EnumHelper
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Linq;


namespace weekysoft.store.Enums
{
  public class EnumHelper
  {
    public static T GetByKey<T>(string value)
    {
      foreach (T enumValue in Enum.GetValues(typeof (T)))
      {
        if (((object) enumValue).GetKey().ToLower().Equals(value.Trim().ToLower()))
          return enumValue;
      }
      return default (T);
    }

    public static IEnumerable<T> Members<T>() => Enum.GetValues(typeof (T)).Cast<T>();
  }
}

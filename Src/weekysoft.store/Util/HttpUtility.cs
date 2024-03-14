// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Util.HttpUtility
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;

#nullable disable
namespace weekysoft.store.Util
{
  public sealed class HttpUtility
  {
    public static HttpValueCollection ParseQueryString(string query)
    {
      if (query == null)
        throw new ArgumentNullException(nameof (query));
      if (query.Length > 0 && query[0] == '?')
        query = query.Substring(1);
      return new HttpValueCollection(query, true);
    }
  }
}

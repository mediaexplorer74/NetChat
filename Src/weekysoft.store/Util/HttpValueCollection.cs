// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Util.HttpValueCollection
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;

#nullable disable
namespace weekysoft.store.Util
{
  public class HttpValueCollection : Collection<HttpValue>
  {
    public HttpValueCollection()
    {
    }

    public HttpValueCollection(string query)
      : this(query, true)
    {
    }

    public HttpValueCollection(string query, bool urlencoded)
    {
      if (string.IsNullOrEmpty(query))
        return;
      this.FillFromString(query, urlencoded);
    }

    public string this[string key]
    {
      get
      {
        return this.First<HttpValue>((Func<HttpValue, bool>) (x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase))).Value;
      }
      set
      {
        HttpValue httpValue = this.FirstOrDefault<HttpValue>((Func<HttpValue, bool>) (x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)));
        if (httpValue == null)
          this.Add(new HttpValue(key, value));
        else
          httpValue.Value = value;
      }
    }

    public void Add(string key, string value) => this.Add(new HttpValue(key, value));

    public bool ContainsKey(string key)
    {
      return this.Any<HttpValue>((Func<HttpValue, bool>) (x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)));
    }

    public string[] GetValues(string key)
    {
      return this.Where<HttpValue>((Func<HttpValue, bool>) (x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase))).Select<HttpValue, string>((Func<HttpValue, string>) (x => x.Value)).ToArray<string>();
    }

    public void Remove(string key)
    {
      foreach (HttpValue httpValue in this.Where<HttpValue>((Func<HttpValue, bool>) (x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase))).ToList<HttpValue>())
        this.Remove(httpValue);
    }

    public override string ToString() => this.ToString(true);

    public virtual string ToString(bool urlencoded)
    {
      return this.ToString(urlencoded, (IDictionary) null);
    }

    public virtual string ToString(bool urlencoded, IDictionary excludeKeys)
    {
      if (this.Count == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      foreach (HttpValue httpValue in (Collection<HttpValue>) this)
      {
        string str = httpValue.Key;
        if (excludeKeys == null || !excludeKeys.Contains((object) str))
        {
          string stringToEscape = httpValue.Value;
          if (urlencoded)
            str = WebUtility.UrlDecode(str);
          if (stringBuilder.Length > 0)
            stringBuilder.Append('&');
          stringBuilder.Append(str != null ? str + "=" : string.Empty);
          if (stringToEscape != null && stringToEscape.Length > 0)
          {
            if (urlencoded)
              stringToEscape = Uri.EscapeDataString(stringToEscape);
            stringBuilder.Append(stringToEscape);
          }
        }
      }
      return stringBuilder.ToString();
    }

    private void FillFromString(string query, bool urlencoded)
    {
      int length = query != null ? query.Length : 0;
      for (int index = 0; index < length; ++index)
      {
        int startIndex = index;
        int num = -1;
        for (; index < length; ++index)
        {
          switch (query[index])
          {
            case '&':
              goto label_7;
            case '=':
              if (num < 0)
              {
                num = index;
                break;
              }
              break;
          }
        }
label_7:
        string str = (string) null;
        string stringToUnescape;
        if (num >= 0)
        {
          str = query.Substring(startIndex, num - startIndex);
          stringToUnescape = query.Substring(num + 1, index - num - 1);
        }
        else
          stringToUnescape = query.Substring(startIndex, index - startIndex);
        if (urlencoded)
          this.Add(Uri.UnescapeDataString(str), Uri.UnescapeDataString(stringToUnescape));
        else
          this.Add(str, stringToUnescape);
        if (index == length - 1 && query[index] == '&')
          this.Add((string) null, string.Empty);
      }
    }
  }
}

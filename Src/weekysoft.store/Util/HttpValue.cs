// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Util.HttpValue
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

#nullable disable
namespace weekysoft.store.Util
{
  public sealed class HttpValue
  {
    public HttpValue()
    {
    }

    public HttpValue(string key, string value)
    {
      this.Key = key;
      this.Value = value;
    }

    public string Key { get; set; }

    public string Value { get; set; }
  }
}

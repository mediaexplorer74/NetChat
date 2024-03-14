// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.SearchResult
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll


namespace weekysoft.store.Bots
{
  public class SearchResult
  {
    public string Snippet { get; set; }

    public string Source { get; set; }

    public string SearchEngine { get; set; }

    public string ToResponseString()
    {
      return string.IsNullOrWhiteSpace(this.Snippet) ? string.Empty : this.Snippet + (string.IsNullOrWhiteSpace(this.Source) ? string.Empty : " [" + this.Source + "]") + (string.IsNullOrWhiteSpace(this.SearchEngine) ? string.Empty : " [" + this.SearchEngine + "]");
    }
  }
}

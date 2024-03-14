// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.BingNewsBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace weekysoft.store.Bots
{
  public class BingNewsBot : BingSearchBot
  {
    protected new static string qnamakerUriBase = "https://api.cognitive.microsoft.com/bing/v5.0/news/search?";

    public override string Name => "Bing News";

    protected override string GetUri(string query) => BingNewsBot.qnamakerUriBase + query;

    public override SearchResult ExtractResponse(string responseString)
    {
      string str = string.Empty;
      string empty = string.Empty;
      BingNewsBot.BingNewsSearchResults newsSearchResults = JsonConvert.DeserializeObject<BingNewsBot.BingNewsSearchResults>(responseString);
      IEnumerable<BingNewsBot.Value> objs;
      if (newsSearchResults == null)
      {
        objs = (IEnumerable<BingNewsBot.Value>) null;
      }
      else
      {
        List<BingNewsBot.Value> source = newsSearchResults.value;
        objs = source != null ? source.OrderByDescending<BingNewsBot.Value, DateTime>((Func<BingNewsBot.Value, DateTime>) (s => s.datePublished)).Take<BingNewsBot.Value>(3) : (IEnumerable<BingNewsBot.Value>) null;
      }
      foreach (BingNewsBot.Value obj in objs)
        str = str + obj.datePublished.ToString("[MM/dd/yyyy] ") + obj.name + Environment.NewLine + obj.description + "[" + obj.provider?[0].name + "]" + Environment.NewLine + Environment.NewLine;
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = empty,
        Snippet = str
      };
    }

    private class BingNewsSearchResults
    {
      public List<BingNewsBot.Value> value { get; set; }
    }

    private class Value
    {
      public string name { get; set; }

      public string description { get; set; }

      public List<BingNewsBot.Provider> provider { get; set; }

      public DateTime datePublished { get; set; }
    }

    private class Provider
    {
      public string name { get; set; }
    }
  }
}

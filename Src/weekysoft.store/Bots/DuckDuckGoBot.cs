// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.DuckDuckGoBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using weekysoft.store.Util;


namespace weekysoft.store.Bots
{
  public class DuckDuckGoBot : Bot
  {
    protected static string qnamakerSubscriptionKey = "d35a1750a0ac40a08718db299916eea1";
    protected static string qnamakerUriBase = "http://api.duckduckgo.com/?";

    public override string Name => "DuckDuckGo";

    public override SearchResult ExtractResponse(string responseString)
    {
      string empty = string.Empty;
      DuckDuckGoBot.DuckDuckGoResults duckDuckGoResults = JsonConvert.DeserializeObject<DuckDuckGoBot.DuckDuckGoResults>(responseString);
      string str1 = duckDuckGoResults.AbstractText ?? "";
      string str2 = duckDuckGoResults.AbstractSource ?? "";
      if (string.IsNullOrWhiteSpace(str1))
      {
        int index = -1;
        List<DuckDuckGoBot.RelatedTopic> relatedTopics = duckDuckGoResults.RelatedTopics;
        // ISSUE: explicit non-virtual call
        int count = relatedTopics != null ? (relatedTopics.Count) : 0;
        if (count > 1)
        {
          string str3;
          for (str3 = string.Empty; (str3 == string.Empty || str3.Contains(" Category")) && index < count - 1; str3 = duckDuckGoResults.RelatedTopics[index]?.Text == null ? duckDuckGoResults.RelatedTopics[index].Topics?[0].Text : duckDuckGoResults.RelatedTopics[index]?.Text ?? "")
            index = new Random().Next(Math.Min(index + 1, count - 1), Math.Min(5, count - 1));
          str1 = WebUtility.HtmlDecode(str3);
        }
      }
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = str2,
        Snippet = str1
      };
    }

    public override string CreateQueryString(HttpClient client, string question)
    {
      HttpValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString["q"] = question;
      queryString["format"] = "json";
      return DuckDuckGoBot.qnamakerUriBase + (object) queryString;
    }

    private class DuckDuckGoResults
    {
      public string AbstractText { get; set; }

      public string AbstractSource { get; set; }

      public List<DuckDuckGoBot.RelatedTopic> RelatedTopics { get; set; }
    }

    private class RelatedTopic
    {
      public string Text { get; set; }

      public List<DuckDuckGoBot.Topic> Topics { get; set; }
    }

    private class Topic
    {
      public string Text { get; set; }
    }
  }
}

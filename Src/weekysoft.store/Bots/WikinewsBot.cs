// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.WikinewsBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace weekysoft.store.Bots
{
  public class WikinewsBot : Bot
  {
    protected static string qnamakerUriBase = "https://{0}.wikinews.org/w/api.php?action=query&format=json&list=search&srsearch=";
    public static string[] SupportedLanguages = new string[33]
    {
      "sr",
      "en",
      "fr",
      "de",
      "ru",
      "pl",
      "pt",
      "es",
      "it",
      "zh",
      "cs",
      "ca",
      "ta",
      "el",
      "ar",
      "sv",
      "fa",
      "ro",
      "uk",
      "tr",
      "ja",
      "sq",
      "no",
      "eo",
      "hu",
      "fi",
      "bs",
      "nl",
      "he",
      "ko",
      "bg",
      "th",
      "sd"
    };

    public override string Name => "Wikinews";

    public override SearchResult ExtractResponse(string responseString)
    {
      string str1 = string.Empty;
      WikinewsBot.WikinewsResults wikinewsResults = JsonConvert.DeserializeObject<WikinewsBot.WikinewsResults>(responseString);
      string str2 = "";
      IEnumerable<WikinewsBot.Search> searches;
      if (wikinewsResults == null)
      {
        searches = (IEnumerable<WikinewsBot.Search>) null;
      }
      else
      {
        WikinewsBot.WikiQuery query = wikinewsResults.query;
        if (query == null)
        {
          searches = (IEnumerable<WikinewsBot.Search>) null;
        }
        else
        {
          List<WikinewsBot.Search> search = query.search;
          searches = search != null ? search.Where<WikinewsBot.Search>((Func<WikinewsBot.Search, bool>) (s => s.timestamp > DateTime.Now.AddDays(-30.0))).OrderByDescending<WikinewsBot.Search, DateTime>((Func<WikinewsBot.Search, DateTime>) (s => s.timestamp)).Take<WikinewsBot.Search>(3) : (IEnumerable<WikinewsBot.Search>) null;
        }
      }
      foreach (WikinewsBot.Search search in searches)
        str1 = str1 + search.timestamp.ToString("[MM/dd/yyyy] ") + search.title + Environment.NewLine + Regex.Replace(search.snippet, "<[^>]*>", string.Empty) + Environment.NewLine + Environment.NewLine;
      string str3 = WebUtility.HtmlDecode(str1);
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = str2,
        Snippet = str3
      };
    }

    public override string CreateQueryString(HttpClient client, string question)
    {
      string str = ((IEnumerable<string>) WikinewsBot.SupportedLanguages).Contains<string>(Bot.DefaultLanguageCode?.ToLower().Substring(0, 2)) ? Bot.DefaultLanguageCode?.ToLower().Substring(0, 2) : "en";
      return string.Format(WikinewsBot.qnamakerUriBase, (object) str) + WebUtility.UrlEncode(question);
    }

    private class WikinewsResults
    {
      public WikinewsBot.WikiQuery query { get; set; }
    }

    private class WikiQuery
    {
      public List<WikinewsBot.Search> search { get; set; }
    }

    private class Search
    {
      public string title { get; set; }

      public string snippet { get; set; }

      public DateTime timestamp { get; set; }
    }
  }
}

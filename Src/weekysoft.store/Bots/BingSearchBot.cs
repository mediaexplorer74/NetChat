// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.BingSearchBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using weekysoft.store.Util;


namespace weekysoft.store.Bots
{
  public class BingSearchBot : Bot
  {
    protected static string qnamakerSubscriptionKey = "da019ca812034f7faf4219b53f8bf52b";
    protected static string qnamakerUriBase = "https://api.cognitive.microsoft.com/bing/v5.0/search?";
    public static string _MarketCode;
    public static string[] MarketCodes = new string[41]
    {
      "es-ar",
      "en-au",
      "de-at",
      "nl-be",
      "fr-be",
      "pt-br",
      "en-ca",
      "fr-ca",
      "es-cl",
      "da-dk",
      "fi-fi",
      "fr-fr",
      "de-de",
      "zh-hk",
      "en-in",
      "en-id",
      "en-ie",
      "it-it",
      "ja-jp",
      "ko-kr",
      "en-my",
      "es-mx",
      "nl-nl",
      "en-nz",
      "no-no",
      "zh-cn",
      "pl-pl",
      "pt-pt",
      "en-ph",
      "ru-ru",
      "ar-sa",
      "en-za",
      "es-es",
      "sv-se",
      "fr-ch",
      "de-ch",
      "zh-tw",
      "tr-tr",
      "en-gb",
      "en-us",
      "es-us"
    };

    public override string Name => "Bing";

    public static string MarketCode
    {
      get
      {
        return !string.IsNullOrWhiteSpace(BingSearchBot._MarketCode) ? BingSearchBot._MarketCode : "en-us";
      }
      set
      {
        if (((IEnumerable<string>) BingSearchBot.MarketCodes).Contains<string>(value?.ToLower()))
        {
          BingSearchBot._MarketCode = value.ToLower();
        }
        else
        {
          if (((IEnumerable<string>) BingSearchBot.MarketCodes).FirstOrDefault<string>((Func<string, bool>) (s => s.Substring(0, 2) == value?.Substring(0, 2))) == null)
            return;
          BingSearchBot._MarketCode = ((IEnumerable<string>) BingSearchBot.MarketCodes).FirstOrDefault<string>((Func<string, bool>) (s => s.Substring(0, 2) == value?.Substring(0, 2)));
        }
      }
    }

    protected virtual string GetUri(string query) => BingSearchBot.qnamakerUriBase + query;

    public override string CreateQueryString(HttpClient client, string question)
    {
      HttpValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString["q"] = question;
      queryString["count"] = "5";
      queryString["offset"] = "0";
      queryString["mkt"] = BingSearchBot.MarketCode;
      queryString["safeSearch"] = "Moderate";
      client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", BingSearchBot.qnamakerSubscriptionKey);
      return this.GetUri(queryString.ToString());
    }

    public override SearchResult ExtractResponse(string responseString)
    {
      string str1 = string.Empty;
      string str2 = string.Empty;
      BingSearchBot.BingSearchResults bingSearchResults = JsonConvert.DeserializeObject<BingSearchBot.BingSearchResults>(responseString);
      int index = -1;
      BingSearchBot.WebPage webPages1 = bingSearchResults.webPages;
      int? count;
      int num1;
      if (webPages1 == null)
      {
        num1 = 0;
      }
      else
      {
        count = webPages1.value?.Count;
        int num2 = 1;
        num1 = count.GetValueOrDefault() > num2 ? (count.HasValue ? 1 : 0) : 0;
      }
      if (num1 != 0)
      {
        index = new Random().Next(bingSearchResults.webPages.value.Count - 1);
      }
      else
      {
        BingSearchBot.WebPage webPages2 = bingSearchResults.webPages;
        int num3;
        if (webPages2 == null)
        {
          num3 = 0;
        }
        else
        {
          count = webPages2.value?.Count;
          int num4 = 1;
          num3 = count.GetValueOrDefault() == num4 ? (count.HasValue ? 1 : 0) : 0;
        }
        if (num3 != 0)
          index = 0;
      }
      if (index >= 0)
      {
        str2 = bingSearchResults.webPages.value[index].displayUrl;
        str1 = WebUtility.HtmlDecode(bingSearchResults.webPages.value[index].snippet);
      }
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = str2,
        Snippet = str1
      };
    }

    private class BingSearchResults
    {
      public BingSearchBot.WebPage webPages { get; set; }
    }

    private class WebPage
    {
      public List<BingSearchBot.PageValue> value;
    }

    private class PageValue
    {
      public string displayUrl { get; set; }

      public string snippet { get; set; }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.GoogleSearchBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

#nullable disable
namespace weekysoft.store.Bots
{
  public class GoogleSearchBot : Bot
  {
    protected static string qnamakerUriBase = "https://www.googleapis.com/customsearch/v1?key=AIzaSyA0qygUtjRkqq4Si7dsIBsDcvD0qhUuhz4&cx=003492188809349593413:lmzc_qdwcys&q=";

    public override string Name => "Google";

    public override SearchResult ExtractResponse(string responseString)
    {
      string str1 = string.Empty;
      string str2 = string.Empty;
      GoogleSearchBot.GoogleResults googleResults = JsonConvert.DeserializeObject<GoogleSearchBot.GoogleResults>(responseString);
      int index = -1;
      List<GoogleSearchBot.Item> items1 = googleResults.items;
      // ISSUE: explicit non-virtual call
      if ((items1 != null ? (__nonvirtual (items1.Count) > 1 ? 1 : 0) : 0) != 0)
      {
        index = new Random().Next(Math.Min(2, googleResults.items.Count - 1));
      }
      else
      {
        List<GoogleSearchBot.Item> items2 = googleResults.items;
        // ISSUE: explicit non-virtual call
        if ((items2 != null ? (__nonvirtual (items2.Count) == 1 ? 1 : 0) : 0) != 0)
          index = 0;
      }
      if (index >= 0)
      {
        str2 = googleResults.items[index].displayLink;
        str1 = WebUtility.HtmlDecode(googleResults.items[index].snippet ?? "");
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
      return GoogleSearchBot.qnamakerUriBase + WebUtility.UrlEncode(question);
    }

    private class GoogleResults
    {
      public List<GoogleSearchBot.Item> items { get; set; }
    }

    private class Item
    {
      public string snippet { get; set; }

      public string displayLink { get; set; }
    }
  }
}

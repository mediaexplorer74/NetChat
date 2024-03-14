// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.StockBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace weekysoft.store.Bots
{
  public class StockBot : Bot
  {
    protected static string qnamakerUriBase = "http://www.google.com/finance/info?q=";

    public override string Name => "Google Finance";

    public override string CreateQueryString(HttpClient client, string question)
    {
      return StockBot.qnamakerUriBase + question;
    }

    public override SearchResult ExtractResponse(string responseString)
    {
      string str1 = Regex.Match(responseString, "\\{([^\\}]+)\\}").Value;
      string str2 = string.Empty;
      StockBot.Stock stock = JsonConvert.DeserializeObject<StockBot.Stock>(str1);
      string str3 = "";
      if (string.IsNullOrWhiteSpace(str2) && stock != null)
      {
        string empty = string.Empty;
        str2 = WebUtility.HtmlDecode(string.Format("Symbol :\t\t{0}\nMarket :\t\t{1}\nLast :\t\t{2}\nChange :\t\t{3}\nLast Traded :\t{4}\nPrev Close :\t{5}", (object) stock.t, (object) stock.e, (object) stock.l, (object) stock.c, (object) stock.ltt, (object) stock.pcls_fix));
      }
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = str3,
        Snippet = str2
      };
    }

    private class Stock
    {
      public string t { get; set; }

      public string e { get; set; }

      public string l { get; set; }

      public string ltt { get; set; }

      public string c { get; set; }

      public string pcls_fix { get; set; }
    }
  }
}

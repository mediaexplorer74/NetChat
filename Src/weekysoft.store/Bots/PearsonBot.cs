// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.PearsonBot
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
  public class PearsonBot : Bot
  {
    protected static string qnamakerSubscriptionKey = "0270WAsWYfaGXImzF1CsGDZ0fTIvpEaj";
    protected static string qnamakerUriBase = "https://api.pearson.com/v2/dictionaries/ldoce5/entries?";

    public override string Name => "Pearson";

    private List<string> SearchTerms { get; set; }

    public override SearchResult ExtractResponse(string responseString)
    {
      string str1 = string.Empty;
      PearsonBot.PearsonResults pearsonResults = JsonConvert.DeserializeObject<PearsonBot.PearsonResults>(responseString);
      string str2 = pearsonResults.url ?? "";
      if (string.IsNullOrWhiteSpace(str1))
      {
        List<PearsonBot.Result> results = pearsonResults.results;
        // ISSUE: explicit non-virtual call
        if ((results != null ? (results.Count) : 0) > 1)
        {
          string empty = string.Empty;
          foreach (PearsonBot.Result result in pearsonResults.results)
          {
            if (this.ContainAllSearchTerms(result.headword))
            {
              string str3;
              if (result.senses?[0] != null)
                str3 = result.headword + ", " + result.part_of_speech + Environment.NewLine + "[Definition] : " + result.senses?[0]?.definition?[0] + Environment.NewLine + (result.senses?[0]?.examples == null ? string.Empty : "[Example] : " + result.senses?[0]?.examples?[0]?.text + Environment.NewLine + Environment.NewLine);
              else
                str3 = string.Empty;
              string str4 = str3;
              empty += str4;
            }
          }
          str1 = WebUtility.HtmlDecode(empty);
        }
      }
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = str2,
        Snippet = str1
      };
    }

    private bool ContainAllSearchTerms(string headword)
    {
      foreach (string searchTerm in this.SearchTerms)
      {
        if (!headword.ToLower().Contains(searchTerm.ToLower()))
          return false;
      }
      return true;
    }

    public override string CreateQueryString(HttpClient client, string question)
    {
      this.SearchTerms = new List<string>();
      this.SearchTerms.AddRange((IEnumerable<string>) question.Split(' '));
      HttpValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString["headword"] = WebUtility.UrlEncode(question);
      queryString["apikey"] = PearsonBot.qnamakerSubscriptionKey;
      return PearsonBot.qnamakerUriBase + (object) queryString;
    }

    private class PearsonResults
    {
      public string url { get; set; }

      public List<PearsonBot.Result> results { get; set; }
    }

    private class Result
    {
      public string part_of_speech { get; set; }

      public string headword { get; set; }

      public List<PearsonBot.Sense> senses { get; set; }
    }

    private class Sense
    {
      public List<string> definition { get; set; }

      public List<PearsonBot.Example> examples { get; set; }
    }

    private class Example
    {
      public string text { get; set; }
    }
  }
}

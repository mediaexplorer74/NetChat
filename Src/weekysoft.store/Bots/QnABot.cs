// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.QnABot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace weekysoft.store.Bots
{
  public class QnABot : Bot
  {
    private static string knowledgebaseId = "76c37545-974d-4b36-a0d7-3c9ef496aac4";
    private static string qnamakerSubscriptionKey = "f6b7a96492584b74bd4abd79600a7521";
    private static Uri qnamakerUriBase = new Uri("https://westus.api.cognitive.microsoft.com/qnamaker/v1.0");
    private static UriBuilder builder = new UriBuilder(string.Format("{0}/knowledgebases/{1}/generateAnswer", (object) QnABot.qnamakerUriBase, (object) QnABot.knowledgebaseId));

    public override string Name => "QnA";

    public override async Task<SearchResult> GetAnswer(string question)
    {
      SearchResult answerStr = (SearchResult) null;
      try
      {
        string content = string.Format("{{\"question\": \"{0}\"}}", (object) question);
        using (HttpClient client = new HttpClient())
        {
          client.Timeout = new TimeSpan(0, 0, Bot.timeout / 1000);
          HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, QnABot.builder.Uri);
          request.Headers.Add("Ocp-Apim-Subscription-Key", QnABot.qnamakerSubscriptionKey);
          request.Content = (HttpContent) new StringContent(content, Encoding.UTF8, "application/json");
          string responseString = await (await client.SendAsync(request)).Content.ReadAsStringAsync();
          if (!string.IsNullOrWhiteSpace(responseString))
            answerStr = this.ExtractResponse(responseString);
        }
      }
      catch (Exception ex)
      {
        answerStr = (SearchResult) null;
      }
      return answerStr;
    }

    public override SearchResult ExtractResponse(string responseString)
    {
      string str1 = WebUtility.HtmlDecode(JsonConvert.DeserializeObject<QnABot.QnAResult>(responseString)?.Answer);
      string str2 = str1 == "No good match found in the KB" ? string.Empty : str1;
      return new SearchResult()
      {
        SearchEngine = this.Name,
        Source = "",
        Snippet = str2
      };
    }

    public override string CreateQueryString(HttpClient client, string question)
    {
      throw new NotImplementedException();
    }

    private class QnAResult
    {
      public string Answer { get; set; }

      public double Score { get; set; }
    }
  }
}

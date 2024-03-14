// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.Bot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Net.Http;
using System.Threading.Tasks;
using weekysoft.store.Chatting;


namespace weekysoft.store.Bots
{
  public abstract class Bot : IBot
  {
    protected static int timeout = 5000;
    public static Language DefaultLanguage = Language.English;
    public static string DefaultLanguageCode = "en";

    public Gender BotGender { get; protected set; }

    public abstract string Name { get; }

    public virtual async Task<SearchResult> Ask(string question) => await this.GetAnswer(question);

    public virtual async Task<SearchResult> GetAnswer(string question)
    {
      SearchResult answer = (SearchResult) null;
      try
      {
        using (HttpClient client = new HttpClient())
        {
          client.Timeout = new TimeSpan(0, 0, Bot.timeout / 1000);
          answer = this.ExtractResponse(await (await client.GetAsync(this.CreateQueryString(client, question), HttpCompletionOption.ResponseContentRead)).Content.ReadAsStringAsync());
        }
      }
      catch (Exception ex)
      {
        answer = (SearchResult) null;
      }
      return answer;
    }

    public abstract SearchResult ExtractResponse(string responseString);

    public abstract string CreateQueryString(HttpClient client, string question);
  }
}

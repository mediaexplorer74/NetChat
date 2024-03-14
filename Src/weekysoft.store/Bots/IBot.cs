// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.IBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System.Net.Http;
using System.Threading.Tasks;
using weekysoft.store.Chatting;

#nullable disable
namespace weekysoft.store.Bots
{
  public interface IBot
  {
    Task<SearchResult> Ask(string question);

    Task<SearchResult> GetAnswer(string question);

    SearchResult ExtractResponse(string responseString);

    string Name { get; }

    Gender BotGender { get; }

    string CreateQueryString(HttpClient client, string question);
  }
}

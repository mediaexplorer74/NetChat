// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Bots.ReceptionistBot
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Net.Http;
using System.Threading.Tasks;
using weekysoft.store.Chatting;


namespace weekysoft.store.Bots
{
  public class ReceptionistBot : Bot
  {
    private new static int timeout = 15000;
    private static string[,] BasicAnswers = new string[5, 3]
    {
      {
        "Hello, I am the Receptionist. How may I help you?\n[Ask me any questions and I will try my best to answer them.\nSpecial Search Symbols\n\t\t? Definition, Usage: ?dog\n\t\t# News, Usage: #Microsoft\n]",
        "你好，我是接待员。我怎样可以帮到你？[问我任何问题，我可以尝试解答。\n特殊的搜索符号\n\t\t? 字义，用法：?狗\n\t\t# 新闻，用法：#微软\n]",
        "Hola, soy la recepcionista. ¿Cómo puedo ayudarle? [Me preguntas y voy a intentar mi mejor para darles respuesta. \nSímbolos especiales de búsqueda\n\t\t? Definición, Uso: ?perro\n\t\t# Noticias, Uso: #Microsoft\n]"
      },
      {
        "A receptionist enters Lobby.",
        "接待员进入大厅。",
        "Recepcionista entra en el vestíbulo."
      },
      {
        "Goodbye.",
        "再见。",
        "Adiós."
      },
      {
        "A receptionist leaves Lobby.",
        "接待员离开大厅。",
        "Recepcionista deja Lobby."
      },
      {
        "I am taking a break. Please call me in about {0} minutes.",
        "我得休息一下。请在大概 {0} 分钟后再找我。",
        "Estoy tomando un descanso. Por favor llámeme {0} minutos."
      }
    };
    private static string[,] RandomAnswers = new string[15, 3]
    {
      {
        "Huh?",
        "吓？",
        "EH"
      },
      {
        "What?",
        "什么？",
        "lo que?"
      },
      {
        "I am sorry?",
        "对不起？",
        "Lo siento?"
      },
      {
        "I am sorry. I am still in training, can you repeat your question?",
        "对不起。我还在训练中，你能重复一下你的问题吗？",
        "Lo siento. Estoy aún en formación, puede repetir su pregunta?"
      },
      {
        "...",
        "...",
        "..."
      },
      {
        "Cough, Cough",
        "咳嗽咳嗽",
        "Tos, tos"
      },
      {
        "Pardon me?",
        "什么呀？",
        "¿Perdón?"
      },
      {
        "Excuse me?",
        "对不起？",
        "¿Disculpa?"
      },
      {
        "I don't understand.",
        "我不明白。",
        "No entiendo."
      },
      {
        "I am confused.",
        "我很困惑。",
        "Estoy confundido."
      },
      {
        "Are you asking me?",
        "你问我吗？",
        "¿Se me pide?"
      },
      {
        "Are you talking to me?",
        "你和我说话吗？",
        "¿Están hablando a mí?"
      },
      {
        "Can I get back to you later?",
        "可以稍后再找你吗？",
        "¿Puedo volver a usted más tarde?"
      },
      {
        "Ask me something else.",
        "问我别的东西吧。",
        "Me pregunta algo más."
      },
      {
        "Jingle Bell, Jingle Bell.",
        "叮铃铃，叮铃铃。",
        "Jingle Bell, Jingle Bell."
      }
    };

    public override string Name => "Receptionist";

    public ReceptionistBot() => this.BotGender = Gender.Female;

    public override async Task<SearchResult> Ask(string question)
    {
      SearchResult result = (SearchResult) null;
      Task<SearchResult> task = this.GetAnswer(question);
      result = await Task.WhenAny((Task) task, Task.Delay(ReceptionistBot.timeout)) == task ? task.Result : throw new Exception("Are you connected to the internet?");
      return result;
    }

    public override async Task<SearchResult> GetAnswer(string question)
    {
      SearchResult answerStr = (SearchResult) null;
      try
      {
        string qclean = this.CleanQuestion(question);
        if (question.StartsWith("?"))
          answerStr = await new PearsonBot().Ask(qclean);
        else if (question.StartsWith("#") && string.IsNullOrWhiteSpace(answerStr?.Snippet))
          answerStr = await new BingNewsBot().Ask(qclean);
        if (string.IsNullOrWhiteSpace(answerStr?.Snippet))
        {
          answerStr = await new QnABot().Ask(qclean);
          if (string.IsNullOrWhiteSpace(answerStr?.Snippet))
            answerStr = await await Task.WhenAny<SearchResult>(new DuckDuckGoBot().Ask(qclean), new PearsonBot().Ask(qclean));
        }
        if (string.IsNullOrWhiteSpace(answerStr?.Snippet))
          answerStr = await new GoogleSearchBot().Ask(qclean);
        if (string.IsNullOrWhiteSpace(answerStr?.Snippet))
          answerStr = await new BingSearchBot().Ask(qclean);
        qclean = (string) null;
      }
      catch (Exception ex)
      {
        answerStr = (SearchResult) null;
      }
      finally
      {
        if (string.IsNullOrWhiteSpace(answerStr?.Snippet))
          answerStr = ReceptionistBot.GenerateRandomAnswer();
      }
      return answerStr;
    }

    private string CleanQuestion(string question)
    {
      string empty = string.Empty;
      return question.Length <= 0 || !(question.Substring(0, 1) == "#") && !(question.Substring(0, 1) == "$") && !(question.Substring(0, 1) == "?") ? question : question.Substring(1, question.Length - 1);
    }

    private static SearchResult GenerateRandomAnswer()
    {
      Random random = new Random();
      string randomAnswer = ReceptionistBot.RandomAnswers[random.Next(ReceptionistBot.RandomAnswers.Length / 3), (int) Bot.DefaultLanguage];
      return new SearchResult() { Snippet = randomAnswer };
    }

    public override SearchResult ExtractResponse(string responseString)
    {
      throw new NotImplementedException();
    }

    public static string GreetConvo => ReceptionistBot.BasicAnswers[0, (int) Bot.DefaultLanguage];

    public static string EntersConvo => ReceptionistBot.BasicAnswers[1, (int) Bot.DefaultLanguage];

    public static string GoodByeConvo => ReceptionistBot.BasicAnswers[2, (int) Bot.DefaultLanguage];

    public static string LeavesConvo => ReceptionistBot.BasicAnswers[3, (int) Bot.DefaultLanguage];

    public static string OffDutyMessage(int breakDurationSeconds)
    {
      return string.Format(ReceptionistBot.BasicAnswers[4, (int) Bot.DefaultLanguage], (object) (breakDurationSeconds / 60));
    }

    public override string CreateQueryString(HttpClient client, string question)
    {
      throw new NotImplementedException();
    }
  }
}

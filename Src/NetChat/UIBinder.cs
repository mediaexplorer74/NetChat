// Decompiled with JetBrains decompiler
// Type: IGM.UI.UIBinder
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using Coding4Fun.Toolkit.Controls;
using IGM.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using weekysoft.store.Bots;
using weekysoft.store.ChatRoom;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;
using weekysoft.store.Messaging;
using weekysoft.store.Storage;
using weekysoft.store.Util;
using Windows.Media.SpeechSynthesis;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace IGM.UI
{
  public partial class UIBinder
  {
    private static UIBinder _Current;

    private UIBinder() => UIBinder.TTSIcon = new SymbolIcon((Symbol) 57693);

    public MediaElement ForegroundPlayer { get; set; }

    public static SymbolIcon TTSIcon { get; set; }

    public static UIBinder Current
    {
      get
      {
        if (UIBinder._Current == null)
          UIBinder._Current = new UIBinder();
        return UIBinder._Current;
      }
    }

    private void DisplayMessageHeader(string msg)
    {
    }

    public MessageType HandleMessage(
      ChatMessage message,
      Peer host,
      TextBlock tbMessages,
      Color color,
      MediaElement media)
    {
      return MessageType.Unknown;
    }

    public MessageType HandleMessage(ChatMessage message, Peer host, ListView lvChat, Color color)
    {
      return MessageType.Text;
    }

    public async void HandleErrorMessage(
      ErrorEventArgs error,
      Peer host,
      ListView lvChat,
      Color color)
    {
      if (error.ErrorType != ErrorType.Unknown || Setting.Current.IsDebugMode)
        this.CreateErrorMessageLine(lvChat)(error.ErrorId, error.Exception?.Message);
      else
        IGM.UI.Util.LogEvent(error.Exception?.Message ?? "");
      if (!Setting.Current.IsDebugMode || string.IsNullOrEmpty(error.Exception.StackTrace))
        return;
      this.CreateErrorMessageLine(lvChat)(error.ErrorId + "4", error.Exception.StackTrace ?? "");
    }

    public async void HandleOwnMessage(
      ChatMessage message,
      Peer host,
      ListView lvChat,
      Color color)
    {
      IGM.UI.Util.LogEvent("Message Sent");
      this.CreateMessageLine(lvChat)(message.Header.MessageId, message);
      if (message.Body == Setting.Current.EnableDebugMode)
      {
        Setting.Current.IsDebugMode = true;
        this.CreateSystemMessageLine(lvChat)(Base64Util.GenerateUniqueId(1), "DEBUG MODE");
      }
      if (Setting.Current.IsSpeechEnabled)
        this.PlayAudio(this.ForegroundPlayer)(message.Body, VoiceType.Self);
      if (!Setting.Current.IsAssistantEnabled || !ClientData.Current.CurrentRoom.Has(ClientData.Current.LobbyBot))
        return;
      string response = string.Empty;
      try
      {
        if (Setting.Current.MaxAssistReached())
        {
          response = ReceptionistBot.OffDutyMessage(Setting.Current.GetBreakSecondsRemaining());
          this.LeaveBot(ClientData.Current.LobbyBot, lvChat);
          IGM.UI.Util.LogEvent("Receptionist off duty.");
        }
        else
        {
          ++Setting.Current.DailyAssistCount;
          if (Setting.Current.GetLifeTimeUseCountRange(Setting.Current.LifetimeAssistCount) != "0")
            IGM.UI.Util.LogEvent(string.Format("Lifetime Assist Count {0}", (object) Setting.Current.GetLifeTimeUseCountRange(Setting.Current.LifetimeAssistCount)));
          Task<SearchResult> a = ClientData.Current.Assistant.Ask(message.Body);
          await Task.Delay(1000);
          SearchResult searchResult = await a;
          response = searchResult.ToResponseString();
          IGM.UI.Util.LogEvent("Bot Response from " + searchResult.SearchEngine);
          if (Setting.Current.MaxAssistReached())
            IGM.UI.Util.LogEvent("Max Assist Reached");
          a = (Task<SearchResult>) null;
        }
      }
      catch (Exception ex)
      {
        this.HandleErrorMessage(new ErrorEventArgs(ErrorType.Unknown, ex), host, lvChat, color);
      }
      finally
      {
        if (!string.IsNullOrWhiteSpace(response))
          this.HandleReceivedMessage(ClientData.Current.CurrentRoom.CreateBotMessage(response, ClientData.Current.LobbyBot, ClientData.Current.Assistant.BotGender), ClientData.Current.LobbyBot, lvChat, color);
      }
      response = (string) null;
    }

    internal async void AddRoomBanner(ListView lvChat, Room activeMember)
    {
      object obj = ((IEnumerable<object>) ((ItemsControl) lvChat).Items).LastOrDefault<object>();
      if (obj is Panel && ((FrameworkElement) obj).Tag?.ToString() == UISetting.Current.BannerTag)
        ((ICollection<object>) ((ItemsControl) lvChat).Items).Remove(obj);
      ((ICollection<object>) ((ItemsControl) lvChat).Items).Add((object) this.CreateRoomBanner(activeMember));
      ((UIElement) lvChat).UpdateLayout();
      ((ListViewBase) lvChat).ScrollIntoView(((IList<object>) ((ItemsControl) lvChat).Items)[((ICollection<object>) ((ItemsControl) lvChat).Items).Count - 1]);
    }

    public async void HandleReceivedMessage(
      ChatMessage message,
      Peer host,
      ListView lvChat,
      Color color)
    {
      this.CreateReceivedLine(lvChat)(message.Header.MessageId, message);
      if (!Setting.Current.IsSpeechEnabled)
        return;
      VoiceType voiceType = message.Header.SenderGender == string.Empty ? VoiceType.Peer : (message.Header.SenderGender == Gender.Male.GetKey() ? VoiceType.Male : VoiceType.Female);
      this.PlayAudio(this.ForegroundPlayer)(message.Body, voiceType);
    }

    public async void HandleLostMessage(
      ChatMessage message,
      Peer host,
      ListView lvChat,
      Color color)
    {
      this.CreateLostLine(lvChat)(message.Header.MessageId);
    }

    public async void HandleConfirmedMessage(
      ChatMessage message,
      Peer host,
      ListView lvChat,
      Color color)
    {
      this.CreateConfirmLine(lvChat)(string.IsNullOrEmpty(message.Header.OriginalMessageId) ? message.Header.MessageId : message.Header.OriginalMessageId);
    }

    public async void HandleFullyConfirmedMessage(
      ChatMessage message,
      Peer host,
      ListView lvChat,
      Color color)
    {
      this.CreateFullyConfirmLine(lvChat)(string.IsNullOrEmpty(message.Header.OriginalMessageId) ? message.Header.MessageId : message.Header.OriginalMessageId);
    }

    public Action<string> CreateConfirmLine(TextBlock tbMessages)
    {
      return (Action<string>) (id =>
      {
        Inline inline1 = ((IEnumerable<Inline>) tbMessages.Inlines).FirstOrDefault<Inline>((Func<Inline, bool>) (s => s is ChatRun && ((ChatRun) s).MessageId == id));
        if (inline1 == null)
          return;
        Inline inline2 = ((IEnumerable<Inline>) ((Span) inline1).Inlines).FirstOrDefault<Inline>();
        if (!(inline2 is Run))
          return;
        ((TextElement) inline2).put_Foreground((Brush) UISetting.Current.ConfirmBrush);
      });
    }

    public Action<string> CreateConfirmLine(ListView lvChat)
    {
      return (Action<string>) (id =>
      {
        if (!(((IEnumerable<object>) ((ItemsControl) lvChat).Items).Where<object>((Func<object, bool>) (s => s is ChatBubble && ((FrameworkElement) s).Name == id)).FirstOrDefault<object>() is ChatBubble chatBubble2))
          return;
        ((Control) chatBubble2).put_BorderBrush((Brush) UISetting.Current.PartiallyConfirmedBrush);
        ((Control) chatBubble2).put_Background((Brush) UISetting.Current.PartiallyConfirmedBrush);
        ((UIElement) chatBubble2).put_Opacity(1.0);
      });
    }

    public Action<string> CreateFullyConfirmLine(ListView lvChat)
    {
      return (Action<string>) (id =>
      {
        if (!(((IEnumerable<object>) ((ItemsControl) lvChat).Items).Where<object>((Func<object, bool>) (s => s is ChatBubble && ((FrameworkElement) s).Name == id)).FirstOrDefault<object>() is ChatBubble chatBubble2))
          return;
        ((Control) chatBubble2).put_Background((Brush) UISetting.Current.ConfirmBrush);
        ((UIElement) chatBubble2).put_Opacity(1.0);
        ((Control) chatBubble2).put_BorderBrush((Brush) UISetting.Current.ConfirmBrush);
      });
    }

    public Action<string, ChatMessage> CreateReceivedLine(TextBlock tbMessages)
    {
      return (Action<string, ChatMessage>) ((id, content) =>
      {
        Run run1 = new Run();
        run1.put_Text(string.Format("{0} ({1}): {2}", (object) content.Header.Sender, (object) content.Header.DateTime.ToString("HH:mm:ss"), (object) content.Body) + Environment.NewLine);
        ((TextElement) run1).put_Foreground((Brush) new SolidColorBrush(Colors.Cyan));
        Run run2 = run1;
        ChatRun chatRun = new ChatRun();
        ((ICollection<Inline>) chatRun.Inlines).Add((Inline) run2);
        chatRun.MessageId = id;
        ((ICollection<Inline>) tbMessages.Inlines).Add((Inline) chatRun);
      });
    }

    public Action<string, ChatMessage> CreateReceivedLine(ListView lvChat)
    {
      return (Action<string, ChatMessage>) ((id, m) =>
      {
        ((ICollection<object>) ((ItemsControl) lvChat).Items).Add((object) this.CreateChatBubble((object) this.CreateBubbleContent(m), id, ChatBubbleDirection.UpperLeft, (HorizontalAlignment) 0, (Brush) UISetting.Current.ChatBubbleReceivedBackground, (Brush) UISetting.Current.ChatBubbleReceivedForeground, (Brush) UISetting.Current.ChatBubbleReceivedBorderBrush));
        ((UIElement) lvChat).UpdateLayout();
        ((ListViewBase) lvChat).ScrollIntoView(((IList<object>) ((ItemsControl) lvChat).Items)[((ICollection<object>) ((ItemsControl) lvChat).Items).Count - 1]);
      });
    }

    public Action<string, string> CreateErrorMessageLine(TextBlock tbMessages)
    {
      return (Action<string, string>) ((id, m) =>
      {
        Run run1 = new Run();
        run1.put_Text(m + Environment.NewLine);
        ((TextElement) run1).put_Foreground((Brush) new SolidColorBrush(Colors.DarkRed));
        Run run2 = run1;
        ChatRun chatRun = new ChatRun();
        ((ICollection<Inline>) chatRun.Inlines).Add((Inline) run2);
        chatRun.MessageId = id;
        ((ICollection<Inline>) tbMessages.Inlines).Add((Inline) chatRun);
      });
    }

    public Action<string, string> CreateSystemMessageLine(ListView lvChat)
    {
      return (Action<string, string>) ((id, m) =>
      {
        if (((IEnumerable<object>) ((ItemsControl) lvChat).Items).Where<object>((Func<object, bool>) (s => s is ChatBubble && ((FrameworkElement) s).Name == id)).FirstOrDefault<object>() is ChatBubble)
          return;
        ((ICollection<object>) ((ItemsControl) lvChat).Items).Add((object) this.CreateChatBubble((object) this.CreateErrorBubbleContent(m, "System"), id, ChatBubbleDirection.UpperLeft, (HorizontalAlignment) 0, (Brush) UISetting.Current.ChatBubbleSystemBackground, (Brush) UISetting.Current.ChatBubbleSystemForeground, (Brush) UISetting.Current.ChatBubbleBorderBrush));
        ((UIElement) lvChat).UpdateLayout();
        ((ListViewBase) lvChat).ScrollIntoView(((IList<object>) ((ItemsControl) lvChat).Items)[((ICollection<object>) ((ItemsControl) lvChat).Items).Count - 1]);
      });
    }

    public Action<string, string> CreateErrorMessageLine(ListView lvChat)
    {
      return (Action<string, string>) ((id, m) =>
      {
        if (((IEnumerable<object>) ((ItemsControl) lvChat).Items).Where<object>((Func<object, bool>) (s => s is ChatBubble && ((FrameworkElement) s).Name == id)).FirstOrDefault<object>() is ChatBubble)
          return;
        ((ICollection<object>) ((ItemsControl) lvChat).Items).Add((object) this.CreateChatBubble((object) this.CreateErrorBubbleContent(m, "Error"), id, ChatBubbleDirection.UpperLeft, (HorizontalAlignment) 0, (Brush) UISetting.Current.ChatBubbleErrorBackground, (Brush) UISetting.Current.ChatBubbleErrorForeground, (Brush) UISetting.Current.ChatBubbleBorderBrush));
        ((UIElement) lvChat).UpdateLayout();
        ((ListViewBase) lvChat).ScrollIntoView(((IList<object>) ((ItemsControl) lvChat).Items)[((ICollection<object>) ((ItemsControl) lvChat).Items).Count - 1]);
      });
    }

    public ChatBubble CreateChatBubble(
      object content,
      string id,
      ChatBubbleDirection direction,
      HorizontalAlignment halignment,
      Brush background,
      Brush foreground,
      Brush border)
    {
      ChatBubble chatBubble = new ChatBubble();
      chatBubble.put_Content(content);
      ((FrameworkElement) chatBubble).put_Name(id);
      ((UIElement) chatBubble).put_UseLayoutRounding(true);
      ((Control) chatBubble).put_Padding(UISetting.Current.ChatBubblePadding);
      ((Control) chatBubble).put_BorderThickness(UISetting.Current.ChatBubbleBorderThickness);
      ((Control) chatBubble).put_BorderBrush(border);
      ((Control) chatBubble).put_Background(background);
      ((Control) chatBubble).put_Foreground(foreground);
      chatBubble.ChatBubbleDirection = direction;
      ((FrameworkElement) chatBubble).put_HorizontalAlignment(halignment);
      return chatBubble;
    }

    public Action<string, ChatMessage> CreateMessageLine(TextBlock tbMessages)
    {
      return (Action<string, ChatMessage>) ((id, content) =>
      {
        Run run1 = new Run();
        run1.put_Text(string.Format("{0} ({1}): {2}", (object) content.Header.Sender, (object) content.Header.DateTime.ToString("HH:mm:ss"), (object) content.Body) + Environment.NewLine);
        ((TextElement) run1).put_Foreground((Brush) new SolidColorBrush(Colors.LightBlue));
        Run run2 = run1;
        ChatRun chatRun = new ChatRun();
        ((ICollection<Inline>) chatRun.Inlines).Add((Inline) run2);
        chatRun.MessageId = id;
        ((ICollection<Inline>) tbMessages.Inlines).Add((Inline) chatRun);
      });
    }

    public Action<string, ChatMessage> CreateMessageLine(ListView lvChat)
    {
      return (Action<string, ChatMessage>) ((id, m) =>
      {
        ((ICollection<object>) ((ItemsControl) lvChat).Items).Add((object) this.CreateChatBubble((object) this.CreateBubbleContent(m), id, ChatBubbleDirection.LowerRight, (HorizontalAlignment) 2, (Brush) UISetting.Current.ChatBubbleSendingBackground, (Brush) UISetting.Current.ChatBubbleSendingForeground, (Brush) UISetting.Current.PartiallyConfirmedBrush));
        ((UIElement) lvChat).UpdateLayout();
        ((ListViewBase) lvChat).ScrollIntoView(((IList<object>) ((ItemsControl) lvChat).Items)[((ICollection<object>) ((ItemsControl) lvChat).Items).Count - 1]);
      });
    }

    private StackPanel CreateErrorBubbleContent(string m, string header)
    {
      StackPanel errorBubbleContent = new StackPanel();
      ((FrameworkElement) errorBubbleContent).put_VerticalAlignment((VerticalAlignment) 3);
      ((FrameworkElement) errorBubbleContent).put_MinWidth(UISetting.Current.ChatBubbleMinWidth);
      TextBlock textBlock1 = new TextBlock();
      textBlock1.put_FontSize(UISetting.Current.ChatBubbleFontSize);
      textBlock1.put_Padding(UISetting.Current.ChatBubblePadding);
      textBlock1.put_Text(m);
      textBlock1.put_FontSize(UISetting.Current.ChatBubbleFontSize);
      ((FrameworkElement) textBlock1).put_Margin(UISetting.Current.ChatBubbleContentMargin);
      textBlock1.put_TextWrapping(UISetting.Current.ChatBubbleTextWrapping);
      ((FrameworkElement) textBlock1).put_MinWidth(UISetting.Current.ChatBubbleMinWidth);
      StackPanel stackPanel = new StackPanel();
      ((FrameworkElement) stackPanel).put_HorizontalAlignment((HorizontalAlignment) 2);
      stackPanel.put_Orientation((Orientation) 1);
      TextBlock textBlock2 = new TextBlock();
      textBlock2.put_Text(header);
      textBlock2.put_FontSize(UISetting.Current.ChatBubbleSenderFontSize);
      textBlock2.put_Padding(UISetting.Current.ChatBubbleSenderPadding);
      ((FrameworkElement) textBlock2).put_VerticalAlignment((VerticalAlignment) 0);
      TextBlock textBlock3 = new TextBlock();
      textBlock3.put_FontSize(UISetting.Current.ChatBubbleTimestampFontSize);
      ((FrameworkElement) textBlock3).put_HorizontalAlignment((HorizontalAlignment) 2);
      ((FrameworkElement) textBlock3).put_VerticalAlignment((VerticalAlignment) 2);
      textBlock3.put_Foreground((Brush) UISetting.Current.ChatBubbleTimestampForeground);
      textBlock3.put_Text(DateTime.Now.ToString("HH:mm:ss"));
      textBlock3.put_Padding(UISetting.Current.ChatBubbleTimestampPadding);
      ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) textBlock2);
      ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) textBlock3);
      ((ICollection<UIElement>) ((Panel) errorBubbleContent).Children).Add((UIElement) textBlock1);
      ((ICollection<UIElement>) ((Panel) errorBubbleContent).Children).Add((UIElement) stackPanel);
      return errorBubbleContent;
    }

    private Grid CreateRoomBanner(Room r)
    {
      Grid roomBanner = new Grid();
      ((UIElement) roomBanner).put_Opacity(0.3);
      ((Panel) roomBanner).put_Background((Brush) new SolidColorBrush(Colors.Gray));
      ((FrameworkElement) roomBanner).put_Tag((object) UISetting.Current.BannerTag);
      TextBlock textBlock = new TextBlock();
      textBlock.put_FontSize(UISetting.Current.RoomBannerFontSize);
      textBlock.put_Padding(UISetting.Current.ChatBubblePadding);
      textBlock.put_Text(string.Format("{0}", (object) r.RoomName));
      textBlock.put_FontSize(UISetting.Current.RoomBannerFontSize);
      ((FrameworkElement) textBlock).put_Margin(UISetting.Current.RoomBannerContentMargin);
      textBlock.put_TextWrapping(UISetting.Current.ChatBubbleTextWrapping);
      ((FrameworkElement) textBlock).put_HorizontalAlignment((HorizontalAlignment) 1);
      ((FrameworkElement) textBlock).put_VerticalAlignment((VerticalAlignment) 1);
      ((ICollection<UIElement>) ((Panel) roomBanner).Children).Add((UIElement) textBlock);
      return roomBanner;
    }

    private StackPanel CreateBubbleContent(ChatMessage m)
    {
      StackPanel bubbleContent = new StackPanel();
      ((FrameworkElement) bubbleContent).put_VerticalAlignment((VerticalAlignment) 3);
      bubbleContent.put_Orientation((Orientation) 0);
      TextBlock textBlock1 = new TextBlock();
      textBlock1.put_FontSize(UISetting.Current.ChatBubbleFontSize);
      textBlock1.put_Padding(UISetting.Current.ChatBubbleContentPadding);
      textBlock1.put_Text(m.Body);
      ((FrameworkElement) textBlock1).put_Margin(UISetting.Current.ChatBubbleContentMargin);
      textBlock1.put_TextWrapping(UISetting.Current.ChatBubbleTextWrapping);
      StackPanel stackPanel = new StackPanel();
      ((FrameworkElement) stackPanel).put_HorizontalAlignment((HorizontalAlignment) 2);
      stackPanel.put_Orientation((Orientation) 1);
      ((FrameworkElement) stackPanel).put_Margin(UISetting.Current.ChatBubbleBorderThickness);
      TextBlock textBlock2 = new TextBlock();
      textBlock2.put_Text(m.Header.Sender);
      textBlock2.put_FontSize(UISetting.Current.ChatBubbleSenderFontSize);
      textBlock2.put_Padding(UISetting.Current.ChatBubbleSenderPadding);
      textBlock2.put_Foreground((Brush) UISetting.Current.ChatBubbleSenderForeground);
      ((FrameworkElement) textBlock2).put_VerticalAlignment((VerticalAlignment) 2);
      ((FrameworkElement) textBlock2).put_Margin(new Thickness(0.0, 0.0, 3.0, 0.0));
      TextBlock textBlock3 = new TextBlock();
      textBlock3.put_FontSize(UISetting.Current.ChatBubbleTimestampFontSize);
      ((FrameworkElement) textBlock3).put_HorizontalAlignment((HorizontalAlignment) 2);
      ((FrameworkElement) textBlock3).put_VerticalAlignment((VerticalAlignment) 2);
      textBlock3.put_Foreground((Brush) UISetting.Current.ChatBubbleTimestampForeground);
      textBlock3.put_Text(m.Header.DateTime.ToString("HH:mm:ss"));
      textBlock3.put_Padding(UISetting.Current.ChatBubbleTimestampPadding);
      ((FrameworkElement) textBlock3).put_Margin(new Thickness(0.0, 0.0, 3.0, 0.0));
      HyperlinkButton hyperlinkButton1 = new HyperlinkButton();
      ((FrameworkElement) hyperlinkButton1).put_Margin(UISetting.Current.ChatBubbleTimestampPadding);
      ((Control) hyperlinkButton1).put_Padding(UISetting.Current.ChatBubbleTimestampPadding);
      ((FrameworkElement) hyperlinkButton1).put_HorizontalAlignment((HorizontalAlignment) 2);
      ((FrameworkElement) hyperlinkButton1).put_VerticalAlignment((VerticalAlignment) 2);
      HyperlinkButton hyperlinkButton2 = hyperlinkButton1;
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((ButtonBase) hyperlinkButton2).add_Click), new Action<EventRegistrationToken>(((ButtonBase) hyperlinkButton2).remove_Click), (RoutedEventHandler) ((s, o) => this.PlayMessage(m.Body, this.ForegroundPlayer, VoiceType.Self)));
      ((ContentControl) hyperlinkButton1).put_Content((object) ">>");
      ((Control) hyperlinkButton1).put_FontSize(UISetting.Current.ChatBubbleTimestampFontSize);
      ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) textBlock2);
      ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) textBlock3);
      ((ICollection<UIElement>) ((Panel) stackPanel).Children).Add((UIElement) hyperlinkButton1);
      ((ICollection<UIElement>) ((Panel) bubbleContent).Children).Add((UIElement) textBlock1);
      ((ICollection<UIElement>) ((Panel) bubbleContent).Children).Add((UIElement) stackPanel);
      ((FrameworkElement) bubbleContent).put_VerticalAlignment((VerticalAlignment) 3);
      return bubbleContent;
    }

    public Action<string> CreateLostLine(TextBlock tbMessages)
    {
      return (Action<string>) (id =>
      {
        Inline inline1 = ((IEnumerable<Inline>) tbMessages.Inlines).FirstOrDefault<Inline>((Func<Inline, bool>) (s => s is ChatRun && ((ChatRun) s).MessageId == id));
        if (inline1 == null)
          return;
        Inline inline2 = ((IEnumerable<Inline>) ((Span) inline1).Inlines).FirstOrDefault<Inline>();
        if (!(inline2 is Run))
          return;
        ((TextElement) inline2).put_Foreground((Brush) new SolidColorBrush(Colors.Gray));
      });
    }

    public Action<string> CreateLostLine(ListView lvChat)
    {
      return (Action<string>) (id =>
      {
        if (!(((IEnumerable<object>) ((ItemsControl) lvChat).Items).Where<object>((Func<object, bool>) (s => s is ChatBubble && ((FrameworkElement) s).Name == id)).FirstOrDefault<object>() is ChatBubble chatBubble2))
          return;
        ((UIElement) chatBubble2).put_Opacity(UISetting.Current.ChatBubbleLostOpacity);
        ((Control) chatBubble2).put_Background((Brush) UISetting.Current.ConfirmBrush);
        ((Control) chatBubble2).put_BorderBrush((Brush) UISetting.Current.ConfirmBrush);
      });
    }

    private Action<string, VoiceType> PlayAudio(MediaElement mediaElement)
    {
      return (Action<string, VoiceType>) ((msg, type) => this.PlayMessage(msg, mediaElement, type));
    }

    public async Task PlayMessage(string msg, MediaElement media, VoiceType type)
    {
      string str = Regex.Replace(Regex.Replace(msg, "\\{([^\\}]+)\\}", string.Empty), "\\[([^\\]]+)\\]", string.Empty);
      SpeechSynthesizer speech = UISetting.Current.GetSpeech(type);
      try
      {
        SpeechSynthesisStream streamAsync = await speech.SynthesizeTextToStreamAsync(str);
        media.SetSource((IRandomAccessStream) streamAsync, streamAsync.ContentType);
        media.Play();
        IGM.UI.Util.LogEvent("Text To Speech");
      }
      catch (Exception ex)
      {
      }
    }

    public async Task PlayMessage2(string msg, MediaElement media)
    {
      SpeechSynthesizer speech2 = UISetting.Current.Speech2;
      try
      {
        SpeechSynthesisStream streamAsync = await speech2.SynthesizeTextToStreamAsync(msg);
        media.SetSource((IRandomAccessStream) streamAsync, streamAsync.ContentType);
        media.Play();
        IGM.UI.Util.LogEvent("Text To Speech");
      }
      catch (Exception ex)
      {
      }
    }

    public ChatMessage CreateBotGreetingMessage(Peer lobbyBot)
    {
      return ClientData.Current.CurrentRoom.RoomId == SuperChannel.Lobby.GetKey() ? ClientData.Current.CurrentRoom.CreateBotMessage(ReceptionistBot.GreetConvo, lobbyBot, ClientData.Current.Assistant.BotGender) : ClientData.Current.CurrentRoom.CreateBotMessage(ReceptionistBot.EntersConvo, lobbyBot, ClientData.Current.Assistant.BotGender);
    }

    public ChatMessage CreateBotExitMessage(Peer lobbyBot)
    {
      return ClientData.Current.CurrentRoom.RoomId == SuperChannel.Lobby.GetKey() ? ClientData.Current.CurrentRoom.CreateBotMessage(ReceptionistBot.GoodByeConvo, lobbyBot, ClientData.Current.Assistant.BotGender) : ClientData.Current.CurrentRoom.CreateBotMessage(ReceptionistBot.LeavesConvo, lobbyBot, ClientData.Current.Assistant.BotGender);
    }

    public async void LeaveBot(Peer bot, ListView lvChat)
    {
      Setting.Current.IsAssistantEnabled = false;
      UIBinder.Current.HandleReceivedMessage(UIBinder.Current.CreateBotExitMessage(bot), bot, lvChat, Colors.Gray);
      ClientData.Current.CurrentSite.LobbyBotLeave(bot);
    }

    public async void EnterBot(Peer bot, ListView lvChat)
    {
      Setting.Current.IsAssistantEnabled = true;
      ClientData.Current.CurrentSite.LobbyBotEnter(bot);
      UIBinder.Current.HandleReceivedMessage(!Setting.Current.MaxAssistReached() ? UIBinder.Current.CreateBotGreetingMessage(bot) : ClientData.Current.CurrentRoom.CreateBotMessage(ReceptionistBot.OffDutyMessage(Setting.Current.GetBreakSecondsRemaining()), bot, ClientData.Current.Assistant.BotGender), bot, lvChat, Colors.Gray);
      if (!Setting.Current.MaxAssistReached())
        return;
      this.LeaveBot(bot, lvChat);
    }
  }
}

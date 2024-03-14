// Decompiled with JetBrains decompiler
// Type: weekysoft.store.ChatRoom.ChatLabel
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Bots;


namespace weekysoft.store.ChatRoom
{
  public class ChatLabel
  {
    private static ChatLabel _Current;
    private static string[,] Labels = new string[13, 3]
    {
      {
        "Chat",
        "聊天",
        "Chat"
      },
      {
        "Peers",
        "聊友",
        "Amigos"
      },
      {
        "Rooms",
        "聊天室",
        "Sala"
      },
      {
        "About",
        "关于",
        "Acerca de"
      },
      {
        "Lobby",
        "大厅",
        "Vestíbulo"
      },
      {
        "Receptionist",
        "接待员",
        "Recepcionista"
      },
      {
        "Feedback",
        "提供意见",
        "Comentarios"
      },
      {
        "Share",
        "分享",
        "Compartir"
      },
      {
        "Create Temporary Room",
        "创建临时的聊天室",
        "Crear espacio temporal"
      },
      {
        "Cannot see other peers? Install Netchat on other devices on the same Local/Wifi network.",
        "你看不到其他聊友？在本地网络 Wifi的其他计算机上安装 Netchat。",
        "¿No puede ver a otros compañeros? Instalar Netchat en otros dispositivos en la misma red Local/Wifi."
      },
      {
        "Maximum Temporary Rooms Reached!!",
        "已达到最大的临时房间!!",
        "Habitaciones temporales máxima alcanzaron!!"
      },
      {
        "Comment",
        "提供意见",
        "Comentarios"
      },
      {
        "To use this app: install on multiple devices on the same wifi/local network. You can start chatting across multiple phones and computers without internet.",
        "使用应用程序：在相同的 wifi/本地网络上的多个计算机上安装。你可以开始和多个互联网的计算机聊天。",
        "Para utilizar esta aplicación: instalar en múltiples dispositivos en la misma red wifi local. Puede empezar a chatear en varios teléfonos y computadoras sin internet."
      }
    };

    public Language DefaultLanguage { get; private set; }

    public ChatLabel(Language lan) => this.DefaultLanguage = lan;

    public static ChatLabel Current
    {
      get
      {
        if (ChatLabel._Current == null)
          ChatLabel._Current = new ChatLabel(Language.English);
        return ChatLabel._Current;
      }
    }

    public string _NewTemporaryRoomLabel { get; set; }

    public string NewTemporaryRoomLabel => ChatLabel.Labels[8, (int) this.DefaultLanguage];

    public string ShareLabel => ChatLabel.Labels[7, (int) this.DefaultLanguage];

    public string FeedbackLabel => ChatLabel.Labels[6, (int) this.DefaultLanguage];

    public string PeerNoteLabel => ChatLabel.Labels[9, (int) this.DefaultLanguage];

    public string MaxRoomLabel => ChatLabel.Labels[10, (int) this.DefaultLanguage];

    public string ReceptionistLabel => ChatLabel.Labels[5, (int) this.DefaultLanguage];

    public string LobbyLabel => ChatLabel.Labels[4, (int) this.DefaultLanguage];

    public string CommentLabel => ChatLabel.Labels[11, (int) this.DefaultLanguage];

    public string AppInstructoinLabel => ChatLabel.Labels[12, (int) this.DefaultLanguage];

    public object AboutLabel => (object) ChatLabel.Labels[3, (int) this.DefaultLanguage];

    public string PeersLabel => ChatLabel.Labels[1, (int) this.DefaultLanguage];

    public string RoomsLabel => ChatLabel.Labels[2, (int) this.DefaultLanguage];
  }
}

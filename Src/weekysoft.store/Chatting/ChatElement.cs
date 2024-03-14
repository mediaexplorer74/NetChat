// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Chatting.ChatElement
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.Linq;
using weekysoft.store.Enums;


namespace weekysoft.store.Chatting
{
  public struct ChatElement : IChatElement
  {
    private static readonly char _ChatElementSeparator = '\f';
    private static char[] _CharSpiter = new char[1]
    {
      ChatElement._ChatElementSeparator
    };

    public ElementType ChatType { get; private set; }

    public ChatElement(ElementType et, string value)
    {
      this.ChatType = et;
      this.Value = value;
    }

    public string BuildSendString()
    {
      return string.Format("{0}" + ChatElement._ChatElementSeparator.ToString() + "{1}", (object) this.ChatType.GetKey(), (object) this.Value);
    }

    public string Parse(string[] messageParts)
    {
      foreach (string messagePart in messageParts)
        this.Parse(messagePart);
      return this.Value;
    }

    public void Parse(string message)
    {
      string[] strArray = message.Split(ChatElement._CharSpiter, 2);
      if (strArray.Length != 2 || EnumHelper.GetByKey<ElementType>(strArray[0]) != this.ChatType)
        return;
      this.Value = strArray[1];
    }

    public static ChatElement Extract(ElementType elementType, string[] messageParts)
    {
      string empty = string.Empty;
      string[] strArray = ((IEnumerable<string>) messageParts).Select<string, string[]>((Func<string, string[]>) (s => s.Split(ChatElement._CharSpiter, 2))).FirstOrDefault<string[]>((Func<string[], bool>) (s => s[0] == elementType.GetKey()));
      if (strArray != null && strArray.Length >= 2)
        empty = strArray[1];
      return new ChatElement(elementType, empty);
    }

    public string Value { get; private set; }
  }
}

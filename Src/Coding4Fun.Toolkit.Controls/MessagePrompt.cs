// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.MessagePrompt
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public class MessagePrompt : UserPrompt
  {
    public static readonly DependencyProperty BodyProperty = DependencyProperty.Register(nameof (Body), typeof (object), typeof (MessagePrompt), new PropertyMetadata((object) null));

    public MessagePrompt()
    {
      this.put_DefaultStyleKey((object) typeof (MessagePrompt));
      this.MessageChanged = new Action(this.SetBodyMessage);
    }

    protected internal void SetBodyMessage()
    {
      TextBlock textBlock = new TextBlock();
      textBlock.put_Text(this.Message);
      textBlock.put_TextWrapping((TextWrapping) 2);
      this.Body = (object) textBlock;
    }

    public object Body
    {
      get => ((DependencyObject) this).GetValue(MessagePrompt.BodyProperty);
      set => ((DependencyObject) this).SetValue(MessagePrompt.BodyProperty, value);
    }
  }
}

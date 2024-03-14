// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Enums.CommentType
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using weekysoft.store.Attributes;

#nullable disable
namespace weekysoft.store.Enums
{
  public enum CommentType
  {
    [DisplayName("I love this app!!")] LoveIt,
    [DisplayName("I found a bug")] FoundABug,
    [DisplayName("New feature request")] FeatureRequest,
    [DisplayName("I hate this app!!")] HateIt,
    [DisplayName("Just thought of something...")] Other,
  }
}

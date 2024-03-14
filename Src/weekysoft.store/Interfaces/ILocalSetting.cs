// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Interfaces.ILocalSetting
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace weekysoft.store.Interfaces
{
  public interface ILocalSetting
  {
    T GetValue<T>(T defaultValue = null, [CallerMemberName] string memberName = "");

    void SetValue<T>(T value, [CallerMemberName] string memberName = "");
  }
}

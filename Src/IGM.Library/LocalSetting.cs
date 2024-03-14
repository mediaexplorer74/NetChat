// Decompiled with JetBrains decompiler
// Type: IGM.Library.LocalSetting
// Assembly: IGM.Library, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 843F6794-B124-487F-905F-30809B16B79B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.Library.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using weekysoft.store.Interfaces;
using weekysoft.store.Serializer;
using Windows.Storage;


namespace IGM.Library
{
  public class LocalSetting : ILocalSetting
  {
    private bool _AlwaysUseDefault;
    private ApplicationData data;
    private ApplicationDataContainer _settings;

    public LocalSetting(bool AlwaysUseDefault)
    {
      this.data = ApplicationData.Current;
      this._settings = this.data.LocalSettings;
      this._AlwaysUseDefault = AlwaysUseDefault;
    }

    public T GetValue<T>(T defaultValue = default, [CallerMemberName] string memberName = "")
    {
      T obj = defaultValue;
      if (!this._AlwaysUseDefault)
      {
        if (((IEnumerable<KeyValuePair<string, object>>) this._settings.Values).Any<KeyValuePair<string, object>>((Func<KeyValuePair<string, object>, bool>) (s => s.Key == memberName)))
          obj = typeof (T).GetTypeInfo().IsPrimitive ? (T) ((IDictionary<string, object>) this._settings.Values)[memberName] : XmlSerialization.XmlToObject<T>(((IDictionary<string, object>) this._settings.Values)[memberName].ToString());
        else
          this.SetValue<T>(obj, memberName);
      }
      return obj;
    }

    public void SetValue<T>(T value, [CallerMemberName] string memberName = "")
    {
      if (!typeof (T).GetTypeInfo().IsPrimitive)
        ((IDictionary<string, object>) this._settings.Values)[memberName] = (object) XmlSerialization.ObjectToXml<T>(value);
      else
        ((IDictionary<string, object>) this._settings.Values)[memberName] = (object) value;
    }
  }
}

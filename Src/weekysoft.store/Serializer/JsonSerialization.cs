// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Serializer.JsonSerialization
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

#nullable disable
namespace weekysoft.store.Serializer
{
  public class JsonSerialization
  {
    public static string ObjectToJson<T>(T objectToSerialise)
    {
      MemoryStream memoryStream = new MemoryStream();
      new DataContractJsonSerializer(typeof (T)).WriteObject((Stream) memoryStream, (object) objectToSerialise);
      byte[] array = memoryStream.ToArray();
      memoryStream.Dispose();
      return Encoding.UTF8.GetString(array, 0, array.Length);
    }

    public static T JsonToObject<T>(string json)
    {
      if (string.IsNullOrEmpty(json))
        return default (T);
      json = JsonSerialization.RemoveInvalidCharacters(json);
      MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
      T obj = (T) new DataContractJsonSerializer(typeof (T)).ReadObject((Stream) memoryStream);
      memoryStream.Dispose();
      return obj;
    }

    private static string RemoveInvalidCharacters(string json)
    {
      return json.Replace("\0", "").Replace("\f", "").Replace("\v", "").Replace("\a", "");
    }
  }
}

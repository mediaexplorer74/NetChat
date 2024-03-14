// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Serializer.XmlSerialization
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System.IO;
using System.Text;
using System.Xml.Serialization;


namespace weekysoft.store.Serializer
{
  public class XmlSerialization
  {
    public static string ObjectToXml<T>(T objectToSerialise)
    {
      StringWriter stringWriter = new StringWriter(new StringBuilder());
      new XmlSerializer(objectToSerialise.GetType()).Serialize((TextWriter) stringWriter, (object) objectToSerialise);
      return stringWriter.ToString();
    }

    public static T XmlToObject<T>(string xml)
    {
      if (string.IsNullOrEmpty(xml))
        return default (T);
      return (T) new XmlSerializer(typeof (T)).Deserialize((TextReader) new StringReader(xml));
    }
  }
}

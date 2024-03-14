// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.Common.ManifestHelper
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using System;
using System.Xml;


namespace Coding4Fun.Toolkit.Controls.Common
{
  public class ManifestHelper
  {
    private const string AppManifestName = "AppxManifest.xml";
    private const string DisplayNameNode = "DisplayName";
    private const string IdentityNode = "Identity";
    private const string VersionAttr = "Version";

    public static string GetDisplayName()
    {
      if (ApplicationSpace.IsDesignMode)
        return "";
      try
      {
        using (XmlReader xmlReader = XmlReader.Create("AppxManifest.xml", new XmlReaderSettings()))
        {
          xmlReader.ReadToDescendant("DisplayName");
          return xmlReader.IsStartElement() ? xmlReader.ReadInnerXml() : throw new FormatException("AppxManifest.xml is missing DisplayName");
        }
      }
      catch (Exception ex)
      {
        return "";
      }
    }

    public static string GetVersion()
    {
      if (ApplicationSpace.IsDesignMode)
        return "";
      try
      {
        using (XmlReader xmlReader = XmlReader.Create("AppxManifest.xml", new XmlReaderSettings()))
        {
          xmlReader.ReadToDescendant("Identity");
          return xmlReader.IsStartElement() ? xmlReader.GetAttribute("Version") : throw new FormatException("AppxManifest.xml is missing DisplayName");
        }
      }
      catch (Exception ex)
      {
        return "";
      }
    }
  }
}

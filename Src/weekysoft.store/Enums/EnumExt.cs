// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Enums.EnumExt
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Reflection;
using weekysoft.store.Attributes;

#nullable disable
namespace weekysoft.store.Enums
{
  public static class EnumExt
  {
    public static string GetKey(this object enumValue)
    {
      string key = string.Empty;
      if (enumValue.GetType().GetRuntimeField(enumValue.ToString()).GetCustomAttributes(typeof (EntityKey), false) is EntityKey[] customAttributes && customAttributes.Length != 0)
        key = customAttributes[0].Key;
      return key;
    }

    public static string GetName(this Enum enumValue)
    {
      string name = string.Empty;
      if (enumValue.GetType().GetRuntimeField(enumValue.ToString()).GetCustomAttributes(typeof (EntityName), false) is EntityName[] customAttributes && customAttributes.Length != 0)
        name = customAttributes[0].Name;
      return name;
    }

    public static string GetDisplayName(this Enum enumValue)
    {
      string displayName = string.Empty;
      if (enumValue.GetType().GetRuntimeField(enumValue.ToString()).GetCustomAttributes(typeof (DisplayName), false) is DisplayName[] customAttributes && customAttributes.Length != 0)
        displayName = customAttributes[0].Name;
      return displayName;
    }

    public static Type GetEntityType(this Enum enumValue)
    {
      Type entityType = (Type) null;
      if (enumValue.GetType().GetRuntimeField(enumValue.ToString()).GetCustomAttributes(typeof (EntityType), false) is EntityType[] customAttributes && customAttributes.Length != 0)
        entityType = customAttributes[0].ObjectType;
      return entityType;
    }
  }
}

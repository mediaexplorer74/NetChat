// Decompiled with JetBrains decompiler
// Type: System.TypeExtensions
// Assembly: Coding4Fun.Toolkit, Version=2.0.8.0, Culture=neutral, PublicKeyToken=c5fd7b72b1a17ce4
// MVID: 3554EA1B-1C3D-465C-8F26-35FED8224A72
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.dll

using System.Reflection;


namespace System
{
  public static class TypeExtensions
  {
    public static bool IsTypeOf(this object target, Type type)
    {
      return target.GetType().GetTypeInfo().IsSubclassOf(type);
    }

    public static bool IsTypeOf(this object target, object referenceObject)
    {
      return TypeExtensions.IsTypeOf(target, referenceObject.GetType());
    }
  }
}

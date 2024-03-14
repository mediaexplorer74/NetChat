// Decompiled with JetBrains decompiler
// Type: Coding4Fun.Toolkit.Controls.DevelopmentHelpers
// Assembly: Coding4Fun.Toolkit.Controls, Version=2.1.7.0, Culture=neutral, PublicKeyToken=null
// MVID: A56425CC-78B4-4409-A058-D6DF5D854B90
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\Coding4Fun.Toolkit.Controls.dll

using Coding4Fun.Toolkit.Controls.Common;
using System;

#nullable disable
namespace Coding4Fun.Toolkit.Controls
{
  public static class DevelopmentHelpers
  {
    [Obsolete("Moved to Coding4Fun.Toolkit.Controls.Common.ApplicationSpace")]
    public static bool IsDesignMode => ApplicationSpace.IsDesignMode;

    [Obsolete("Moved to Coding4Fun.Toolkit.dll now, Namespace is System")]
    public static bool IsTypeOf(this object target, Type type)
    {
      return TypeExtensions.IsTypeOf(target, type);
    }

    [Obsolete("Moved to Coding4Fun.Toolkit.dll now, Namespace is System")]
    public static bool IsTypeOf(this object target, object referenceObject)
    {
      return TypeExtensions.IsTypeOf(target, referenceObject);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Util.ImageUtil
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll


namespace weekysoft.store.Util
{
  public class ImageUtil
  {
    private static void ConvertToRGBA(int pixelHeight, int pixelWidth, byte[] pixels)
    {
      if (pixels == null)
        return;
      for (int index1 = 0; (long) index1 < (long) (uint) pixelHeight; ++index1)
      {
        for (int index2 = 0; (long) index2 < (long) (uint) pixelWidth; ++index2)
        {
          int index3 = index1 * pixelWidth * 4 + index2 * 4;
          byte pixel1 = pixels[index3];
          byte pixel2 = pixels[index3 + 1];
          byte pixel3 = pixels[index3 + 2];
          byte pixel4 = pixels[index3 + 3];
          pixels[index3] = pixel3;
          pixels[index3 + 1] = pixel2;
          pixels[index3 + 2] = pixel1;
          pixels[index3 + 3] = pixel4;
        }
      }
    }
  }
}

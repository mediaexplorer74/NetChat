// Decompiled with JetBrains decompiler
// Type: IGM.UI.UISetting
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using weekysoft.store.Bots;
using weekysoft.store.Enums;
using weekysoft.store.Serializer;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.System.UserProfile;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

#nullable disable
namespace IGM.UI
{
  public class UISetting
  {
    private ApplicationData data;
    private static ApplicationDataContainer _settings;
    private static bool _AlwaysUseDefault = true;
    public bool IsInitialized;
    private static UISetting _Current;

    private UISetting()
    {
      this.data = ApplicationData.Current;
      UISetting._settings = this.data.LocalSettings;
      this.IsInitialized = false;
    }

    public async Task Initialize()
    {
      this.ConfirmBrush = new SolidColorBrush(UISetting.GetValue<Color>(Colors.White, "ConfirmBrush"));
      this.ChatBubbleBorderBrush = new SolidColorBrush(UISetting.GetValue<Color>(Colors.White, "ChatBubbleBorderBrush"));
      this.ChatBubbleReceivedBorderBrush = new SolidColorBrush(UISetting.GetValue<Color>(Colors.LightYellow, "ChatBubbleReceivedBorderBrush"));
      this.ChatBubbleReceivedBackground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.LightYellow, "ChatBubbleReceivedBackground"));
      this.ChatBubbleReceivedForeground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.Black, "ChatBubbleReceivedForeground"));
      this.ChatBubbleErrorBackground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.Yellow, "ChatBubbleErrorBackground"));
      this.ChatBubbleErrorForeground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.Red, "ChatBubbleErrorForeground"));
      this.ChatBubbleSendingBackground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.LightBlue, "ChatBubbleSendingBackground"));
      this.ChatBubbleSendingForeground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.Black, "ChatBubbleSendingForeground"));
      this.ChatBubbleSenderForeground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.DarkGray, "ChatBubbleSenderForeground"));
      this.ChatBubbleTimestampForeground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.DarkGray, "ChatBubbleTimestampForeground"));
      this.LostBrush = new SolidColorBrush(UISetting.GetValue<Color>(Colors.Gray, "LostBrush"));
      this.ChatBubbleSystemBackground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.AliceBlue, "ChatBubbleSystemBackground"));
      this.ChatBubbleSystemForeground = new SolidColorBrush(UISetting.GetValue<Color>(Colors.Blue, "ChatBubbleSystemForeground"));
      this.PartiallyConfirmedBrush = new SolidColorBrush(UISetting.GetValue<Color>(Colors.LightCyan, "PartiallyConfirmedBrush"));
      this.ChatBubblePadding = UISetting.GetValue<Thickness>(new Thickness(0.0), "ChatBubblePadding");
      this.ChatBubbleBorderThickness = UISetting.GetValue<Thickness>(new Thickness(1.0), "ChatBubbleBorderThickness");
      this.ChatBubbleContentMargin = UISetting.GetValue<Thickness>(new Thickness(5.0, 0.0, 5.0, 0.0), "ChatBubbleContentMargin");
      this.ChatBubbleSenderPadding = UISetting.GetValue<Thickness>(new Thickness(0.0), "ChatBubbleSenderPadding");
      this.ChatBubbleContentPadding = UISetting.GetValue<Thickness>(new Thickness(0.0), "ChatBubbleContentPadding");
      this.ChatBubbleTimestampPadding = UISetting.GetValue<Thickness>(new Thickness(0.0), "ChatBubbleTimestampPadding");
      this.RoomBannerContentMargin = UISetting.GetValue<Thickness>(new Thickness(5.0, 2.0, 5.0, 2.0), "RoomBannerContentMargin");
      this.ChatBubbleFontSize = UISetting.GetValue<double>(14.0, "ChatBubbleFontSize");
      this.ChatBubbleTextWrapping = UISetting.GetValue<TextWrapping>((TextWrapping) 3, "ChatBubbleTextWrapping");
      this.ChatBubbleMinWidth = UISetting.GetValue<double>(200.0, "ChatBubbleMinWidth");
      this.ChatBubbleSenderFontSize = UISetting.GetValue<double>(10.0, "ChatBubbleSenderFontSize");
      this.ChatBubbleTimestampFontSize = UISetting.GetValue<double>(10.0, "ChatBubbleTimestampFontSize");
      this.ChatBubbleLostOpacity = UISetting.GetValue<double>(0.5, "ChatBubbleLostOpacity");
      this.RoomBannerFontSize = UISetting.GetValue<double>(18.0, "RoomBannerFontSize");
      this.DefaultLanguage = Language.English;
      try
      {
        VoiceInformation defaultVoice = SpeechSynthesizer.DefaultVoice;
        this.DefaultLanguageCode = defaultVoice.Language.ToLower();
        this.DefaultLanguage = EnumHelper.GetByKey<Language>(this.DefaultLanguageCode?.Substring(0, 2));
        this.FemaleVoice = SpeechSynthesizer.AllVoices.FirstOrDefault<VoiceInformation>((Func<VoiceInformation, bool>) (s => s.Language.ToLower() == this.DefaultLanguageCode && s.Gender == 1));
        this.FemaleSpeech = new SpeechSynthesizer();
        this.FemaleSpeech.put_Voice(this.FemaleVoice);
        this.MaleVoice = SpeechSynthesizer.AllVoices.FirstOrDefault<VoiceInformation>((Func<VoiceInformation, bool>) (s => s.Language.ToLower() == this.DefaultLanguageCode && s.Gender == 0));
        this.MaleSpeech = new SpeechSynthesizer();
        this.MaleSpeech.put_Voice(this.MaleVoice);
        this.Speech = new SpeechSynthesizer();
        this.Voice = SpeechSynthesizer.AllVoices.FirstOrDefault<VoiceInformation>((Func<VoiceInformation, bool>) (s => s.DisplayName == UISetting.GetValue<string>(defaultVoice.DisplayName, "Voice")));
        this.Speech.put_Voice(this.Voice);
        this.Speech2 = new SpeechSynthesizer();
        this.Voice2 = SpeechSynthesizer.AllVoices.FirstOrDefault<VoiceInformation>((Func<VoiceInformation, bool>) (s => s.DisplayName == UISetting.GetValue<string>(SpeechSynthesizer.AllVoices.FirstOrDefault<VoiceInformation>((Func<VoiceInformation, bool>) (t => t.DisplayName != this.Voice.DisplayName && t.Language == this.Voice.Language))?.DisplayName, "Voice2")));
        this.Speech2.put_Voice(this.Voice2 ?? this.Voice);
      }
      catch (Exception ex)
      {
        Util.LogEvent(ex);
      }
      this.BannerTag = "BANNER";
      this.DisplayName = await UserInformation.GetDisplayNameAsync();
      this.IsInitialized = true;
    }

    public SpeechSynthesizer GetSpeech(VoiceType type)
    {
      switch (type)
      {
        case VoiceType.Self:
          return this.Speech;
        case VoiceType.Peer:
          return this.Speech2 ?? this.Speech;
        case VoiceType.Female:
          return this.FemaleSpeech ?? this.Speech;
        case VoiceType.Male:
          return this.MaleSpeech ?? this.Speech;
        default:
          return this.Speech;
      }
    }

    public void Save()
    {
      UISetting.SetValue<Color>(this.ConfirmBrush.Color, "ConfirmBrush");
      UISetting.SetValue<Color>(this.ChatBubbleBorderBrush.Color, "ChatBubbleBorderBrush");
      UISetting.SetValue<Color>(this.ChatBubbleReceivedBorderBrush.Color, "ChatBubbleReceivedBorderBrush");
      UISetting.SetValue<Color>(this.ChatBubbleReceivedBackground.Color, "ChatBubbleReceivedBackground");
      UISetting.SetValue<Color>(this.ChatBubbleReceivedForeground.Color, "ChatBubbleReceivedForeground");
      UISetting.SetValue<Color>(this.ChatBubbleErrorBackground.Color, "ChatBubbleErrorBackground");
      UISetting.SetValue<Color>(this.ChatBubbleErrorForeground.Color, "ChatBubbleErrorForeground");
      UISetting.SetValue<Color>(this.ChatBubbleSendingBackground.Color, "ChatBubbleSendingBackground");
      UISetting.SetValue<Color>(this.ChatBubbleSendingForeground.Color, "ChatBubbleSendingForeground");
      UISetting.SetValue<Color>(this.ChatBubbleSenderForeground.Color, "ChatBubbleSenderForeground");
      UISetting.SetValue<Color>(this.ChatBubbleTimestampForeground.Color, "ChatBubbleTimestampForeground");
      UISetting.SetValue<Color>(this.LostBrush.Color, "LostBrush");
      UISetting.SetValue<Color>(this.ChatBubbleSystemBackground.Color, "ChatBubbleSystemBackground");
      UISetting.SetValue<Color>(this.ChatBubbleSystemForeground.Color, "ChatBubbleSystemForeground");
      UISetting.SetValue<Color>(this.PartiallyConfirmedBrush.Color, "PartiallyConfirmedBrush");
      UISetting.SetValue<Thickness>(this.ChatBubblePadding, "ChatBubblePadding");
      UISetting.SetValue<Thickness>(this.ChatBubbleBorderThickness, "ChatBubbleBorderThickness");
      UISetting.SetValue<Thickness>(this.ChatBubbleContentMargin, "ChatBubbleContentMargin");
      UISetting.SetValue<Thickness>(this.ChatBubbleSenderPadding, "ChatBubbleSenderPadding");
      UISetting.SetValue<Thickness>(this.ChatBubbleContentPadding, "ChatBubbleContentPadding");
      UISetting.SetValue<Thickness>(this.ChatBubbleTimestampPadding, "ChatBubbleTimestampPadding");
      UISetting.SetValue<Thickness>(this.RoomBannerContentMargin, "RoomBannerContentMargin");
      UISetting.SetValue<double>(this.ChatBubbleFontSize, "ChatBubbleFontSize");
      UISetting.SetValue<TextWrapping>(this.ChatBubbleTextWrapping, "ChatBubbleTextWrapping");
      UISetting.SetValue<double>(this.ChatBubbleMinWidth, "ChatBubbleMinWidth");
      UISetting.SetValue<double>(this.ChatBubbleSenderFontSize, "ChatBubbleSenderFontSize");
      UISetting.SetValue<double>(this.ChatBubbleTimestampFontSize, "ChatBubbleTimestampFontSize");
      UISetting.SetValue<double>(this.ChatBubbleLostOpacity, "ChatBubbleLostOpacity");
      UISetting.SetValue<double>(this.RoomBannerFontSize, "RoomBannerFontSize");
      UISetting.SetValue<string>(this.Voice.DisplayName, "Voice");
      UISetting.SetValue<string>(this.Voice2.DisplayName, "Voice2");
    }

    public async void ResetToDefault()
    {
      UISetting._AlwaysUseDefault = true;
      await this.Initialize();
      UISetting._AlwaysUseDefault = false;
    }

    public static UISetting Current
    {
      get
      {
        if (UISetting._Current == null)
          UISetting._Current = new UISetting();
        return UISetting._Current;
      }
    }

    private static T GetValue<T>(T defaultValue = null, [CallerMemberName] string memberName = "")
    {
      T obj = defaultValue;
      if (!UISetting._AlwaysUseDefault)
      {
        if (((IEnumerable<KeyValuePair<string, object>>) UISetting._settings.Values).Any<KeyValuePair<string, object>>((Func<KeyValuePair<string, object>, bool>) (s => s.Key == memberName)))
          obj = typeof (T).GetTypeInfo().IsPrimitive ? (T) ((IDictionary<string, object>) UISetting._settings.Values)[memberName] : XmlSerialization.XmlToObject<T>(((IDictionary<string, object>) UISetting._settings.Values)[memberName].ToString());
        else
          UISetting.SetValue<T>(obj, memberName);
      }
      return obj;
    }

    private static void SetValue<T>(T value, [CallerMemberName] string memberName = "")
    {
      if (!typeof (T).GetTypeInfo().IsPrimitive)
        ((IDictionary<string, object>) UISetting._settings.Values)[memberName] = (object) XmlSerialization.ObjectToXml<T>(value);
      else
        ((IDictionary<string, object>) UISetting._settings.Values)[memberName] = (object) value;
    }

    public Language DefaultLanguage { get; private set; }

    public SolidColorBrush ConfirmBrush { get; set; }

    public Thickness ChatBubblePadding { get; set; }

    public double ChatBubbleFontSize { get; set; }

    public Thickness ChatBubbleBorderThickness { get; set; }

    public SolidColorBrush PartiallyConfirmedBrush { get; set; }

    public SolidColorBrush ChatBubbleBorderBrush { get; set; }

    public SolidColorBrush ChatBubbleReceivedBackground { get; set; }

    public SolidColorBrush ChatBubbleReceivedForeground { get; set; }

    public SolidColorBrush ChatBubbleErrorBackground { get; set; }

    public SolidColorBrush ChatBubbleErrorForeground { get; set; }

    public SolidColorBrush ChatBubbleSendingBackground { get; set; }

    public SolidColorBrush ChatBubbleSendingForeground { get; set; }

    public Thickness ChatBubbleContentMargin { get; set; }

    public TextWrapping ChatBubbleTextWrapping { get; set; }

    public double ChatBubbleMinWidth { get; set; }

    public SolidColorBrush ChatBubbleSenderForeground { get; set; }

    public Thickness ChatBubbleSenderPadding { get; set; }

    public double ChatBubbleSenderFontSize { get; set; }

    public double ChatBubbleTimestampFontSize { get; set; }

    public SolidColorBrush ChatBubbleTimestampForeground { get; set; }

    public Thickness ChatBubbleContentPadding { get; set; }

    public Thickness ChatBubbleTimestampPadding { get; set; }

    public double ChatBubbleLostOpacity { get; set; }

    public SpeechSynthesizer Speech { get; set; }

    public VoiceInformation Voice { get; private set; }

    public SolidColorBrush ChatBubbleReceivedBorderBrush { get; private set; }

    public SpeechSynthesizer Speech2 { get; set; }

    public VoiceInformation Voice2 { get; private set; }

    public VoiceInformation FemaleVoice { get; private set; }

    public VoiceInformation MaleVoice { get; private set; }

    public string DisplayName { get; private set; }

    public BitmapImage ProfileImage { get; private set; }

    public double RoomBannerFontSize { get; internal set; }

    public Thickness RoomBannerContentMargin { get; internal set; }

    public SolidColorBrush LostBrush { get; internal set; }

    public string BannerTag { get; internal set; }

    public SolidColorBrush ChatBubbleSystemBackground { get; internal set; }

    public SolidColorBrush ChatBubbleSystemForeground { get; internal set; }

    public string DefaultLanguageCode { get; private set; }

    public SpeechSynthesizer FemaleSpeech { get; private set; }

    public SpeechSynthesizer MaleSpeech { get; private set; }
  }
}

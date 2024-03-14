// Decompiled with JetBrains decompiler
// Type: weekysoft.store.Storage.Setting
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using weekysoft.store.Interfaces;

#nullable disable
namespace weekysoft.store.Storage
{
  public class Setting : INotifyPropertyChanged
  {
    public bool IsInitialized;
    private static int DefaultMaxAssistPerShift;
    private static int DefaultBreakDurationSeconds;
    private ILocalSetting _LocalSetting;
    private bool _IsSpeechEnabled;
    private bool _IsAssistantEnabled;
    private int _DailyAssistCount;
    public string[] Ports = new string[1]{ "22111" };
    public readonly string EnableDebugMode = "#debug#";
    public readonly string DisableDelay = "#nodelay#";

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      if (!(propertyName != ""))
        return;
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    public Setting(ILocalSetting setting)
    {
      this._LocalSetting = setting;
      this.IsInitialized = false;
      Setting.DefaultMaxAssistPerShift = 100;
      Setting.DefaultBreakDurationSeconds = 7200;
    }

    public void Initialize()
    {
      this.IsSpeechEnabled = this._LocalSetting != null && this._LocalSetting.GetValue<bool>(memberName: "IsSpeechEnabled");
      this.IsAssistantEnabled = this._LocalSetting != null && this._LocalSetting.GetValue<bool>(memberName: "IsAssistantEnabled");
      this.DailyAssistCount = this._LocalSetting == null ? 0 : this._LocalSetting.GetValue<int>(memberName: "DailyAssistCount");
      this.MaxAssistPerShift = Setting.DefaultMaxAssistPerShift;
      this.LastDateTime = this._LocalSetting == null ? DateTime.Now : this._LocalSetting.GetValue<DateTime>(DateTime.Now, "LastDateTime");
      this.BreakDurationSeconds = Setting.DefaultBreakDurationSeconds;
      this.LifetimeAssistCount = this._LocalSetting == null ? 0 : this._LocalSetting.GetValue<int>(memberName: "LifetimeAssistCount");
      this.TryResetCounter();
      this.IsDebugMode = false;
      this.HasDelay = true;
      this.IsInitialized = true;
    }

    public void TryResetCounter()
    {
      if (this.GetBreakSecondsRemaining() > 0)
        return;
      this.LastDateTime = DateTime.Now;
      this.DailyAssistCount = 0;
    }

    public bool MaxAssistReached()
    {
      this.TryResetCounter();
      return this.DailyAssistCount >= this.MaxAssistPerShift;
    }

    public int GetBreakSecondsRemaining()
    {
      return Math.Max(0, this.BreakDurationSeconds - (int) DateTime.Now.Subtract(this.LastDateTime).TotalSeconds);
    }

    public void Save()
    {
      this._LocalSetting?.SetValue<bool>(this.IsSpeechEnabled, "IsSpeechEnabled");
      this._LocalSetting?.SetValue<bool>(this.IsAssistantEnabled, "IsAssistantEnabled");
      this._LocalSetting?.SetValue<int>(this.DailyAssistCount, "DailyAssistCount");
      this._LocalSetting?.SetValue<DateTime>(this.LastDateTime, "LastDateTime");
    }

    public void ResetToDefault() => this.Initialize();

    public static Setting Current { get; set; }

    public bool IsSpeechEnabled
    {
      get => this._IsSpeechEnabled;
      set
      {
        this._IsSpeechEnabled = value;
        this.NotifyPropertyChanged("TTSBgColor");
      }
    }

    public bool IsAssistantEnabled
    {
      get => this._IsAssistantEnabled;
      set
      {
        this._IsAssistantEnabled = value;
        this.NotifyPropertyChanged(nameof (IsAssistantEnabled));
        this.NotifyPropertyChanged("AssistantBgColor");
      }
    }

    public int DailyAssistCount
    {
      get => this._DailyAssistCount;
      set
      {
        if (value > this._DailyAssistCount)
          ++this.LifetimeAssistCount;
        this._DailyAssistCount = value;
        if (value < this.MaxAssistPerShift)
          return;
        this.LastDateTime = DateTime.Now > this.LastDateTime ? DateTime.Now : this.LastDateTime;
      }
    }

    public int MaxAssistPerShift { get; set; }

    public DateTime LastDateTime { get; set; }

    public int BreakDurationSeconds { get; set; }

    public string TTSBgColor => this.IsSpeechEnabled ? "#CC8329" : "#333333";

    public string AssistantBgColor => this.IsAssistantEnabled ? "#CC8329" : "#333333";

    public string AssistantToggleImage
    {
      get => this.IsAssistantEnabled ? "AssistantEnabled.png" : "AssistantDisabled.png";
    }

    public string SpeechToggleImage
    {
      get => this.IsSpeechEnabled ? "SpeechEnabled.png" : "SpeechDisabled.png";
    }

    public string SendingPort => "22112";

    public string ReceivingPort => "22111";

    public string FacebookAppId => "990907747636818";

    public bool IsEncrypted => true;

    public bool HasAd => true;

    public string BroadcastAddress => "255.255.255.255";

    public int MessageDelayMiliseconds => 45;

    public int ListViewScrollDelayMiliseconds => 500;

    public bool IsDebugMode { get; set; }

    public bool HasDelay { get; set; }

    public int LifetimeAssistCount { get; private set; }

    public string GetLifeTimeUseCountRange(int lifetimeCount)
    {
      if (lifetimeCount <= 200)
      {
        if (lifetimeCount <= 20)
        {
          if (lifetimeCount != 10 && lifetimeCount != 20)
            goto label_8;
        }
        else if (lifetimeCount != 50 && lifetimeCount != 100 && lifetimeCount != 200)
          goto label_8;
      }
      else if (lifetimeCount <= 1000)
      {
        if (lifetimeCount != 500 && lifetimeCount != 1000)
          goto label_8;
      }
      else if (lifetimeCount != 2000 && lifetimeCount != 5000 && lifetimeCount != 10000)
        goto label_8;
      return lifetimeCount.ToString();
label_8:
      return "0";
    }

    public int LifetimeUseCount
    {
      get => this._LocalSetting.GetValue<int>(memberName: nameof (LifetimeUseCount));
      set => this._LocalSetting.SetValue<int>(value, nameof (LifetimeUseCount));
    }

    public int CurrentUseCount
    {
      get => this._LocalSetting.GetValue<int>(memberName: nameof (CurrentUseCount));
      set => this._LocalSetting.SetValue<int>(value, nameof (CurrentUseCount));
    }

    public bool Rated
    {
      get => this._LocalSetting.GetValue<bool>(memberName: nameof (Rated));
      set => this._LocalSetting.SetValue<bool>(value, nameof (Rated));
    }
  }
}

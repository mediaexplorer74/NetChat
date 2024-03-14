// Decompiled with JetBrains decompiler
// Type: weekysoft.store.ChatRoom.Member
// Assembly: weekysoft.store, Version=2.0.6272.32043, Culture=neutral, PublicKeyToken=null
// MVID: 5346AFDA-B762-4A4C-8E26-6978C993B771
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\weekysoft.store.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

#nullable disable
namespace weekysoft.store.ChatRoom
{
  [DataContract]
  public class Member : INotifyPropertyChanged
  {
    public static readonly int TimeOut = 35;
    public static readonly int RenewTime = 10;
    public static List<KeyValuePair<string, int>> SignalStrengths = new List<KeyValuePair<string, int>>();
    private string _SignalSymbol;
    private string _SignalColor;
    private DateTime _ActiveTime;
    private Queue<bool> _Signals;

    protected virtual string Id { get; }

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

    public void UpdateSignalStat()
    {
      KeyValuePair<string, int> keyValuePair = Member.SignalStrengths.Where<KeyValuePair<string, int>>((Func<KeyValuePair<string, int>, bool>) (s => s.Key == this.Id)).FirstOrDefault<KeyValuePair<string, int>>();
      if (keyValuePair.Key != null)
        Member.SignalStrengths.Remove(keyValuePair);
      Member.SignalStrengths.Add(new KeyValuePair<string, int>(this.Id, this.SignalStrength()));
    }

    public void RestoreSignalStat(bool self = false)
    {
      KeyValuePair<string, int> keyValuePair = Member.SignalStrengths.Where<KeyValuePair<string, int>>((Func<KeyValuePair<string, int>, bool>) (s => s.Key == this.Id)).FirstOrDefault<KeyValuePair<string, int>>();
      if (keyValuePair.Key != null)
      {
        this.SetSignal(keyValuePair.Value);
        if (!self)
          return;
        this.SignalSymbol = "SolidStar";
      }
      else
        this.CalculateSignal(Member.TimeOut, Member.RenewTime, self);
    }

    public string SignalSymbol
    {
      get
      {
        if (string.IsNullOrEmpty(this._SignalSymbol))
          this._SignalSymbol = "FourBars";
        return this._SignalSymbol;
      }
      set
      {
        if (!(this._SignalSymbol != value))
          return;
        this._SignalSymbol = value;
        this.UpdateSignalColor(this._SignalSymbol);
        this.NotifyPropertyChanged(nameof (SignalSymbol));
      }
    }

    private void UpdateSignalColor(string _SignalSymbol)
    {
      switch (_SignalSymbol)
      {
        case "SolidStar":
          this.SignalColor = "Green";
          break;
        case "FourBars":
          this.SignalColor = "Green";
          break;
        case "ThreeBars":
          this.SignalColor = "Yellow";
          break;
        case "TwoBars":
          this.SignalColor = "Orange";
          break;
        case "OneBar":
          this.SignalColor = "Red";
          break;
        case "ZeroBars":
          this.SignalColor = "Gray";
          break;
        default:
          this.SignalColor = "Gray";
          break;
      }
    }

    public string SignalColor
    {
      get
      {
        if (string.IsNullOrEmpty(this._SignalColor))
          this._SignalColor = "Green";
        return this._SignalColor;
      }
      set
      {
        if (!(this._SignalColor != value))
          return;
        this._SignalColor = value;
        this.NotifyPropertyChanged(nameof (SignalColor));
      }
    }

    public DateTime ActiveTime
    {
      get => this._ActiveTime;
      set
      {
        this._ActiveTime = value;
        this.NotifyPropertyChanged(nameof (ActiveTime));
      }
    }

    public Member() => this._Signals = new Queue<bool>();

    public Queue<bool> Signals
    {
      get
      {
        if (this._Signals == null)
          this._Signals = new Queue<bool>();
        return this._Signals;
      }
      set => this._Signals = value;
    }

    private int Samples => 5;

    private void GainSignal()
    {
      if (this.Signals.Count<bool>() == this.Samples)
        this.Signals.Dequeue();
      this.Signals.Enqueue(true);
      this.UpdateSymbol(this.SignalStrength());
    }

    private void LoseSignal()
    {
      if (this.Signals.Count<bool>() == this.Samples)
        this.Signals.Dequeue();
      this.Signals.Enqueue(false);
      this.UpdateSymbol(this.SignalStrength());
    }

    public int SignalStrength()
    {
      return this.Signals.Count<bool>() == 0 ? 0 : this.Signals.Where<bool>((Func<bool, bool>) (s => s)).Count<bool>() * 5 / Math.Min(this.Samples, this.Signals.Count<bool>());
    }

    public void SetSignal(int strength)
    {
      this.Signals.Clear();
      for (int index = 0; index < strength; ++index)
        this.GainSignal();
      for (int index = 0; index < this.Samples - strength; ++index)
        this.LoseSignal();
    }

    public void CalculateSignal(int timeout, int renewTime, bool self = false)
    {
      int seconds = DateTime.Now.Subtract(this.ActiveTime).Seconds;
      bool flag1 = seconds >= timeout - renewTime;
      bool flag2 = seconds >= renewTime;
      if (self)
        this.SignalSymbol = "SolidStar";
      else if (flag1)
      {
        this.LoseSignal();
        this.LoseSignal();
      }
      else if (flag2)
        this.LoseSignal();
      else
        this.GainSignal();
    }

    private void UpdateSymbol(int v)
    {
      switch (v)
      {
        case 0:
          this.SignalSymbol = "ZeroBars";
          break;
        case 1:
          this.SignalSymbol = "OneBar";
          break;
        case 2:
          this.SignalSymbol = "TwoBars";
          break;
        case 3:
          this.SignalSymbol = "ThreeBars";
          break;
        case 4:
          this.SignalSymbol = "FourBars";
          break;
        case 5:
          this.SignalSymbol = "FourBars";
          break;
        default:
          this.SignalSymbol = "FourBars";
          break;
      }
    }

    private void Increment()
    {
      switch (this.SignalSymbol)
      {
        case "FourBars":
          this.SignalSymbol = "FourBars";
          break;
        case "ThreeBars":
          this.SignalSymbol = "FourBars";
          break;
        case "TwoBars":
          this.SignalSymbol = "ThreeBars";
          break;
        case "OneBar":
          this.SignalSymbol = "TwoBars";
          break;
        default:
          this.SignalSymbol = "OneBar";
          break;
      }
    }

    private void Decrement()
    {
      switch (this.SignalSymbol)
      {
        case "FourBars":
          this.SignalSymbol = "ThreeBars";
          break;
        case "ThreeBars":
          this.SignalSymbol = "TwoBars";
          break;
        case "TwoBars":
          this.SignalSymbol = "OneBar";
          break;
        case "OneBar":
          this.SignalSymbol = "ZeroBars";
          break;
        default:
          this.SignalSymbol = "ZeroBars";
          break;
      }
    }
  }
}

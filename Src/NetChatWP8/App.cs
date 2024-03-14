// Decompiled with JetBrains decompiler
// Type: IGM.UI.App
// Assembly: IGM.UI.WindowsPhone, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 39AE0C25-23A8-498B-8A6F-1CF45DE9A28B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.UI.WindowsPhone.exe

using IGM.Library;
using IGM.UI.IGM_UI_WindowsPhone_XamlTypeInfo;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using weekysoft.store.Bots;
using weekysoft.store.ChatRoom;
using weekysoft.store.Interfaces;
using weekysoft.store.Messaging;
using weekysoft.store.Storage;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

#nullable disable
namespace IGM.UI
{
  public sealed class App : Application, IComponentConnector, IXamlMetadataProvider
  {
    private TransitionCollection transitions;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;
    private XamlTypeInfoProvider _provider;

    public App()
    {
      this.InitializeComponent();
      WindowsRuntimeMarshal.AddEventHandler<SuspendingEventHandler>(new Func<SuspendingEventHandler, EventRegistrationToken>(((Application) this).add_Suspending), new Action<EventRegistrationToken>(((Application) this).remove_Suspending), new SuspendingEventHandler(this.OnSuspending));
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(((Application) this).add_Resuming), new Action<EventRegistrationToken>(((Application) this).remove_Resuming), new EventHandler<object>(this.App_Resuming));
      this.put_RequestedTheme((ApplicationTheme) 1);
      WindowsRuntimeMarshal.AddEventHandler<UnhandledExceptionEventHandler>(new Func<UnhandledExceptionEventHandler, EventRegistrationToken>(((Application) this).add_UnhandledException), new Action<EventRegistrationToken>(((Application) this).remove_UnhandledException), new UnhandledExceptionEventHandler(this.App_UnhandledException));
    }

    private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      ClientData.Current.ChatMessaging.RaiseError(new ErrorEventArgs(ErrorType.Unknown, e.Exception));
      Util.LogEvent(e.Exception);
    }

    private async void App_Resuming(object sender, object e)
    {
      ClientData.Current.CurrentRoom.Enter(ClientData.Current.MySelf);
      ClientData.Current.CurrentSite.AdvertiseRooms();
    }

    protected virtual async void OnLaunched(LaunchActivatedEventArgs e)
    {
      Exception startupError = (Exception) null;
      if (e.PreviousExecutionState == null || e.PreviousExecutionState == 3 || e.PreviousExecutionState == 4)
      {
        try
        {
          if (Setting.Current == null)
            Setting.Current = new Setting((ILocalSetting) new LocalSetting(false));
          if (!Setting.Current.IsInitialized)
            Setting.Current.Initialize();
        }
        catch (Exception ex)
        {
          Util.LogEvent("Setting Initialize Error: " + ex.Message);
          if (ex.InnerException != null)
            Util.LogEvent("Setting Initialize Error Inner: " + ex.InnerException?.Message);
          startupError = ex;
        }
        try
        {
          if (ClientData.Current == null)
          {
            IPAddressManager manager = new IPAddressManager();
            ClientData.Current = new ClientData((IMessaging) new WindowsMessaging(Setting.Current.SendingPort, Setting.Current.Ports, Setting.Current.BroadcastAddress, sendBuffer: 1000, receiveBuffer: 1000, deliveryTimeoutMilSec: 2000, reconfirm: true));
            await ClientData.Current.ChatMessaging.Initialize((IIPAddressManager) manager);
          }
        }
        catch (Exception ex)
        {
          Util.LogEvent("ChatMessaging Initialize Error: " + ex.Message);
          if (ex.InnerException != null)
            Util.LogEvent("ChatMessaging Initialize Error Inner: " + ex.InnerException?.Message);
          startupError = ex;
        }
        try
        {
          if (!UISetting.Current.IsInitialized)
            await UISetting.Current.Initialize();
          Bot.DefaultLanguage = UISetting.Current.DefaultLanguage;
          Bot.DefaultLanguageCode = UISetting.Current.DefaultLanguageCode;
          BingSearchBot.MarketCode = UISetting.Current.DefaultLanguageCode;
          ClientData.Current.ChatLabel = new ChatLabel(UISetting.Current.DefaultLanguage);
        }
        catch (Exception ex)
        {
          Util.LogEvent("UISetting Initialize Error: " + ex.Message);
          if (ex.InnerException != null)
            Util.LogEvent("UISetting Initialize Error Inner: " + ex.InnerException?.Message);
          startupError = ex;
        }
        if (!string.IsNullOrWhiteSpace(UISetting.Current.DisplayName))
        {
          ClientData.Current.MySelf.DisplayName = UISetting.Current.DisplayName;
          ClientData.Current.ChatMessaging.UserName = UISetting.Current.DisplayName;
        }
        else
          ClientData.Current.MySelf.DisplayName = ClientData.Current.ChatMessaging.UserName;
      }
      if (!(Window.Current.Content is Frame frame1))
      {
        frame1 = new Frame();
        frame1.put_CacheSize(1);
        ApplicationExecutionState previousExecutionState = e.PreviousExecutionState;
        Window.Current.put_Content((UIElement) frame1);
      }
      if (((ContentControl) frame1).Content == null)
      {
        if (((ContentControl) frame1).ContentTransitions != null)
        {
          this.transitions = new TransitionCollection();
          foreach (Transition contentTransition in (IEnumerable<Transition>) ((ContentControl) frame1).ContentTransitions)
            ((ICollection<Transition>) this.transitions).Add(contentTransition);
        }
        ((ContentControl) frame1).put_ContentTransitions((TransitionCollection) null);
        Frame frame2 = frame1;
        WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(frame2.add_Navigated), new Action<EventRegistrationToken>(frame2.remove_Navigated), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
        if (!frame1.Navigate(typeof (MainPage), (object) e.Arguments))
          throw new Exception("Failed to create initial page");
      }
      Window.Current.Activate();
      if (startupError == null)
        return;
      IUICommand iuiCommand = await new MessageDialog(startupError.Message, "Initialization Error").ShowAsync();
    }

    private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
    {
      Frame frame = sender as Frame;
      TransitionCollection transitionCollection1 = this.transitions;
      if (transitionCollection1 == null)
      {
        TransitionCollection transitionCollection2 = new TransitionCollection();
        ((ICollection<Transition>) transitionCollection2).Add((Transition) new NavigationThemeTransition());
        transitionCollection1 = transitionCollection2;
      }
      ((ContentControl) frame).put_ContentTransitions(transitionCollection1);
      // ISSUE: virtual method pointer
      WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>((object) frame, __vmethodptr(frame, remove_Navigated)), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
    }

    private async void OnSuspending(object sender, SuspendingEventArgs e)
    {
      SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
      ClientData.Current.CurrentRoom.Leave(ClientData.Current.MySelf);
      Setting.Current.Save();
      deferral.Complete();
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target) => this._contentLoaded = true;

    public IXamlType GetXamlType(Type type)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByType(type);
    }

    public IXamlType GetXamlType(string fullName)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByName(fullName);
    }

    public XmlnsDefinition[] GetXmlnsDefinitions() => new XmlnsDefinition[0];
  }
}

// Decompiled with JetBrains decompiler
// Type: IGM.Library.WindowsMessaging
// Assembly: IGM.Library, Version=1.7.12.11, Culture=neutral, PublicKeyToken=null
// MVID: 843F6794-B124-487F-905F-30809B16B79B
// Assembly location: C:\Users\Admin\Desktop\RE\NetChatWP8\IGM.Library.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using weekysoft.store.Messaging;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;


namespace IGM.Library
{
  public class WindowsMessaging : RelayMessaging
  {
    protected List<DataWriter> _Writers;

    protected List<DatagramSocket> Listeners { get; private set; }

    public WindowsMessaging(
      string sendingPort,
      string[] receivingPorts,
      string broadcastAddress = "255.255.255.255",
      bool ignoreSelf = true,
      int repeatCount = 1,
      int sendBuffer = 60,
      int receiveBuffer = 60,
      int deliveryTimeoutMilSec = 1000,
      int messageDelay = 45,
      bool reconfirm = false)
      : base(sendingPort, receivingPorts, broadcastAddress, ignoreSelf, repeatCount, sendBuffer, 
            receiveBuffer, deliveryTimeoutMilSec, messageDelay, reconfirm)
    {
      this._Writers = new List<DataWriter>();
      this.Listeners = new List<DatagramSocket>();
    }

    protected override async Task SetupBroadcaster()
    {
      if (this.IsBroadcastSetup)
        return;
      this._Writers = new List<DataWriter>();
      foreach (string host in this.HostNames)
      {
        string[] strArray = this._ReceivingPorts;
        for (int index = 0; index < strArray.Length; ++index)
        {
          string port = strArray[index];
          try
          {
            DatagramSocket Broadcaster = new DatagramSocket();

            await Broadcaster.ConnectAsync(new EndpointPair(new HostName(host),
                (Convert.ToInt32(port) + 1).ToString(), new HostName(this._BroadcastAddress), port));
            this._Writers.Add(new DataWriter(await Broadcaster.GetOutputStreamAsync(
                new HostName(this._BroadcastAddress), port)));

            Broadcaster = (DatagramSocket) null;
          }
          catch (Exception ex)
          {
            this.RaiseError(new ErrorEventArgs(ErrorType.System, ex));
          }
          port = (string) null;
        }
        strArray = (string[]) null;
      }
      this.IsBroadcastSetup = true;
    }

    protected virtual async void _Listener_MessageReceived(
      DatagramSocket sender,
      DatagramSocketMessageReceivedEventArgs args)
    {
      try
      {
        string canonicalName = args.RemoteAddress.CanonicalName;
        DataReader dataReader = args.GetDataReader();
        string text = dataReader.ReadString(dataReader.UnconsumedBufferLength);
        await this.ProcessMessageReceived(canonicalName, text);
      }
      catch (Exception ex)
      {
        this.OnMessageReceivedError(new ErrorEventArgs(ErrorType.Unknown, ex));
      }
    }

    protected override async Task StartListen(bool allAdapters = false)
    {
      if (this.IsListening)
        return;
      this.Listeners = new List<DatagramSocket>();
      string[] strArray;
      int index;
      if (allAdapters)
      {
        foreach (string hn in this.HostNames)
        {
          strArray = this._ReceivingPorts;
          for (index = 0; index < strArray.Length; ++index)
          {
            string str = strArray[index];
            DatagramSocket ds = new DatagramSocket();
            DatagramSocket datagramSocket = ds;
            Func<TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>, EventRegistrationToken> 
                            addMethod = new Func<TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>, 
                            EventRegistrationToken>(datagramSocket.add_MessageReceived);

            Action<EventRegistrationToken> removeMethod = new Action<EventRegistrationToken>(
                datagramSocket.remove_MessageReceived);

            WindowsMessaging windowsMessaging = this;
            // ISSUE: virtual method pointer
            TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs> handler 
                            = new TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>((object) windowsMessaging, 
                __vmethodptr(windowsMessaging, _Listener_MessageReceived));

            WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>>(
                addMethod, removeMethod, handler);
            await ds.BindEndpointAsync(new HostName(hn), str);
            this.Listeners.Add(ds);
            ds = (DatagramSocket) null;
          }
          strArray = (string[]) null;
        }
      }
      else
      {
        strArray = this._ReceivingPorts;
        for (index = 0; index < strArray.Length; ++index)
        {
          string str = strArray[index];
          DatagramSocket datagramSocket1 = new DatagramSocket();
          DatagramSocket datagramSocket2 = datagramSocket1;
          Func<TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>, EventRegistrationToken> addMethod 
                        = new Func<TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>, 
                        EventRegistrationToken>(datagramSocket2.add_MessageReceived);
          Action<EventRegistrationToken> removeMethod = new Action<EventRegistrationToken>(
              datagramSocket2.remove_MessageReceived);

          WindowsMessaging windowsMessaging = this;

          // ISSUE: virtual method pointer
          TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs> handler 
                        = new TypedEventHandler<DatagramSocket, DatagramSocketMessageReceivedEventArgs>((object) windowsMessaging, 
              __vmethodptr(windowsMessaging, _Listener_MessageReceived));

          WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<DatagramSocket,
              DatagramSocketMessageReceivedEventArgs>>(addMethod, removeMethod, handler);
          this.Listeners.Add(datagramSocket1);
          await datagramSocket1.BindServiceNameAsync(str);
        }
        strArray = (string[]) null;
      }
      this.IsListening = true;
    }

    public override void CleanUp()
    {
      foreach (DataWriter writer in this._Writers)
        writer.Dispose();
      this.IsListening = false;
    }

    protected override async Task BroadCast(string message)
    {
      if (!this.IsBroadcastSetup)
        return;
      message += UdpMessaging._StringTerminator.ToString();
      foreach (DataWriter writer in this._Writers)
      {
        int num1 = (int) writer.WriteString(message);
        int num2 = (int) await (IAsyncOperation<uint>) writer.StoreAsync();
        int num3 = await writer.FlushAsync() ? 1 : 0;
        writer.DetachBuffer();
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Messaging;
using weekysoft.store.Chatting;
using weekysoft.store.Enums;
using weekysoft.store.Interfaces;
using Windows.Networking.Sockets;
using Windows.Networking;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace IGM.UI
{
    public class UWPMessaging : IMessaging
    {
        private string _SendingPort;
        private string[] _ReceivingPorts;
        private string _BroadcastAddress;
        private bool _IgnoreSelf;
        private string _Username;
        private IEnumerable<string> _HostNames;
        private string _Host;
        private Version _ProtocolVersion = new Version(1, 0);
        private DatagramSocket _Broadcaster;
        private List<DatagramSocket> _Listeners = new List<DatagramSocket>();

        public EventHandler<MessageEventArgs> MessageReceived { get; set; }
        public bool IsListening { get; private set; }
        public bool IsBroadcastSetup { get; private set; }
        public string Channel { get; set; }

        public EventHandler<MessageEventArgs> MessageValidating { get; set; }
        public EventHandler<MessageEventArgs> MessageValidated { get; set; }
        public EventHandler<MessageEventArgs> MessageConfirmed { get; set; }
        public EventHandler<MessageEventArgs> MessageFullyConfirmed { get; set; }
        public EventHandler<MessageEventArgs> MessageReconfirmed { get; set; }
        public EventHandler<MessageEventArgs> MessageLost { get; set; }
        public EventHandler<MessageEventArgs> ConfirmMessageLost { get; set; }
        public EventHandler<ErrorEventArgs> MessageReceivedError { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageAck { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageNak { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageSync { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageConfirm { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageText { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageReconfirm { get; set; }
        public EventHandler<MessageEventArgs> ReceivedMessageRequest { get; set; }
        public EventHandler<MessageEventArgs> ReceivingMessageConfirm { get; set; }
        public EventHandler<MessageEventArgs> ReceivingMessageText { get; set; }
        public EventHandler<MessageEventArgs> ReceivingMessageReconfirm { get; set; }
        public EventHandler<MessageEventArgs> ReceivingMessageRequest { get; set; }
        public EventHandler<MessageEventArgs> SiteMessageReceived { get; set; }

        public Version ProtocolVersion => _ProtocolVersion;

        public IEnumerable<string> IPAddresses => _HostNames;
        public IEnumerable<string> HostNames 
        { 
            get => _HostNames; 
            private set => _HostNames = value; 
        }
        public string Host => _Host;
        public string UserName 
        { 
            get => _Username; 
            set => _Username = value; 
        }

        public UWPMessaging(
            string sendingPort,
            string[] receivingPorts,
            string broadcastAddress = "255.255.255.255",
            bool ignoreSelf = true)
        {
            this._IgnoreSelf = ignoreSelf;
            this.IsListening = false;
            this.IsBroadcastSetup = false;
            this._SendingPort = sendingPort;
            this._ReceivingPorts = receivingPorts;
            this._BroadcastAddress = broadcastAddress;
            this.Channel = "0";
            
            // Initialize event handlers to avoid null reference exceptions
            this.ReceivedMessageSync += HandleReceivedMessageSync;
            this.MessageValidating += HandleMessageValidating;
        }

        private void HandleMessageValidating(object sender, MessageEventArgs e)
        {
            // Default implementation
        }

        private void HandleReceivedMessageSync(object sender, MessageEventArgs e)
        {
            // Default implementation
            Ack(e.Message.Header.RoomId).ConfigureAwait(false);
        }

        public async Task Initialize(IIPAddressManager ipaddress)
        {
            if (!DetectNetworkChanges(ipaddress))
                return;

            this.HostNames = ipaddress.GetIPAddresses();
            if (this.HostNames != null && this.HostNames.Count() > 0)
            {
                // Set the first IP address as the host
                this._Host = this.HostNames.First();
                this._Username = this._Host; // Use IP as username for now

                await SetupBroadcaster();
                await StartListen(true);
            }
            else
            {
                this._HostNames = new List<string> { "127.0.0.1" };
                this._Host = "127.0.0.1";
                this._Username = "localhost";
                // Don't raise error for now, just log it
                System.Diagnostics.Debug.WriteLine("No network available");
            }
        }

        private async Task SetupBroadcaster()
        {
            if (this.IsBroadcastSetup)
                return;

            try
            {
                _Broadcaster = new DatagramSocket();
                _Broadcaster.MessageReceived += OnMessageReceived;
                await _Broadcaster.BindServiceNameAsync(_SendingPort);
                IsBroadcastSetup = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting up broadcaster: {ex.Message}");
            }
        }

        private async Task StartListen(bool allAdapters = false)
        {
            if (this.IsListening)
                return;

            foreach (string port in _ReceivingPorts)
            {
                try
                {
                    DatagramSocket listener = new DatagramSocket();
                    listener.MessageReceived += OnMessageReceived;
                    await listener.BindServiceNameAsync(port);
                    _Listeners.Add(listener);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error starting listener on port {port}: {ex.Message}");
                }
            }

            IsListening = true;
        }

        private async void OnMessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            try
            {
                string message = string.Empty;
                using (DataReader reader = args.GetDataReader())
                {
                    uint bytesRead = reader.UnconsumedBufferLength;
                    if (bytesRead > 0)
                    {
                        byte[] data = new byte[bytesRead];
                        reader.ReadBytes(data);
                        message = Encoding.UTF8.GetString(data, 0, data.Length);
                    }
                }

                if (!string.IsNullOrEmpty(message))
                {
                    var messageEventArgs = new MessageEventArgs();
                    messageEventArgs.Sender = args.RemoteAddress.DisplayName;
                    messageEventArgs.Data = message;
                    
                    try
                    {
                        messageEventArgs.Message = new ChatMessage(message);
                        MessageReceived?.Invoke(this, messageEventArgs);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing message: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error receiving message: {ex.Message}");
            }
        }

        public async Task SendMessage(ChatMessage content)
        {
            // Check if the messaging system is properly initialized
            if (!IsBroadcastSetup || _Broadcaster == null)
            {
                System.Diagnostics.Debug.WriteLine("Messaging system not properly initialized. Cannot send message.");
                return;
            }

            try
            {
                using (var stream = await _Broadcaster.GetOutputStreamAsync(
                    new HostName(_BroadcastAddress), _SendingPort))
                {
                    using (DataWriter writer = new DataWriter(stream))
                    {
                        string messageString = content.BuildSendString(); // Use BuildSendString instead of ToString
                        byte[] data = Encoding.UTF8.GetBytes(messageString);
                        writer.WriteBytes(data);
                        await writer.StoreAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error sending message: {ex.Message}");
                // Re-throw the exception so it can be handled by the caller
                throw;
            }
        }

        public async Task Ack(string roomName)
        {
            // Implementation for acknowledgment
            System.Diagnostics.Debug.WriteLine($"Acknowledging room: {roomName}");
            // In a real implementation, you would send an acknowledgment message
        }

        public async Task Syn(string roomName)
        {
            // Implementation for synchronization
            System.Diagnostics.Debug.WriteLine($"Synchronizing room: {roomName}");
            // In a real implementation, you would send a synchronization message
        }

        public async Task Nak(string roomName)
        {
            // Implementation for negative acknowledgment
            System.Diagnostics.Debug.WriteLine($"Negative acknowledgment for room: {roomName}");
            // In a real implementation, you would send a negative acknowledgment message
        }

        public bool DetectNetworkChanges(IIPAddressManager ipaddress)
        {
            bool flag = this.HostNames == null;
            if (this.HostNames != null)
            {
                foreach (string ipAddress in ipaddress.GetIPAddresses())
                {
                    if (!this.HostNames.Contains(ipAddress))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                this.IsBroadcastSetup = false;
                this.IsListening = false;
            }
            return flag;
        }

        public void CleanUp()
        {
            try
            {
                foreach (var listener in _Listeners)
                {
                    listener.Dispose();
                }
                _Listeners.Clear();

                _Broadcaster?.Dispose();
                _Broadcaster = null;

                IsListening = false;
                IsBroadcastSetup = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        public async Task RaiseError(ErrorEventArgs e)
        {
            MessageReceivedError?.Invoke(this, e);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using weekysoft.store.ChatRoom;
using weekysoft.store.Chatting;
using weekysoft.store.Messaging;
using weekysoft.store.Storage;
using Windows.Media.SpeechSynthesis;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Coding4Fun.Toolkit.Controls;

namespace IGM.UI
{
    public sealed partial class ChatBubblePanel : UserControl, INotifyPropertyChanged
    {
        private ThreadPoolTimer _periodicTimer;
        private SpeechSynthesizer _speechSynthesizer;
        private bool _isSpeechEnabled;
        private bool _isAssistantEnabled;
        
        public ObservableCollection<ChatMessageViewModel> ChatMessages { get; } = new ObservableCollection<ChatMessageViewModel>();

        public bool IsSpeechEnabled
        {
            get => _isSpeechEnabled;
            set
            {
                _isSpeechEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsAssistantEnabled
        {
            get => _isAssistantEnabled;
            set
            {
                _isAssistantEnabled = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ChatBubblePanel()
        {
            InitializeComponent();
            DataContext = this;
            lvChat.ItemsSource = ChatMessages;
            InitializeChat();
        }

        private void InitializeChat()
        {
            try
            {
                _speechSynthesizer = new SpeechSynthesizer();
                
                // Set up periodic timer for chat synchronization
                _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(
                    PeerSyncElapsedHandler, 
                    TimeSpan.FromSeconds(Member.RenewTime));

                // Subscribe to messaging events
                if (ClientData.Current?.CurrentRoom?.ChatMessaging != null)
                {
                    ClientData.Current.CurrentRoom.ChatMessaging.MessageReceived += OnReceivedMessage; 
                    ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageAck += OnReceivedMessageAck;
                    ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageNak += OnReceivedMessageNak;
                    ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageSync += OnReceivedMessageSync;
                }

                // Set up event handlers
                send.Click += OnSendClick;
                tbSend.KeyDown += OnTextBoxKeyDown;
            }
            catch (Exception ex)
            {
                // Handle initialization errors gracefully
                System.Diagnostics.Debug.WriteLine($"ChatBubblePanel initialization error: {ex.Message}");
            }
        }

        private async void OnSendClick(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async void OnTextBoxKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                await SendMessage();
            }
        }

        private async System.Threading.Tasks.Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(tbSend.Text))
                return;

            try
            {
                string messageText = tbSend.Text.Trim();
                tbSend.Text = string.Empty;

                // Create and send the message
                var message = new ChatMessage(
                    ClientData.Current.ChatMessaging.ProtocolVersion, // Fixed: Use ChatMessaging.ProtocolVersion instead of ClientData.Current.ProtocolVersion
                    ClientData.Current.CurrentRoom.RoomId,
                    MessageType.Text, // Fixed: Use MessageType.Text instead of MessageType.Chat
                    ClientData.Current.MySelf.IPAddress,
                    ClientData.Current.MySelf.DisplayName,
                    DateTime.Now,
                    messageText
                );

                message.IsMyMessage = true;
                message.IsSending = true;

                // Add to UI
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    AddChatBubble(message);
                });

                // Send the message
                ClientData.Current.CurrentRoom.ChatMessaging.SendMessage(message); // Fixed: Use SendMessage instead of Send
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Send message error: {ex.Message}");
            }
        }

        private void AddChatBubble(ChatMessage message)
        {
            try
            {
                var chatMessageViewModel = new ChatMessageViewModel
                {
                    MessageText = message.Body,
                    SenderName = message.Header.Sender,
                    Timestamp = message.Header.DateTime, // Fixed: Use DateTime instead of Timestamp
                    IsFromMe = message.IsMyMessage,
                    ShowSenderName = !message.IsMyMessage // Show sender name for received messages
                };

                ChatMessages.Add(chatMessageViewModel);

                // Scroll to the bottom
                if (ChatMessages.Count > 0)
                {
                    lvChat.ScrollIntoView(ChatMessages.Last());
                }

                // Handle text-to-speech
                if (IsSpeechEnabled && !message.IsMyMessage)
                {
                    _ = SpeakMessageAsync(message.Body);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Add chat bubble error: {ex.Message}");
            }
        }

        private FrameworkElement CreateChatBubbleContent(ChatMessage message)
        {
            var textBlock = new TextBlock
            {
                Text = $"{message.Header.Sender}: {message.Body}",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5)
            };

            return textBlock;
        }

        private Brush GetBackgroundBrush(ChatMessage message)
        {
            if (message.IsMyMessage)
                return UISetting.Current.ChatBubbleMyBackground;
            return UISetting.Current.ChatBubblePeerBackground;
        }

        private Brush GetForegroundBrush(ChatMessage message)
        {
            if (message.IsMyMessage)
                return UISetting.Current.ChatBubbleMyForeground;
            return UISetting.Current.ChatBubblePeerForeground;
        }

        private async System.Threading.Tasks.Task SpeakMessageAsync(string text)
        {
            try
            {
                if (_speechSynthesizer != null && !string.IsNullOrEmpty(text))
                {
                    var stream = await _speechSynthesizer.SynthesizeTextToStreamAsync(text);
                    meChatVoice.SetSource(stream, stream.ContentType);
                    meChatVoice.Play();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Speech synthesis error: {ex.Message}");
            }
        }

        private async void OnReceivedMessage(object sender, MessageEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                try
                {
                    // Fixed: Create ChatMessage from e.Message.Body instead of e.Message.Content
                    var message = new ChatMessage(e.Message.Header.ProtocolVersion, 
                                                 e.Message.Header.RoomId,
                                                 e.Message.Header.MessageType,
                                                 e.Message.Header.SenderIP,
                                                 e.Message.Header.Sender,
                                                 e.Message.Header.DateTime,
                                                 e.Message.Body); // Use Body instead of Content
                    message.IsMyMessage = false;
                    AddChatBubble(message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Received message error: {ex.Message}");
                }
            });
        }

        private async void OnReceivedMessageAck(object sender, MessageEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Handle message acknowledgment
                UIBinder.Current.CreateConfirmLine(lvChat)?.Invoke(e.Message.Header.OriginalMessageId);
            });
        }

        private async void OnReceivedMessageNak(object sender, MessageEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Handle message negative acknowledgment
                UIBinder.Current.CreateLostLine(lvChat)?.Invoke(e.Message.Header.OriginalMessageId);
            });
        }

        private async void OnReceivedMessageSync(object sender, MessageEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Handle message synchronization

            });
        }

        private void PeerSyncElapsedHandler(ThreadPoolTimer timer)
        {
            try
            {
                if (ClientData.Current?.ChatMessaging?.IsBroadcastSetup == true)
                {
                    ClientData.Current.ChatMessaging.Ack(ClientData.Current.CurrentRoom.RoomId);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Peer sync error: {ex.Message}");
            }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Cleanup when control is unloaded
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _periodicTimer?.Cancel();
                _speechSynthesizer?.Dispose();

                if (ClientData.Current?.CurrentRoom?.ChatMessaging != null)
                {
                    ClientData.Current.CurrentRoom.ChatMessaging.MessageReceived -= OnReceivedMessage; // Fixed: Use MessageReceived instead of ReceivedMessage
                    ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageAck -= OnReceivedMessageAck;
                    ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageNak -= OnReceivedMessageNak;
                    ClientData.Current.CurrentRoom.ChatMessaging.ReceivedMessageSync -= OnReceivedMessageSync;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Cleanup error: {ex.Message}");
            }
        }
    }

    // ViewModel for Chat Messages
    public class ChatMessageViewModel : INotifyPropertyChanged
    {
        private string _messageText;
        private string _senderName;
        private DateTime _timestamp;
        private bool _isFromMe;
        private bool _showSenderName;

        public string MessageText
        {
            get => _messageText;
            set
            {
                _messageText = value;
                OnPropertyChanged();
            }
        }

        public string SenderName
        {
            get => _senderName;
            set
            {
                _senderName = value;
                OnPropertyChanged();
            }
        }

        public DateTime Timestamp
        {
            get => _timestamp;
            set
            {
                _timestamp = value;
                OnPropertyChanged();
            }
        }

        public bool IsFromMe
        {
            get => _isFromMe;
            set
            {
                _isFromMe = value;
                OnPropertyChanged();
            }
        }

        public bool ShowSenderName
        {
            get => _showSenderName;
            set
            {
                _showSenderName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

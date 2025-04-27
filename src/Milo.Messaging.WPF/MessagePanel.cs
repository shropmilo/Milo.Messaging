using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Milo.Core.Messaging;

namespace Milo.Messaging.WPF
{
    /// <summary>
    ///Pass in a <see cref="IMiloMessageService"/> and all messages are displayed
    /// </summary>
    public class MessagePanel : Control
    {
        public static readonly DependencyProperty MessageServiceProperty = DependencyProperty.Register(
            nameof(MessageService), typeof(IMiloMessageService), typeof(MessagePanel), new PropertyMetadata(null, propertyChangedCallback:OnMessageServiceChanged));

        public IMiloMessageService MessageService
        {
            get => (IMiloMessageService)GetValue(MessageServiceProperty);
            set => SetValue(MessageServiceProperty, value);
        }

        public ObservableCollection<IMiloMessage> Messages { get; } = new();

        static MessagePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessagePanel), new FrameworkPropertyMetadata(typeof(MessagePanel)));
        }

        private static void OnMessageServiceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MessagePanel panel)
            {
                panel.OnMessageServiceChanged(e.OldValue as IMiloMessageService, e.NewValue as IMiloMessageService);
            }
        }

        private void OnMessageServiceChanged(IMiloMessageService? oldService, IMiloMessageService? newService)
        {
            if (oldService != null)
            {
                oldService.MessageSent -= OnMessageSent;
            }

            if (newService != null)
            {
                newService.MessageSent += OnMessageSent;
            }
        }

        private void OnMessageSent(object? sender, MessageEventArgs e)
        {
            Messages.Add(e.Message);
        }
    }
}
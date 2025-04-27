using System.Windows;
using System.Windows.Controls;

namespace Milo.Messaging.WPF
{
    /// <summary>
    ///
    /// </summary>
    public class MessagePanel : Control
    {
        static MessagePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessagePanel), new FrameworkPropertyMetadata(typeof(MessagePanel)));
        }
    }
}
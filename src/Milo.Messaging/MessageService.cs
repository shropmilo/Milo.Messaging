using Milo.Core.Messaging;

namespace Milo.Messaging
{
    internal class MessageService : IMiloMessageService
    {
        public void Start()
        {
           
        }

        public void Stop()
        {
            
        }

        public event EventHandler<MessageEventArgs>? MessageSent;

        public bool Send(IMiloMessage message)
        {
            if (MessageSent != null)
            {
                MessageSent.Invoke(this, new MessageEventArgs(message));

                return true;
            }

            return false;
        }
    }
}

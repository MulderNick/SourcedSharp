using System;
using System.Collections.Generic;
using System.Reflection;

namespace SourcedSharp.Core.Messages
{
    public class MessageHandler
    {
        private Dictionary<Type, MethodInfo> Handlers = new Dictionary<Type, MethodInfo>();

        protected void HandleMessages(IEnumerable<IMessage> messages)
        {
            foreach (var message in messages)
            {
                HandleMessage(message);
            }
        }

        protected void HandleMessage(IMessage message)
        {
            var messageType = message.GetType();
            var isHandlerAvailable = Handlers.TryGetValue(messageType, out var messageHandler);

            if (isHandlerAvailable)
            {
                messageHandler.Invoke(this, new[] { message });
            }
        }

        protected void Subscribe()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using SourcedSharp.Core.Messages;

namespace SourcedSharp.Core.MessageBroker
{
    public class MessageBroker : IMessageBroker
    {
        public void EmitMessage(IMessage message)
        {
            throw new NotImplementedException();
        }

        public void EnqueueMessage(IMessage message)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Type messageType)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(IEnumerable<Type> messageTypes)
        {
            throw new NotImplementedException();
        }
    }
}
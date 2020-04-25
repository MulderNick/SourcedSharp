using System;
using System.Collections.Generic;
using SourcedSharp.Messages;

namespace SourcedSharp.MessageBus
{
    /*
     * A message bus is responsible for making messages available to listeners
     *
     * ToDo: Define "Messages"
     */
    public interface IMessageBroker
    {
        // Emited messages behave as a bus where every listeners has their own queue
        void EmitMessage(IMessage message);
        // Enqueued messages behave as a queue where every type of handler has their own queue
        void EnqueueMessage(IMessage message);
        void Subscribe(Type messageTypes);
        void Subscribe(IEnumerable<Type> messageTypes);
    }
}
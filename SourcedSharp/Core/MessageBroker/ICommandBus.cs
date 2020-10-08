using System;
using System.Collections.Generic;
using SourcedSharp.Core.Messages.Commands;

namespace SourcedSharp.Core.MessageBroker
{
    public interface ICommandBus
    {
        // Enqueued messages behave as a queue where every type of handler has their own queue
        void EnqueueMessage(ICommand command);
        void Subscribe(Type commandType);
        void Subscribe(IEnumerable<Type> commandTypes);
    }
}
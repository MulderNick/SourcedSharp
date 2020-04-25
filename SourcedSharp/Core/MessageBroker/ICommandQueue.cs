using System;
using System.Collections.Generic;
using SourcedSharp.Commands;
using SourcedSharp.Messages;

namespace SourcedSharp.MessageBus
{
    public interface ICommandQueue
    {
        // Enqueued messages behave as a queue where every type of handler has their own queue
        void EnqueueMessage(ICommand command);
        void Subscribe(Type commandType);
        void Subscribe(IEnumerable<Type> commandTypes);
    }
}
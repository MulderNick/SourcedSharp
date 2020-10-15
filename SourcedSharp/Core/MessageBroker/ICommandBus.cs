using System;
using System.Collections.Generic;
using SourcedSharp.Core.Messages.Commands;

namespace SourcedSharp.Core.MessageBroker
{
    public interface ICommandBus
    {
        public void ExecuteCommand(ICommand command);
        public void RegisterHandlerFor<TCommand>(Type handlerType);
    }
}
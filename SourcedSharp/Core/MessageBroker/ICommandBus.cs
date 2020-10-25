using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SourcedSharp.Core.Messages.Commands;

namespace SourcedSharp.Core.MessageBroker
{
    public interface ICommandBus
    {
        public Task ExecuteCommand(ICommand command);
        public void RegisterHandlerFor<TCommand>(Type handlerType);
    }
}
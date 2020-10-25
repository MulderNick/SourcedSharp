using SourcedSharp.Core.Aggregates;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Commands;
using SourcedSharp.Core.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SourcedSharp.Core.MessageHandling;

namespace SourcedSharp.Core.MessageBroker
{
    // ToDo: handlers should be stored in solution, not command bus
    public class CommandBus : ICommandBus
    {
        private IDictionary<Type, Type> _handlers = new Dictionary<Type, Type>();
        private IEventStore EventStore;

        public CommandBus(IEventStore eventStore)
        {
            EventStore = eventStore;
        }

        public async Task ExecuteCommand(ICommand command)
        {
            await HandleCommand(command);
            return;
        }
        private async Task HandleCommand(ICommand command)
        {
            var processOperator = new ProcessOperator(EventStore);

            // When commiting check projections for changes
            // when handling an aggregate its easy.
            // when handling a process we don't have a view on the aggregate itself. Should we mount all aggregates somehow in the process manager?
            var commandType = command.GetType();
            var handlerRegistered = _handlers.TryGetValue(commandType, out Type aggregate );
            if (handlerRegistered) {
                var res = await processOperator.With(aggregate).Handle(command);
                await processOperator.Commit();
            }
        }

        // ToDo: Put handler registration to solution, commandbus is just a user of the registrations
        public void RegisterHandlerFor<TCommand>(Type handlerType)
        {
            _handlers.Add(typeof(TCommand), handlerType);
        }

    }
}
using SourcedSharp.Core.Aggregates;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Commands;
using SourcedSharp.Core.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SourcedSharp.Core.MessageBroker
{
    public class CommandBus : ICommandBus
    {
        private object QueueAdapter;

        private IDictionary<Type, Type> _handlers = new Dictionary<Type, Type>();
        private IEventStore EventStore;

        public CommandBus(IEventStore eventStore)
        {
            EventStore = eventStore;
        }


        public void ExecuteCommand(ICommand command)
        {
            HandleCommand(command);
        }
        private void HandleCommand(ICommand command)
        {
            var processOperator = new ProcessOperator(EventStore);

            // When commiting check projections for changes
            // when handling an aggregate its easy.
            // when handling a process we don't have a view on the aggregate itself. Should we mount all aggregates somehow in the process manager?
            var commandType = command.GetType();
            var handlerRegistered = _handlers.TryGetValue(commandType, out Type aggregate );
            if (handlerRegistered) {
                processOperator.With(aggregate).Handle(command);
                processOperator.Commit();
            }
        }

        // ToDo: Put handler registration to solution, commandbus is just a user of the registrations
        public void RegisterHandlerFor<TCommand>(Type handlerType)
        {
            _handlers.Add(typeof(TCommand), handlerType);
        }

    }

    public class ProcessOperator
    {
        public Dictionary<Type, AggregateOperator> AggregateOperators = new Dictionary<Type, AggregateOperator>();
        public IEventStore EventStore;
        public IEnumerable<IEvent> Events
        {
            get => AggregateOperators.Values.Select(ao => ao.Event).ToList();
        }

        public ProcessOperator(IEventStore eventStore)
        {
            EventStore = eventStore;
        }

        public AggregateOperator With(Type aggregateType)
        {
            var aggregateOperator = new AggregateOperator(aggregateType);
            AggregateOperators.Add(aggregateType, aggregateOperator);
            return aggregateOperator;
        }

        public void Commit()
        {
            EventStore.Commit(Events);
        }
    }

    // ToDo: put handle string in parent class as it is reused
    public class AggregateOperator
    {
        public Type AggregateType;
        public IAggregate Aggregate;
        public IEvent Event;

        public AggregateOperator(Type aggregateType)
        {
            AggregateType = aggregateType;
            Aggregate = (IAggregate)Activator.CreateInstance(aggregateType);
        }
        public IEvent Handle(ICommand command)
        {
            var method = AggregateType.GetMethods().First(m =>
                m.Name.Equals("Handle") &&
                m.GetParameters().Length == 1 &&
                m.GetParameters().Count(p => p.ParameterType.IsEquivalentTo(command.GetType())) == 1);
            Event = method.Invoke(Aggregate, new[] {command}) as IEvent;
            return Event;
        }
    }
}
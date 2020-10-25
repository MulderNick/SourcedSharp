using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.MessageHandling
{
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

        public async Task Commit()
        {

            await EventStore.Commit(Events);
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using SourcedSharp.Core.Aggregates;
using SourcedSharp.Core.Messages.Commands;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.MessageHandling
{
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
        public async Task<IEvent> Handle(ICommand command)
        {
            var method = AggregateType.GetMethods().First(m =>
                m.Name.Equals("Handle") &&
                m.GetParameters().Length == 1 &&
                m.GetParameters().Count(p => p.ParameterType.IsEquivalentTo(command.GetType())) == 1);
            dynamic task = method.Invoke(Aggregate, new[] { command });
            Event = await task;
            SetEventMetaData();
            return Event;
        }

        private void SetEventMetaData()
        {
            Event.MetaData.CreationDateTime = DateTime.UnixEpoch;
            Event.MetaData.EventTypeId = Guid.Empty;
            Event.MetaData.CorrelationId = Guid.Empty;
            Event.MetaData.AggregateId = Aggregate.AggregateId;
            Event.MetaData.AggregateVersion = Aggregate.AggregateVersion;
        }
    }
}
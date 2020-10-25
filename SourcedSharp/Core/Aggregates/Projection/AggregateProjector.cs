using System;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;
using SourcedSharp.Core.Projections;
using SourcedSharp.Core.Projections.SnapshotStore;

namespace SourcedSharp.Core.Aggregates.Projection
{
    public class AggregateProjector<TProjection> : SnapshotProjector<TProjection>, IAggregateProjector where TProjection : IAggregateProjection
    {
        IAggregateProjection IAggregateProjector.Projection
        {
            get => Projection;
            set => Projection = (TProjection)value;
        }
        public AggregateProjector(Guid aggregateId, IEventStore eventStore, ISnapshotStore projectionStore) : base(aggregateId, eventStore, projectionStore)
        {

        }
        public override void ApplyEvent(IEvent @event)
        {
            base.ApplyEvent(@event);
            IncreaseAggregateId(@event);
        }

        private void IncreaseAggregateId(IEvent @event)
        {
            Projection.LastHandledAggregateEvent = @event;
            if (@event.MetaData.AggregateVersion != EventHandler.NumberOfEventsHandled - 1)
            {
                throw new Exception("Aggregate Events-Versioning out of order");
            }
            Projection.AggregateVersion = @event.MetaData.AggregateVersion + 1;
        }
    }
}
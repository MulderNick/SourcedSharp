using System;
using System.Collections.Generic;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.Aggregates.Projection;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;
using SourcedSharp.Core.Projections;
using SourcedSharp.Core.Projections.SnapshotStore;

namespace EntityTestApplication.Entity.Entities.State
{
    public class EntitiesProjector : AggregateProjector<EntitiesProjection>,
        IApply<EntityCreated>,
        IApply<EntityDeleted>, IAggregateProjector
    {
        public EntitiesProjector(Guid aggregateId, IEventStore eventStore, ISnapshotStore projectionStore) : base(aggregateId, eventStore, projectionStore)
        {
        }

        public void Apply(EntityCreated @event)
        {
            Projection.Entities.Add(@event.Id, new Entity(@event.Id, @event.Name));
        }
        public void Apply(EntityDeleted @event)
        {
            Projection.Entities.Remove(@event.Id);
        }
    }
}
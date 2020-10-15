using System;
using System.Collections.Generic;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;
using SourcedSharp.Core.Projections;

namespace EntityTestApplication.Entity.Entities.State
{
    public class EntitiesProjector : InMemoryProjector<EntitiesProjection>,
        IApply<EntityCreated>,
        IApply<EntityDeleted>
    {
        public EntitiesProjector(Guid projectionId, IEventStore eventStore) : base(projectionId, eventStore)
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
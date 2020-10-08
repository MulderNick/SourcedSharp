using System;
using System.Collections.Generic;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.Messages.Events;
using SourcedSharp.Core.Projections;

namespace EntityTestApplication.Entity.Entities.AggregateComponents.State
{
    public class EntitiesProjector : InMemoryProjector<EntitiesProjection>,
        IApply<EntityCreated>,
        IApply<EntityDeleted>
    {
        public EntitiesProjector(Guid projectionId) : base(projectionId)
        {
            var events = new List<IEvent>()
            {
                new EntityCreated(Guid.NewGuid(), "name")
            };
            ApplyEvents(events);
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
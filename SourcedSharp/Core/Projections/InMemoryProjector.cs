using System;
using System.Collections.Generic;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Projections
{
    public class InMemoryProjector<TProjection> : Projector<TProjection> where TProjection : IProjection
    {
        
        public InMemoryProjector(Guid projectionId, IEventStore eventStore) : base(projectionId, eventStore)
        {
            Rehydrate();
        }

        private void Rehydrate()
        {
            var events = EventStore.GetEvents();
            ApplyEvents(events);
        }
    }
}
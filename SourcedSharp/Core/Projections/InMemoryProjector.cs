using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RabbitMQ.Client;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Projections
{
    public class InMemoryProjector<TProjection> : Projector<TProjection> where TProjection : IProjection
    {
        
        public InMemoryProjector(Guid projectionId, IEventStore eventStore) : base(projectionId, eventStore)
        {
        }

        public override async Task Initialize()
        {
            await Rehydrate();
        }

        public static async Task<InMemoryProjector<TProjection>> CreateAsync(Guid projectionId, IEventStore eventStore)
        {
            var projector = new InMemoryProjector<TProjection>(projectionId, eventStore);
            await projector.Initialize();
            return projector;
        }

        private async Task Rehydrate()
        {
            var events = await EventStore.GetEvents();
            ApplyEvents(events);
        }
    }
}
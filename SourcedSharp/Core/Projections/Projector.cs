using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;
using MountedEventHandler = SourcedSharp.Core.Messages.Events.MountedEventHandler;


namespace SourcedSharp.Core.Projections
{
    public abstract class Projector<TProjection> : IProjector, IEventHandler
        where TProjection : IProjection
    {
        public Guid ProjectionId { get; set; }
        protected MountedEventHandler EventHandler;

        // ToDo: see if this solution for interface typecasting will cause problems, other solution it to make the interface generic, ut this will cause other challenges in inheritance
        // Could this cause runtime errors?
        public TProjection Projection { get; set; }
        IProjection IProjector.Projection
        {
            get => Projection;
            set => Projection = (TProjection)value;
        }

        public IEventStore EventStore;

        public Projector(Guid projectionId, IEventStore eventStore)
        {
            EventHandler = new MountedEventHandler(this);
            ProjectionId = projectionId;
            EventStore = eventStore;
            Projection = CreateProjection();
        }

        public abstract Task Initialize();

        private TProjection CreateProjection()
        {
            return (TProjection)Activator.CreateInstance(typeof(TProjection), ProjectionId);
        }

        public virtual void ApplyEvents(IEnumerable<IEvent> events)
        {
            EventHandler.ApplyEvents(events);
        }

        public virtual void ApplyEvent(IEvent @event)
        {
            EventHandler.ApplyEvent(@event);
            Projection.NumberOfEventsHandled = EventHandler.NumberOfEventsHandled;
            Projection.LastHandledEvent = EventHandler.LastHandledEvent;
        }
    }
}

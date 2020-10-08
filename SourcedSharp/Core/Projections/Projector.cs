using System;
using SourcedSharp.Core.EventStore;
using EventHandler = SourcedSharp.Core.Messages.Events.EventHandler;


namespace SourcedSharp.Core.Projections
{
    public class Projector<TProjection> : EventHandler, IProjector
        where TProjection : IProjection
    {
        public Guid ProjectionId { get; set; }

        // ToDo: see if this solution for interface typecasting will cause problems, other solution it to make the interface generic, ut this will cause other challenges in inheritance
        // Could this cause runtime errors?
        public TProjection Projection { get; set; }
        IProjection IProjector.Projection
        {
            get => Projection;
            set => Projection = (TProjection)value;
        }

        public IEventStore EventsStore;

        public Projector(Guid projectionId)
        {
            ProjectionId = projectionId;
            Projection = CreateProjection();
        }

        private TProjection CreateProjection()
        {
            return (TProjection)Activator.CreateInstance(typeof(TProjection), ProjectionId);
        }
    }
}

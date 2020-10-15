using System;
using SourcedSharp.Core.EventStore;

namespace SourcedSharp.Core.Projections
{
    public class SnapshotProjector<TProjection> : Projector<TProjection> where TProjection : IProjection
    {
        public SnapshotProjector(Guid projectionId, IEventStore eventStore, object snapshotStore) : base(projectionId, eventStore)
        {
            LoadCachedProjection();
            ApplyNewEvents();
        }

        public void LoadCachedProjection()
        {

        }

        public void ApplyNewEvents()
        {
        }
    }
}
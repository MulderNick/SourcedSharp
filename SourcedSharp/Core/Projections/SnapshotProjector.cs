using System;
using System.Threading.Tasks;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Projections.SnapshotStore;

namespace SourcedSharp.Core.Projections
{
    public class SnapshotProjector<TProjection> : Projector<TProjection> where TProjection : IProjection
    {
        private ISnapshotStore _snapshotStore;
        public SnapshotProjector(Guid projectionId, IEventStore eventStore, ISnapshotStore snapshotStore) : base(projectionId, eventStore)
        {
            _snapshotStore = snapshotStore;
        }

        public override async Task Initialize()
        {
            await LoadCachedProjection();
            await ApplyNewEvents();
        }

        public async Task LoadCachedProjection()
        {
            if (_snapshotStore == null)
            {
                return;
            }

            var loadedProjection = await _snapshotStore.GetSnapshot<TProjection>(ProjectionId);
            if (loadedProjection != null)
            {
                Projection = loadedProjection;
            }
        }

        public async Task ApplyNewEvents()
        {
            var events = await EventStore.GetEvents();
            ApplyEvents(events);
        }
    }
}
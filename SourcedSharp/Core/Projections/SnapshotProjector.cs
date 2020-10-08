using System;

namespace SourcedSharp.Core.Projections
{
    public class SnapshotProjector<TProjection> : Projector<TProjection> where TProjection : IProjection
    {
        public SnapshotProjector(Guid projectionId) : base(projectionId)
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
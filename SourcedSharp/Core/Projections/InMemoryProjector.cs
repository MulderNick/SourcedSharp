using System;
using System.Collections.Generic;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Projections
{
    public class InMemoryProjector<TProjection> : Projector<TProjection> where TProjection : IProjection
    {
        public InMemoryProjector(Guid projectionId) : base(projectionId)
        {
            LoadProjectionFromCache();
            ApplyNewEvents();
        }

        private void ApplyNewEvents()
        {
        }

        private void LoadProjectionFromCache()
        {

        }
    }
}
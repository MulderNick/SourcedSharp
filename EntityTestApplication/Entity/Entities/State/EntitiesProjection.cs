using System;
using System.Collections.Generic;
using SourcedSharp.Core.Aggregates.Projection;
using SourcedSharp.Core.Projections;

namespace EntityTestApplication.Entity.Entities.State
{
    public class EntitiesProjection : AggregateProjection, IProjection
    {
        public Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>();

        public EntitiesProjection()
        {
            Id = Guid.NewGuid();
        }
        public EntitiesProjection(Guid id)
        {
            Id = id;
        }
    }
}
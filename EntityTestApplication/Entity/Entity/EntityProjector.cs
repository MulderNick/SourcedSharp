using System;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.Projections;

namespace EntityTestApplication.Entity.Entity
{
    public class EntityProjector : SnapshotProjector<EntityProjection>, 
        IApply<EntityCreated>,
        IApply<AttributeRemovedFromEntity>,
        IApply<AttributeSetOnEntity>
    {
        public EntityProjector(Guid projectionId) : base(projectionId)
        {
        }

        public void Apply(EntityCreated @event)
        {
            throw new System.NotImplementedException();
        }

        public void Apply(AttributeRemovedFromEntity @event)
        {
            throw new System.NotImplementedException();
        }

        public void Apply(AttributeSetOnEntity @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using SourcedSharp.Projections;
using SourcedSharp.Testing.FunctionalTests.Domain.Projections.models;

namespace SourcedSharp.Testing.FunctionalTests.Domain.Projections
{
    public class EntitiesProjection : IProjection
    {
        public Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>();
        public int NumberOfEventsHandled { get; set; }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity.Id, entity);
        }

        public Entity GetEntity(Guid entityId)
        {
            Entities.TryGetValue(entityId, out var entity);
            return entity;
        }

        public Boolean DeleteEntity(Guid entityId)
        {
            return Entities.Remove(entityId);
        }

        public bool ContainsEntity(Guid entityId)
        {
            return Entities.ContainsKey(entityId);
        }
    }


    public class EntityNameProjection : IProjection
    {
        public Dictionary<Guid, Entity> names = new Dictionary<Guid, Entity>();

    }
}
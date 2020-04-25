using System;
using SourcedSharp.Testing.FunctionalTests.Domain.Projections;
using SourcedSharp.Testing.FunctionalTests.Public.Commands;
using SourcedSharp.Testing.FunctionalTests.Public.Events;

namespace SourcedSharp.Testing.FunctionalTests.Domain
{
    public class EntityAggregate
    {
        private readonly EntitiesProjection _entitiesProjection;

        public EntityAggregate(EntitiesProjection entitiesProjection)
        {
            _entitiesProjection = entitiesProjection;
        }

        public EntityCreated CreateEntity(Guid id, string name)
        {
            return new EntityCreated(id, name);
        }

        public EntityRenamed RenameEntity(Guid id, string name)
        {
            return new EntityRenamed(id, name);
        }

        public EntityDeleted DeleteEntity(Guid id)
        {
            return new EntityDeleted(id);
        }
    }
}
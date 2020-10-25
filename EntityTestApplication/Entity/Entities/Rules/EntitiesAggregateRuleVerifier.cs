using System;
using System.Linq;
using EntityTestApplication.Entity.Entities.State;
using SourcedSharp.Core.Aggregates;
using SourcedSharp.Core.Exceptions;

namespace EntityTestApplication.Entity.Entities.Rules
{
    public class EntitiesAggregateRuleVerifier : AggregateRuleVerifier<EntitiesProjection>
    {
        public EntitiesAggregateRuleVerifier(EntitiesProjection projection) : base(projection)
        {
        }

        public void EntityNameIsUnique(string name)
        {
            var entityNameIsUnique = State.Entities.Count(e => e.Value.Name == name) == 0;
            if (!entityNameIsUnique)
            {
                throw new EntityNameNotUniqueException(name);
            }
        }

        public void EntityExists(Guid entityId)
        {
            var entityExists = State.Entities.ContainsKey(entityId);
            if (!entityExists)
            {
                throw new EntityNotFoundException(entityId);
            }
        }
    }


    public class EntityNameNotUniqueException : DomainException
    {
        public EntityNameNotUniqueException(string name) : base($"An entity with name:{name} already exists")
        {

        }
    }
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(Guid id) : base($"Entity with id:{id} could not be found")
        {

        }
    }
}
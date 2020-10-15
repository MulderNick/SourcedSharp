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
                throw new EntityNameNotUniqueException();
            }
        }

        public void EntityExists(Guid entityId)
        {
            var entityExists = State.Entities.ContainsKey(entityId);
            if (!entityExists)
            {
                throw new EntityNotFoundException();
            }
        }
    }


    public class EntityNameNotUniqueException : DomainException
    {

    }
    public class EntityNotFoundException : DomainException
    {

    }
}
using System.Linq;
using EntityTestApplication.Entity.Entities.AggregateComponents.State;
using SourcedSharp.Core.Aggregates;
using SourcedSharp.Core.Exceptions;

namespace EntityTestApplication.Entity.Entities.AggregateComponents
{
    public class EntitiesAggregateRuleVerifier : AggregateRuleVerifier
    {
        public EntitiesProjection State;

        public void EntityNameIsUnique(string name)
        {
            var entityNameIsUnique = State.Entities.Count(e => e.Value.Name == name) == 0;
            if (!entityNameIsUnique)
            {
                throw new EntityNameNotUniqueException();
            }
        }
    }


    public class EntityNameNotUniqueException : DomainException
    {

    }
}
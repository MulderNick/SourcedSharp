using System;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using EntityTestApplication.Entity.Entities.AggregateComponents;
using EntityTestApplication.Entity.Entities.AggregateComponents.State;
using EntityTestApplication.Entity.Public.Commands;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.Aggregates;

namespace EntityTestApplication.Entity.Entities
{
    public class EntitiesAggregate : Aggregate<EntitiesProjector, EntitiesAggregateRuleVerifier>
    {
        public EntitiesAggregate(Guid aggregateId) : base(aggregateId)
        {
        }

        public EntityCreated Handle(CreateEntity command)
        {
            Verify.EntityNameIsUnique(command.Name);
            return new EntityCreated(command.Id, command.Name);
        }

        public EntityDeleted Handle(DeleteEntity command)
        {
            // Check rules
            var @event = new EntityDeleted(command.Id);
            return @event;
        }
    }
}
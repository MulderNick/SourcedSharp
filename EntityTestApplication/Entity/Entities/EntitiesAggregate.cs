using EntityTestApplication.Entity.Entities.Rules;
using EntityTestApplication.Entity.Entities.State;
using EntityTestApplication.Entity.Public.Commands;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.Aggregates;

namespace EntityTestApplication.Entity.Entities
{
    public class EntitiesAggregate : Aggregate<EntitiesProjector, EntitiesAggregateRuleVerifier>
    {
        public EntityCreated Handle(CreateEntity command)
        {
            HandleCommandFor(command.EntityId);
            Verify.EntityNameIsUnique(command.Name);
            return new EntityCreated(command.EntityId, command.Name);
        }

        public EntityDeleted Handle(DeleteEntity command)
        {
            HandleCommandFor(command.EntityId);
            Verify.EntityExists(command.EntityId);
            var @event = new EntityDeleted(command.EntityId);
            return @event;
        }
    }
}
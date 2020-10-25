using System.Threading.Tasks;
using EntityTestApplication.Entity.Entities.Rules;
using EntityTestApplication.Entity.Entities.State;
using EntityTestApplication.Entity.Public.Commands;
using EntityTestApplication.Entity.Public.Events;
using SourcedSharp.Core.Aggregates;

namespace EntityTestApplication.Entity.Entities
{
    public class EntitiesAggregate : Aggregate<EntitiesProjector, EntitiesAggregateRuleVerifier>
    {
        public async Task<EntityCreated> Handle(CreateEntity command)
        {
            await HandleCommandFor(command.EntityId);
            Verify.EntityNameIsUnique(command.Name);
            var events = new EntityCreated(command.EntityId, command.Name);
            return events;
        }

        public async Task<EntityDeleted> Handle(DeleteEntity command)
        {
            await HandleCommandFor(command.EntityId);
            Verify.EntityExists(command.EntityId);
            return new EntityDeleted(command.EntityId);
        }
    }
}
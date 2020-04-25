using System.Collections.Generic;
using SourcedSharp.Commands;
using SourcedSharp.Events;
using SourcedSharp.Messages;
using SourcedSharp.Testing.FunctionalTests.Domain.Projections;
using SourcedSharp.Testing.FunctionalTests.Public.Commands;

namespace SourcedSharp.Testing.FunctionalTests.Domain
{
    public class EntityCommandHandler : ICommandHandler,
        IHandleCommand<CreateEntity>,
        IHandleCommand<RenameEntity>,
        IHandleCommand<DeleteEntity>
    {
        // ToDo: check if/why an aggregate should be given a state instead of creating its own
        private EntityAggregate _entityAggregate = new EntityAggregate(new EntitiesProjection());
        public void Handle(CreateEntity message)
        {
            var @event = _entityAggregate.CreateEntity(message.Id, message.Name);
            var eventStore = new Core.EventStore();
            eventStore.TryCommitEvent(new EntitiesProjector(new EntitiesProjection(), @event))
        }

        public void Handle(RenameEntity message)
        {
            var @event = _entityAggregate.RenameEntity(message.Id, message.Name);
        }

        public void Handle(DeleteEntity message)
        {
            var @event = _entityAggregate.DeleteEntity(message.Id);
        }

        public void HandleProcess(DeleteEntity message)
        {
            var events = new List<IEvent>();
        }
    }
}
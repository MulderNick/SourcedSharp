using SourcedSharp.Messages;
using SourcedSharp.Projections;
using SourcedSharp.Testing.FunctionalTests.Domain.Projections.models;
using SourcedSharp.Testing.FunctionalTests.Public.Events;

namespace SourcedSharp.Testing.FunctionalTests.Domain.Projections
{
    /*
     * ToDo: A projection should handle requirements where as a projection handles mutations
     */
    public class EntitiesProjector : IProjector, 
        IHandleEvent<EntityCreated>,
        IHandleEvent<EntityRenamed>,
        IHandleEvent<EntityDeleted>
    {
        // ToDo: auto count on effective event 
        public EntitiesProjection EntitiesProjection = new EntitiesProjection();
        public int NumberOfEventsHandled
        {
            get => EntitiesProjection.NumberOfEventsHandled;
            // ToDo setting this from outside is ugly, a projection should know it own state.
            set => EntitiesProjection.NumberOfEventsHandled = value;
        }

        public EntitiesProjector(EntitiesProjection projection = null)
        {
            EntitiesProjection = projection;
        }

        public void Handle(EntityCreated @event)
        {
            NumberOfEventsHandled++;
            EntitiesProjection.AddEntity(new Entity(@event.Id, @event.Name));
        }

        public void Handle(EntityRenamed @event)
        {
            NumberOfEventsHandled++;
            var entity = EntitiesProjection.GetEntity(@event.Id);
            entity.Name = @event.Name;
        }

        public void Handle(EntityDeleted @event)
        {
            NumberOfEventsHandled++;
            EntitiesProjection.DeleteEntity(@event.Id);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;
using SourcedSharp.Core.Projections;

namespace SourcedSharp.Testing.FunctionalTests.Core
{
    public class EventStore : IEventStore
    {
        private IEventRepository _eventRepository = new EventRepository();

        // ToDo: EventRepo should be fast and might need middleware like elastic search or redis
        public IEnumerable<IEvent> GetEventsForProjector(IProjector projector)
        {
            var events = _eventRepository.GetEvents();
            return events;
        }

        public bool TryCommitEvent(IProjector projector, IEvent @event)
        {
            if (GetEventsForProjector(projector).Count() == projector.NumberOfEventsHandled)
            {
                return _eventRepository.AddEvent(@event);
            }

            return false;
        }
    }
}          
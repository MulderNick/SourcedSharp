using System.Collections.Generic;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.EventStore
{
    public class EventStore : IEventStore
    {
        public object EventRepository;

        public List<IEvent> TempEvents = new List<IEvent>();

        public void Commit(IEnumerable<IEvent> events)
        {
            TempEvents.AddRange(events);
        }

        public IEnumerable<IEvent> GetEvents()
        {
            return TempEvents;
        }
    }
}
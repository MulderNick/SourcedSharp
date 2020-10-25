using System.Collections.Generic;
using System.Threading.Tasks;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.EventStore
{
    public class EventStore : IEventStore
    {
        public IEventRepository EventRepository;

        public EventStore(IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
        }


        public async Task Commit(IEnumerable<IEvent> events)
        {
            await EventRepository.CommitEvents(events);
        }

        public async Task<IEnumerable<IEvent>> GetEvents()
        {
            return await EventRepository.GetEvents();
        }
    }
}
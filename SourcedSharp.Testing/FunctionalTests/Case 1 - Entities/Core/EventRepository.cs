using System.Collections.Generic;
using System.Net.Http.Headers;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Testing.FunctionalTests.Core
{
    public class EventRepository : IEventRepository
    {
        public IEnumerable<IEvent> GetEvents()
        {
            return new List<IEvent>();
        }

        public bool AddEvent(IEvent @eEvent)
        {
            return true;
        }
    }
}
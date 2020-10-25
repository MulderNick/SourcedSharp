using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Exceptions;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Implementations.EventStore.InMemoryAdapter
{
    public class InMemoryEventRepository : IEventRepository
    {
        private SortedDictionary<string, IEvent> _events = new SortedDictionary<string, IEvent>();
        public InMemoryEventRepository()
        {
        }

        public async Task<IEnumerable<IEvent>> GetEvents()
        {
            return _events.Values.ToList();
        }

        public async Task CommitEvents(IEnumerable<IEvent> events)
        {
            var committedItems = new List<string>();
            try
            {
                foreach (var @event in events)
                {
                    var index = GetIndexForEvent(@event);
                    _events.Add(index, @event);
                    committedItems.Add(index);
                }
            }
            catch (Exception e)
            {
                foreach (var item in committedItems)
                {
                    _events.Remove(item);
                }
                throw new EventStoreException("Transaction did not succeed: reason - unknown");// ToDo reason so that retries can be done, //Perhaps change exception class to optimistic consistency locking type
            }
        }

        private string GetIndexForEvent(IEvent @event)
        {
            return $"{@event.MetaData.AggregateId}-{@event.MetaData.AggregateVersion}";
        }
    }
}
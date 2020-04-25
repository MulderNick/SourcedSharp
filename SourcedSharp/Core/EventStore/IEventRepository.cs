using System.Collections.Generic;
using SourcedSharp.Events;

namespace SourcedSharp.EventStore
{
    /*
     * An Event Repository is responsible for persisting events committed by the EventStore
     */
    public interface IEventRepository
    {
        IEnumerable<IEvent> GetEvents();
        bool AddEvent(IEvent @Event);
    }
}
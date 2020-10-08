using System.Collections.Generic;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.EventStore
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
using System.Collections.Generic;
using System.Threading.Tasks;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.EventStore
{
    /*
     * An Event Repository is responsible for persisting events committed by the EventStore
     */
    public interface IEventRepository
    {
        Task<IEnumerable<IEvent>> GetEvents();
        Task CommitEvents(IEnumerable<IEvent> events);
    }
}
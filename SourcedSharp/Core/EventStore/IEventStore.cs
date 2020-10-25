using System.Collections.Generic;
using System.Threading.Tasks;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.EventStore
{
    /*
     * An event store is responsible for maintaining Write Side consistency and for committing and retrieving events
     *
     * ToDo: rewrite Storage... it's not a repository and not a database per se , its more abstract
     * ToDo: define words Write Side and Read Side
     */
    public interface IEventStore
    {
        Task Commit(IEnumerable<IEvent> events);
        Task<IEnumerable<IEvent>> GetEvents();
    }
}
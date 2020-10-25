using System;
using System.Threading.Tasks;
using SourcedSharp.Core.Messages.Commands;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Aggregates
{
    /*
     * Aggregates are responsible for handling business/domain rules. They check if an event is allowed to happen.
     */
    public interface IAggregate
    {
        Guid AggregateId { get; set; }
        int AggregateVersion { get; }
    }
}
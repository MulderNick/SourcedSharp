using System;

namespace SourcedSharp.Core.Messages.Events
{
    public interface IEventMetaData
    {
        Guid AggregateId { get; set; }
        int AggregateVersion { get; set; }
        Guid EventTypeId { get; set; }
        Guid CorrelationId { get; set; }
        DateTime CreationDateTime { get; set; }
    }
}
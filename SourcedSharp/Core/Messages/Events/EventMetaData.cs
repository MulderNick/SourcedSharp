using System;

namespace SourcedSharp.Core.Messages.Events
{
    public class EventMetaData : IEventMetaData
    {
        public Guid AggregateId { get; set; }
        public int AggregateVersion { get; set; }
        public Guid EventTypeId { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
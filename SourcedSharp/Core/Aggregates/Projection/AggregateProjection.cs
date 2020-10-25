using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Aggregates.Projection
{
    public class AggregateProjection : Projections.Projection, IAggregateProjection
    {
        public IEvent LastHandledAggregateEvent { get; set; }
        public int AggregateVersion { get; set; }
    }
}
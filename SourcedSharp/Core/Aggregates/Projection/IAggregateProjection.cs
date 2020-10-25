using SourcedSharp.Core.Messages.Events;
using SourcedSharp.Core.Projections;

namespace SourcedSharp.Core.Aggregates.Projection
{
    public interface IAggregateProjection : IProjection
    {
        public IEvent LastHandledAggregateEvent { get; set; }
        public int AggregateVersion { get; set; }
    }
}
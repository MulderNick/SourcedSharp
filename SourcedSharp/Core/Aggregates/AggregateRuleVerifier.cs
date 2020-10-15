using SourcedSharp.Core.Projections;

namespace SourcedSharp.Core.Aggregates
{
    public class AggregateRuleVerifier<TProjection> : IAggregateRuleVerifier
        where TProjection : IProjection
    {
        public TProjection State;

        public AggregateRuleVerifier(TProjection projection)
        {
            State = projection;
        }
    }
}
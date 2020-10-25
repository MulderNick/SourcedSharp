using System;
using SourcedSharp.Core.Projections;

namespace SourcedSharp.Core.Aggregates.Projection
{
    public interface IAggregateProjector : IProjector
    {
        new IAggregateProjection Projection { get; set; }
    }
}
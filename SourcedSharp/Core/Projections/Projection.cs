using System;

namespace SourcedSharp.Core.Projections
{
    public class Projection : IProjection
    {
        public Guid Id;
        public Guid LastHandledEventId;
        public int NumberOfEventsHandled { get; set; }
    }
}
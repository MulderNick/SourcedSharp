using System;

namespace SourcedSharp.Core.Projections
{
    public class Projection : IProjection
    {
        public Guid Id;
        public int NumberOfHandledEvents = 0;
        public Guid LastHandledEventId;
    }
}
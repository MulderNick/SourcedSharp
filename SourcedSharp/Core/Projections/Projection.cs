using System;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Projections
{
    public class Projection : IProjection
    {
        public Guid Id { get; set; }
        public int NumberOfEventsHandled { get; set; }
        public IEvent LastHandledEvent { get; set; }
    }
}
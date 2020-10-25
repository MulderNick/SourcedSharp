using System;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Projections
{
    /*
     * A Projection is responsible for holding states created by projectors 
     */
    public interface IProjection
    {
        public Guid Id { get; set; }
        public int NumberOfEventsHandled { get; set; }
        public IEvent LastHandledEvent { get; set; }
    }
}
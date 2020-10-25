using System;
using System.Threading.Tasks;

namespace SourcedSharp.Core.Projections
{
    /*
     * A projector is responsible for created models/states in the form of Projections based on events
     */
    // ToDo: see if the separation between Projector and Projection is actually useful
    public interface IProjector
    {
        Guid ProjectionId { get; set; }
        IProjection Projection { get; set; }
        public Task Initialize();
    }
}
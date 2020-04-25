using System.Runtime.CompilerServices;
using SourcedSharp.Events;

namespace SourcedSharp.Projections
{
    /*
     * A projector is responsible for created models/states in the form of Projections based on events
     */
    public interface IProjector
    {
        int NumberOfEventsHandled { get; set; }
    }
}
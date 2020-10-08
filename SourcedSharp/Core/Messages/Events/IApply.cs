using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Core.Projections
{
    public interface IApply<in TEvent> where TEvent : IEvent
    {
        void Apply(TEvent @event);
    }
}
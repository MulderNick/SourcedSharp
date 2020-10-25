namespace SourcedSharp.Core.Messages.Events
{
    public interface IApply<in TEvent> where TEvent : IEvent
    {
        void Apply(TEvent @event);
    }
}
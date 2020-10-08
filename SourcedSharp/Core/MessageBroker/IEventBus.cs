namespace SourcedSharp.Core.MessageBroker
{
    public interface IEventBus
    {
        // Enqueued messages behave as a queue where every type of handler has their own queue
        //Task<bool> EmitEvent(IEvent @event);
        //void Subscribe(Type eventType);
        //void Subscribe(IEnumerable<Type> eventType);
    }
}
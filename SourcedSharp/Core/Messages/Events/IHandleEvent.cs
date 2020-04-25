namespace SourcedSharp.Messages
{
    public interface IHandleEvent<in TEvent> : IHandleMessage<TEvent>
    {
    }
}
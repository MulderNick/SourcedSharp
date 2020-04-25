namespace SourcedSharp.Messages
{
    public interface IHandleCommand<in TCommand> : IHandleMessage<TCommand>
    {
    }
}
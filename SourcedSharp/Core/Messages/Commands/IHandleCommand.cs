namespace SourcedSharp.Core.Messages.Commands
{
    public interface IHandleCommand<in TCommand> : IHandleMessage<TCommand>
    {
    }
}
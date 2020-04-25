using SourcedSharp.Commands;
using SourcedSharp.Messages;
using SourcedSharp.Testing.FunctionalTests.Objects.Commands;

namespace SourcedSharp.Testing.FunctionalTests.Domain
{
    public class EntityCommandHandler : ICommandHandler,
        IHandleCommand<CreateEntity>,
        IHandleCommand<RenameEntity>,
        IHandleCommand<DeleteEntity>
    {
        public void HandleMessage(CreateEntity message)
        {
            throw new System.NotImplementedException();
        }

        public void HandleCommand(CreateEntity command)
        {
            throw new System.NotImplementedException();
        }
    }
}
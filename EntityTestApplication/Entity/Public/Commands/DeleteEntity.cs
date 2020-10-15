using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class DeleteEntity : ICommand
    {
        public Guid EntityId;

        public DeleteEntity(Guid entityId)
        {
            EntityId = entityId;
        }
    }
}
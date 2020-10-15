using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class CreateEntity : ICommand
    {
        public Guid EntityId;
        public string Name;

        public CreateEntity(Guid entityId, string name)
        {
            EntityId = entityId;
            Name = name;
        }
    }
}
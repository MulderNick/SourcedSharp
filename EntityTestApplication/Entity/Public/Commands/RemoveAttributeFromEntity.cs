using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class RemoveAttributeFromEntity : ICommand
    {
        public Guid EntityId;
        public Guid AttributeId;

        public RemoveAttributeFromEntity(Guid entityId, Guid attributeId)
        {
            EntityId = entityId;
            AttributeId = attributeId;
        }
    }
}
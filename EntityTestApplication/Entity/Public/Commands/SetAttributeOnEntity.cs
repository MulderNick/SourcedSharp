using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class SetAttributeOnEntity : ICommand
    {
        public Guid EntityId;
        public Guid AttributeId;
        public string Value;

        public SetAttributeOnEntity(Guid entityId, Guid attributeId, string value)
        {
            EntityId = entityId;
            AttributeId = attributeId;
            Value = value;
        }
    }
}
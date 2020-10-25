using System;
using SourcedSharp.Core.Messages.Events;

namespace EntityTestApplication.Entity.Public.Events
{
    public class AttributeRemovedFromEntity : Event
    {
        public Guid EntityId;
        public Guid AttributeId;

        public AttributeRemovedFromEntity(Guid entityId, Guid attributeId)
        {
            EntityId = entityId;
            AttributeId = attributeId;
        }
    }
}
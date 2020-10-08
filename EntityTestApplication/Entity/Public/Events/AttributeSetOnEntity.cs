using System;
using SourcedSharp.Core.Messages.Events;

namespace EntityTestApplication.Entity.Public.Events
{
    public class AttributeSetOnEntity : IEvent
    {
        public Guid EntityId;
        public Guid AttributeId;
        public string Value;

        public AttributeSetOnEntity(Guid entityId, Guid attributeId, string value)
        {
            EntityId = entityId;
            AttributeId = attributeId;
            Value = value;
        }
    }
}
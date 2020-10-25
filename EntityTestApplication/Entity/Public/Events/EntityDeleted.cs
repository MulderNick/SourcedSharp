using System;
using SourcedSharp.Core.Messages.Events;

namespace EntityTestApplication.Entity.Public.Events
{
    public class EntityDeleted : Event
    {
        public Guid Id;

        public EntityDeleted(Guid id)
        {
            Id = id;
        }
    }
}
using System;
using SourcedSharp.Core.Messages.Events;

namespace EntityTestApplication.Entity.Public.Events
{
    public class EntityCreated : Event
    {
        public Guid Id;
        public string Name;

        public EntityCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
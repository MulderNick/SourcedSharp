using System;
using SourcedSharp.Events;

namespace SourcedSharp.Testing.FunctionalTests.Public.Events
{
    public class EntityRenamed : IEvent
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public EntityRenamed(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
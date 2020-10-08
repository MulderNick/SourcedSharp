using System;
using System.Collections.Generic;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Testing.FunctionalTests.Public.Events
{
    public class EntityCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public EntityCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
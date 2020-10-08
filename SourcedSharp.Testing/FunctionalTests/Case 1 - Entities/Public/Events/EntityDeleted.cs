using System;
using SourcedSharp.Core.Messages.Events;

namespace SourcedSharp.Testing.FunctionalTests.Public.Events
{
    public class EntityDeleted : IEvent
    {
        public Guid Id { get; }

        public EntityDeleted(Guid id)
        {
            Id = id;
        }
    }
}
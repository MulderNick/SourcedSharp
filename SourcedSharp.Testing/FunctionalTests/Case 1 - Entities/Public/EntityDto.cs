using System;

namespace SourcedSharp.Testing.FunctionalTests.Public
{
    public class EntityDto
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime CreatedAt { get; }
        public DateTime LastUpdatedAt { get; }

        public EntityDto(Guid id, string name, DateTime createdAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            LastUpdatedAt = createdAt;
        }
    }
}
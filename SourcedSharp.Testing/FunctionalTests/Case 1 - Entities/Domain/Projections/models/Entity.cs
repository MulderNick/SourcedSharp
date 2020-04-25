using System;
using SourcedSharp.ReadModels;

namespace SourcedSharp.Testing.FunctionalTests.Domain.Projections.models
{
    public class Entity : IReadModel
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public Entity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
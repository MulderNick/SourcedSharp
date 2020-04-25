using System;
using SourcedSharp.Commands;

namespace SourcedSharp.Testing.FunctionalTests.Public.Commands
{
    public class CreateEntity : ICommand
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public CreateEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
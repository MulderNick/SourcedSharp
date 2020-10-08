using System;
using SourcedSharp.Core.Messages.Commands;

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
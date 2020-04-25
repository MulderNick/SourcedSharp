using System;
using SourcedSharp.Commands;

namespace SourcedSharp.Testing.FunctionalTests.Public.Commands
{
    public class RenameEntity : ICommand
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public RenameEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
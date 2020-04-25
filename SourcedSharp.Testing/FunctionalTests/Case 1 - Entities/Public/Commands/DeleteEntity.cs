using System;
using SourcedSharp.Commands;

namespace SourcedSharp.Testing.FunctionalTests.Public.Commands
{
    public class DeleteEntity : ICommand
    {
        public Guid Id { get; }

        public DeleteEntity(Guid id)
        {
            Id = id;
        }
    }
}
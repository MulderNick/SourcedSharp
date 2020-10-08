using System;
using SourcedSharp.Core.Messages.Commands;

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
using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class DeleteEntity : ICommand
    {
        public Guid Id;

        public DeleteEntity(Guid id)
        {
            Id = id;
        }
    }
}
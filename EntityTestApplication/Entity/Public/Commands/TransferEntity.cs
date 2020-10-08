using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class TransferEntity : ICommand
    {
        public Guid Id;
        public Guid DestinationId;

        public TransferEntity(Guid id, Guid destinationId)
        {
            Id = id;
            DestinationId = destinationId;
        }
    }
}
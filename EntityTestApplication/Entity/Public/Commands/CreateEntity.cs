using System;
using SourcedSharp.Core.Messages.Commands;

namespace EntityTestApplication.Entity.Public.Commands
{
    public class CreateEntity : ICommand
    {
        public Guid Id;
        public string Name;

        public CreateEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
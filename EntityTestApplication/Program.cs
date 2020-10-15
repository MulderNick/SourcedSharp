using System;
using EntityTestApplication.Entity.Public.Commands;
using AttributeContext = EntityTestApplication.Attribute.Context;
using EntityContext = EntityTestApplication.Entity.Context;
using SourcedSharp.Core.Solution;

namespace EntityTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            solution.AddContext<EntityContext>();
            solution.AddContext<AttributeContext>();


            solution.ExecuteCommand(new CreateEntity(Guid.NewGuid(), "Name1"));
            solution.ExecuteCommand(new CreateEntity(Guid.NewGuid(), "Name2"));
            solution.ExecuteCommand(new CreateEntity(Guid.NewGuid(), "Name2"));
        }
    }
}

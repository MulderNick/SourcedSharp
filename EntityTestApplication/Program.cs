using System;
using System.Threading.Tasks;
using EntityTestApplication.Entity.Public.Commands;
using AttributeContext = EntityTestApplication.Attribute.Context;
using EntityContext = EntityTestApplication.Entity.Context;
using SourcedSharp.Core.Solution;
using SourcedSharp.Implementations.EventStore.InMemoryAdapter;
using SourcedSharp.Implementations.EventStore.MongoDbAdapter;
using SourcedSharp.Implementations.SnapshotRepositories;

namespace EntityTestApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var eventRepository = new InMemoryEventRepository();
            var snapshotRepository = new InMemorySnapshotRepository();
            var solution = new Solution(eventRepository, snapshotRepository);
            solution.AddContext<EntityContext>();
            solution.AddContext<AttributeContext>();


            await solution.ExecuteCommand(new CreateEntity(Guid.NewGuid(), "Name1"));
            await solution.ExecuteCommand(new CreateEntity(Guid.NewGuid(), "Name2"));
            await solution.ExecuteCommand(new CreateEntity(Guid.NewGuid(), "Name2"));
        }
    }
}

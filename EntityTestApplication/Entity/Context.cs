using EntityTestApplication.Entity.Entities;
using EntityTestApplication.Entity.Public.Commands;
using SourcedSharp.Core.Solution;
using SourcedSharp.Core.Solution.Context;

namespace EntityTestApplication.Entity
{
    public class Context : DomainContext
    {
        public Context(SolutionContext solution)
        {
            solution.With<EntitiesAggregate>()
                .Handle<CreateEntity>()
                .Handle<DeleteEntity>();
        }
    }
}
using System;
using EntityTestApplication.Entity.Entities;
using EntityTestApplication.Entity.Entities.AggregateComponents.State;
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

            var test = new EntitiesProjector(new Guid());
        }
    }
}

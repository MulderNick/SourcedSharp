using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SourcedSharp.Core.Aggregates.Projection;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Exceptions;

namespace SourcedSharp.Core.Projections
{
    // ToDo: Add option to register custom projector types?
    public static class ProjectorFactory
    {
        private static IEventStore _eventStore;
        private static object _snapshotCache;

        public static void Init(IEventStore eventStore, object snapshotCache = null)
        {
            _eventStore = eventStore;
            _snapshotCache = snapshotCache;
        }

        // ToDo: clean if statements
        public static async Task<TProjector> GetProjector<TProjector>(Guid projectionId)
        {
            var projectorType = typeof(TProjector);
            var initMethod = projectorType.GetMethod("Initialize");

            if (ProjectorIsTypeOfGenericBase(projectorType, typeof(InMemoryProjector<>)))
            {
                
                var instance = CreateInstance<TProjector>(projectionId, _eventStore);
                var task = (Task)initMethod.Invoke(instance, null);
                await task;
                return instance;
            }
            
            if (ProjectorIsTypeOfGenericBase(projectorType, typeof(SnapshotProjector<>)))
            {
                var instance = CreateInstance<TProjector>(projectionId, _eventStore, _snapshotCache);
                var task = (Task)initMethod.Invoke(instance, null);
                await task;
                return instance;
            }            
            if (ProjectorIsTypeOfGenericBase(projectorType, typeof(AggregateProjector<>)))
            {
                var instance = CreateInstance<TProjector>(projectionId, _eventStore, _snapshotCache);
                var task = (Task)initMethod.Invoke(instance, null);
                await task;
                return instance;
            }
            throw new SolutionException("Unregistered ProjectionType");
        }

        private static TProjector CreateInstance<TProjector>(params object[] args)
        {
            return (TProjector)Activator.CreateInstance(typeof(TProjector), args);
        }

        private static bool ProjectorIsTypeOfGenericBase(Type projectorType, Type GenericBase)
        {
            return projectorType.BaseType.GetGenericTypeDefinition().IsAssignableFrom(GenericBase);
        }
    }
}
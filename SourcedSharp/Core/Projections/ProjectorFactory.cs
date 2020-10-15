using System;
using SourcedSharp.Core.EventStore;
using SourcedSharp.Core.Exceptions;

namespace SourcedSharp.Core.Projections
{
    // ToDo: Add option for custom projector types?
    public static class ProjectorFactory
    {
        private static IEventStore _eventStore;
        private static object _snapshotCache;

        public static void Init(IEventStore eventStore, object snapshotCache = null)
        {
            _eventStore = eventStore;
            _snapshotCache = snapshotCache;
        }

        public static TProjector GetProjector<TProjector>(Guid projectionId)
        {
            var projectorType = typeof(TProjector);
            

            if (ProjectorTypeIsTypeOfGenericBase(projectorType, typeof(InMemoryProjector<>)))
            {
                return CreateInstance<TProjector>(projectionId, _eventStore);
            }
            
            if (ProjectorTypeIsTypeOfGenericBase(projectorType, typeof(SnapshotProjector<>)))
            {
                return CreateInstance<TProjector>(projectionId, _eventStore, _snapshotCache);
            }
            throw new SolutionException("Unregistered ProjectionType");
        }

        private static TProjector CreateInstance<TProjector>(params object[] args)
        {
            return (TProjector)Activator.CreateInstance(typeof(TProjector), args);
        }

        private static bool ProjectorTypeIsTypeOfGenericBase(Type projectorType, Type GenericBase)
        {
            return projectorType.BaseType.GetGenericTypeDefinition().IsAssignableFrom(GenericBase);
        }
    }
}
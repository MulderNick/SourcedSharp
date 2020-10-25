using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SourcedSharp.Core.Projections;
using SourcedSharp.Core.Projections.SnapshotStore;

namespace SourcedSharp.Implementations.SnapshotRepositories
{
    public class InMemorySnapshotRepository : ISnapshotRepository
    {
        // An instance is currently saved here. That means that the same instance is used and that side-effects migth occur.
        // ToDo: Serialize or deep-copy objects when returning
        private Dictionary<Guid, IProjection> _snapshots = new Dictionary<Guid, IProjection>();

        public async Task<TSnapshot> GetSnapshot<TSnapshot>(Guid snapshotId) where TSnapshot : IProjection
        {
            return (TSnapshot)_snapshots[snapshotId];
        }

        public async Task StoreSnapshot(IProjection projection)
        {
            _snapshots[projection.Id] = projection;
        }
    }
}
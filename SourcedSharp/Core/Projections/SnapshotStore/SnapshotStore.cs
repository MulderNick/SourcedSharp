using System;
using System.Threading.Tasks;

namespace SourcedSharp.Core.Projections.SnapshotStore
{
    public class SnapshotStore : ISnapshotStore
    {
        private ISnapshotRepository _repository;

        public SnapshotStore(ISnapshotRepository repository)
        {
            _repository = repository;
        }

        public async Task<TSnapshot> GetSnapshot<TSnapshot>(Guid snapshotId) where TSnapshot : IProjection
        {
            return await _repository.GetSnapshot<TSnapshot>(snapshotId);
        }

        public async Task StoreSnapshot(IProjection projection)
        {
            await _repository.StoreSnapshot(projection);
        }
    }
}
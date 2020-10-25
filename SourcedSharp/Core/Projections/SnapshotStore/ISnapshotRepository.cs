using System;
using System.Threading.Tasks;

namespace SourcedSharp.Core.Projections.SnapshotStore
{
    public interface ISnapshotRepository
    {
        Task<TSnapshot> GetSnapshot<TSnapshot>(Guid snapshotId) where TSnapshot : IProjection;
        Task StoreSnapshot(IProjection projection);
    }
}
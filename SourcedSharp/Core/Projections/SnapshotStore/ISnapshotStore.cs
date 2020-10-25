using System;
using System.Threading.Tasks;

namespace SourcedSharp.Core.Projections.SnapshotStore
{
    public interface ISnapshotStore
    {
        Task<TSnapshot> GetSnapshot<TSnapshot>(Guid snapshotId) where TSnapshot : IProjection;
        Task StoreSnapshot(IProjection projection);
    }
}
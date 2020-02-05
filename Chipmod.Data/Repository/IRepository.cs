using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chipmod.Data.Repository
{
    public interface IRepository<TEntity, in TId> : IReadRepository<TEntity, TId>
        where TId : IEquatable<TId>
    {
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
        Task Complete();
    }
}

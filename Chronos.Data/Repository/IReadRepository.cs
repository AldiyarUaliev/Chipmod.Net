using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chronos.Data.Repository
{
    public interface IReadRepository<TEntity, in TId>
        where TId : IEquatable<TId>
    {
        Task<TEntity> Get(TId id);
        Task<IEnumerable<TEntity>> GetList(TId[] ids);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate);
    }
}

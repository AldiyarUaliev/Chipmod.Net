using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.Repository
{
    public class EFCoreReadRepository<TEntity, TId, TContext> : IReadRepository<TEntity, TId>
        where TEntity : class
        where TId : IEquatable<TId>
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly Expression<Func<TEntity, TId>> EntityId;

        public EFCoreReadRepository(TContext context, Expression<Func<TEntity, TId>> entityId)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
            EntityId = entityId;
        }

        public async Task<TEntity> Get(TId id)
        {
            return await DbSet.FirstOrDefaultAsync(EntityId.EqualsTo(id));
        }

        public async Task<IEnumerable<TEntity>> GetList(TId[] ids)
        {
            return ids is null || ids.Length == 0
                ? null
                : await DbSet.Where(EntityId.ContainedIn(ids)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate is null
                ? null
                : await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate is null
                ? null
                : await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate)
        {
            await Task.Yield();
            return predicate is null
                ? null
                : DbSet.Where(predicate);
        }

    }
}

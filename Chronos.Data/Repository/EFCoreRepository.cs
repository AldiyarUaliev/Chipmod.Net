using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.Repository
{
    public class EFCoreRepository<TEntity, TId, TContext>
        : EFCoreReadRepository<TEntity, TId, TContext>, IRepository<TEntity, TId>
        where TEntity : class
        where TId : IEquatable<TId>
        where TContext : DbContext
    {
        public EFCoreRepository(TContext context, Func<TContext, DbSet<TEntity>> dbSet,
            Expression<Func<TEntity, TId>> entityId) : base(context, dbSet, entityId)
        {
        }

        public async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            var array = entities as TEntity[] ?? entities?.ToArray();
            if (array is { } && array.Length > 0)
                await DbSet.AddRangeAsync(array);
        }

        public async Task Remove(TEntity entity)
        {
            await Task.Yield();
            DbSet.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            await Task.Yield();
            var array = entities as TEntity[] ?? entities?.ToArray();
            if (array is { } && array.Length > 0)
                DbSet.RemoveRange(array);
        }

        public async Task Complete()
        {
            await Context.SaveChangesAsync();
        }

    }
}

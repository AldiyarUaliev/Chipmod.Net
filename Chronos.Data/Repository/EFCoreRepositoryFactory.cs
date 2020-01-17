using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos.Data.Repository
{
    public class EFCoreRepositoryFactory<TContext> where TContext : DbContext
    {
        public IReadRepository<TEntity, TId> ReadRepository<TEntity, TId>(
            IServiceProvider serviceProvider,
            Func<TContext, DbSet<TEntity>> dbSet,
            Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
        {
            var context = serviceProvider.GetRequiredService<TContext>();
            return new EFCoreReadRepository<TEntity, TId, TContext>(context, dbSet, entityId);
        }

        public IRepository<TEntity, TId> Repository<TEntity, TId>(
            IServiceProvider serviceProvider,
            Func<TContext, DbSet<TEntity>> dbSet,
            Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
        {
            var context = serviceProvider.GetRequiredService<TContext>();
            return new EFCoreRepository<TEntity, TId, TContext>(context, dbSet, entityId);
        }

    }
}

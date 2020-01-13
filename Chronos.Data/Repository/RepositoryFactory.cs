using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos.Data.Repository
{
    public class RepositoryFactory
    {
        public static EFCoreReadRepository<TEntity, TId, TContext> EFCoreReadRepository<TEntity, TId, TContext>(
            IServiceProvider serviceProvider,
            Func<TContext, DbSet<TEntity>> dbSet,
            Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
            where TContext : DbContext
        {
            var context = serviceProvider.GetRequiredService<TContext>();
            return new EFCoreReadRepository<TEntity, TId, TContext>(context, dbSet, entityId);
        }

        public static EFCoreRepository<TEntity, TId, TContext> EFCoreRepository<TEntity, TId, TContext>(
            IServiceProvider serviceProvider,
            Func<TContext, DbSet<TEntity>> dbSet,
            Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
            where TContext : DbContext
        {
            var context = serviceProvider.GetRequiredService<TContext>();
            return new EFCoreRepository<TEntity, TId, TContext>(context, dbSet, entityId);
        }

    }
}

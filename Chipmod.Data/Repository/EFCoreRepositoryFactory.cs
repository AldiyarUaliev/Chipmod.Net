using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Chipmod.Data.Repository
{
    public class EFCoreRepositoryFactory<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public EFCoreRepositoryFactory(TContext context)
        {
            _context = context;
        }

        public IReadRepository<TEntity, TId> ReadRepository<TEntity, TId>(
            Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
        {
            return new EFCoreReadRepository<TContext, TEntity, TId>(_context, entityId);
        }

        public IRepository<TEntity, TId> Repository<TEntity, TId>(
            Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
        {
            return new EFCoreRepository<TContext, TEntity, TId>(_context, entityId);
        }

    }
}

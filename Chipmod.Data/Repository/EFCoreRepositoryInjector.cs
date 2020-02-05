using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chipmod.Data.Repository
{
    public class EFCoreRepositoryInjector<TContext> where TContext : DbContext
    {
        private readonly IServiceCollection _services;

        internal EFCoreRepositoryInjector(IServiceCollection services)
        {
            _services = services;
            if (_services.All(x => x.ServiceType != typeof(EFCoreRepositoryFactory<TContext>)))
                _services.AddScoped<EFCoreRepositoryFactory<TContext>>();
        }

        public EFCoreRepositoryInjector<TContext> ReadRepository<TEntity, TId>(Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
        {
            if (_services.All(x => x.ServiceType != typeof(IReadRepository<TEntity, TId>)))
                _services.AddScoped(provider => provider
                    .GetRequiredService<EFCoreRepositoryFactory<TContext>>()
                    .ReadRepository(entityId));
            return this;
        }

        public EFCoreRepositoryInjector<TContext> Repository<TEntity, TId>(Expression<Func<TEntity, TId>> entityId)
            where TEntity : class
            where TId : IEquatable<TId>
        {
            ReadRepository(entityId);

            if (_services.All(x => x.ServiceType != typeof(IRepository<TEntity, TId>)))
                _services.AddScoped(provider => provider
                    .GetRequiredService<EFCoreRepositoryFactory<TContext>>()
                    .Repository(entityId));
            return this;
        }

    }
}

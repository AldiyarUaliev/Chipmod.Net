using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos.Data.Repository
{
    public static class ServiceCollectionExtensions
    {
        public static EFCoreRepositoryInjector<TContext> AddEFCoreRepositories<TContext>(
            this IServiceCollection services)
            where TContext : DbContext
        {
            return new EFCoreRepositoryInjector<TContext>(services);
        }
    }

}

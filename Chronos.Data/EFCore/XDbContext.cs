using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chronos.Data.EFCore
{
    public abstract class XDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        protected XDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected string ConnectionString => Configuration.GetConnectionString(DbContextName);

        protected abstract string DbContextName { get; }

    }
}

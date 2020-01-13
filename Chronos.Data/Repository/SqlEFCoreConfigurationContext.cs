using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chronos.Data.Repository
{
    public abstract class SqlEFCoreConfigurationContext : EFCoreConfigurationContext
    {
        protected SqlEFCoreConfigurationContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString(ContextName));
        }

    }
}

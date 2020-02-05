using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chipmod.Data.Repository
{
    public abstract class EFCoreConfigurationContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        protected EFCoreConfigurationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public abstract string ContextName { get; }
    }
}

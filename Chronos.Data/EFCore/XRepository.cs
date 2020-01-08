using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.EFCore
{
    public abstract class XRepository<TContext> where TContext : DbContext
    {
        protected TContext Db;

        protected XRepository(TContext dbContext)
        {
            Db = dbContext;
        }

    }
}

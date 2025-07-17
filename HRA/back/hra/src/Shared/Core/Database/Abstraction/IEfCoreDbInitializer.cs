using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Abstraction
{
    public interface IEfCoreDbInitializer
    {

        Task EnsureDbCreatedAsync<TContext>(IServiceProvider serviceProvider)
            where TContext : DbContext;
    }
}

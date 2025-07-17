using Core.Database.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Concrete
{
    public class EfCoreDbInitializer :IEfCoreDbInitializer
    {
        public async Task EnsureDbCreatedAsync<TContext>(IServiceProvider serviceProvider)
        where TContext : DbContext
        {
            using var scope = serviceProvider.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<EfCoreDbInitializer>>();
            var context = scope.ServiceProvider.GetRequiredService<TContext>();

            try
            {
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    logger.LogInformation("Applying migrations for {Context}...", typeof(TContext).Name);
                    await context.Database.MigrateAsync();
                    logger.LogInformation("Migrations applied for {Context}.", typeof(TContext).Name);
                }
                else
                {
                    logger.LogInformation("No pending migrations for {Context}.", typeof(TContext).Name);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error initializing database for {Context}.", typeof(TContext).Name);
                throw;
            }
        }
    }
}

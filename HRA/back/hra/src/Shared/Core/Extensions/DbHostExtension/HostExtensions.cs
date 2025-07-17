using Core.Database.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core.Extensions.DbHostExtension
{
    public static class HostExtensions
    {
        public static async Task UseEfCoreDbInitializerAsync<TContext>(this IHost host)
           where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IEfCoreDbInitializer>();
            await initializer.EnsureDbCreatedAsync<TContext>(scope.ServiceProvider);
        }
    }
}

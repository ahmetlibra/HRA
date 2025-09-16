using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Data.HrsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class HrsUserDbContextFactory : IDesignTimeDbContextFactory<HrsTenantDbContext>
    {
        public HrsTenantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HrsTenantDbContext>();

            // appsettings.json'daki connection string'e uygun şekilde düzenle
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hra_tenant;Username=root;Password=root;");

            return new HrsTenantDbContext(optionsBuilder.Options);
        }
    }
}

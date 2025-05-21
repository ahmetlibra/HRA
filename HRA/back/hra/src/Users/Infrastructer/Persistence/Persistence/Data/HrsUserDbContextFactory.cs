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
    public class HrsUserDbContextFactory : IDesignTimeDbContextFactory<HrsUserDbContext>
    {
        public HrsUserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HrsUserDbContext>();

            // appsettings.json'daki connection string'e uygun şekilde düzenle
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hradb;Username=root;Password=root;");

            return new HrsUserDbContext(optionsBuilder.Options);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.HrsDbContext
{
    public class HrsTenantDbContext : DbContext
    {
        public HrsTenantDbContext(DbContextOptions<HrsTenantDbContext> options) : base(options)
        { 
        
        
        
        }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<TenantConfiguration> TenantConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

        }

    }
}

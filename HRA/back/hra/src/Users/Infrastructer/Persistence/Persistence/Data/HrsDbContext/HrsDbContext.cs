using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.HrsDbContext
{
    public class HrsDbContext : DbContext
    {
        public HrsDbContext(DbContextOptions<HrsDbContext> options) : base(options)
        { 
        
        
        
        } 

    }
}

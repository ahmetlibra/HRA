using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProvisioningService.DBService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvisioningService.DBService.Concrete
{
    public class PostgresProvisioner : IDbProvisioner
    {
        private readonly IConfiguration _configuration;


        public PostgresProvisioner(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string Type => "PostgreSQL"; // Hangi türü desteklediğini belirtiyoruz.

        public async Task ProvisionTenantDatabaseAsync(string tenantCode)
        {
            // PostgreSQL şeması oluşturma ve migrate etme kodları (zaten yazdığımız kısım)
        }



    }
}

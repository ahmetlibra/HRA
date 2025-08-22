using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvisioningService.DBService.Abstract
{
    public interface IDbProvisioner
    {
        string Type { get; } // Bu satırı ekle
        /// <summary>
        /// Verilen tenant kodu için veritabanı şemasını oluşturur ve migration'ları uygular.
        /// </summary>
        /// <param name="tenantCode">Benzersiz tenant kodu.</param>
        /// <returns></returns>
        Task ProvisionTenantDatabaseAsync(string tenantCode);
    }
}

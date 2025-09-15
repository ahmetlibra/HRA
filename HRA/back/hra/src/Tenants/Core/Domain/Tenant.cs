using Core.Entities.Abstract;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Tenant:BaseEntitiy<Guid>, IEntity
    {
        public string Name { get; set; }
        public string Code { get; set; } // unique short string
        public TenantStorageType? StorageType { get; set; } // Shared / Dedicated

        /// <summary>
        /// ToDo : ConnectionStringKey Güvenliği: ConnectionStringKey'i direkt olarak veritabanında saklamak güvenlik riski oluşturabilir. Bunun yerine Azure Key Vault, AWS Secrets Manager veya HashiCorp Vault gibi bir "secrets management" aracı kullanmayı düşün. Veritabanında sadece bu servisteki anahtarın adını (SecretKey) tutabilirsin. Uygulama başlangıcında bu anahtarla gerçek connection string'i güvenli kasadan çeker.
        /// </summary>

        public string? ConnectionStringKey { get; set; } // optional for DB isolation
        public string? TimeZone { get; set; } = string.Empty; // Tenant'ın varsayılan zaman dilimi
        public TenantStatus Status { get; set; }
        public TenantType Type { get; set; } // Internal / External
        public TenantConfiguration? Configuration { get; set; }
    }
}




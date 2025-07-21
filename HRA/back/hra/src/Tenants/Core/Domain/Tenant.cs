using Core.Entities.Abstract;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Tenan:BaseEntitiy<Guid>, IEntity
    {
        public string Name { get; set; }
        public string Code { get; set; } // unique short string
        public TenantStorageType StorageType { get; set; } // Shared / Dedicated

        public string ConnectionString { get; set; } // optional for DB isolation
        public string TimeZone { get; set; }
        public TenantStatus Status { get; set; }
        public TenantType Type { get; set; } // Internal / External
        public TenantConfiguration Configuration { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}




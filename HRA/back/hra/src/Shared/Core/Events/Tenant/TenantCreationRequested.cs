using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events.Tenant
{
    public record TenantCreationRequested(Guid TenantId, string TenantCode, string DatabaseType);


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events.Tenant
{
    public record TenantProvisioningFailed(Guid TenantId, string ErrorMessage);

}

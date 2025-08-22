using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvisioningService.DBService.Abstract
{
    public interface IProvisionerFactory
    {
        IDbProvisioner GetProvisioner(string databaseType);
    }
}

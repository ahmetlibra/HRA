using ProvisioningService.DBService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvisioningService.DBService.Concrete
{
    internal class ProvisionerFactory : IProvisionerFactory
    {
        private readonly IEnumerable<IDbProvisioner> _provisioners;

        // DI container, bu arayüzü implemente eden TÜM sınıfları buraya enjekte edecek.
        public ProvisionerFactory(IEnumerable<IDbProvisioner> provisioners)
        {
            _provisioners = provisioners;
        }

        public IDbProvisioner GetProvisioner(string databaseType)
        {
            var provisioner = _provisioners.FirstOrDefault(p =>
                p.Type.Equals(databaseType, StringComparison.OrdinalIgnoreCase));

            if (provisioner == null)
            {
                throw new NotSupportedException($"Database type '{databaseType}' is not supported.");
            }

            return provisioner;
        }
    }
}

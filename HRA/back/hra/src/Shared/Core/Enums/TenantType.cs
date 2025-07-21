using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum TenantType
    {
        /// <summary>
        /// Platform içi (örneğin: kendi şirketin, test tenantları, admin'ler).
        /// </summary>
        Internal = 0,

        /// <summary>
        /// Sistemi kullanan dış firmalar (müşteriler).
        /// </summary>
        External = 1
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
  
       public enum TenantStatus
    {
        /// <summary>
        /// Yeni oluşturulmuş, ancak henüz aktivasyonu yapılmamış tenant.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Aktif olarak kullanılan tenant.
        /// </summary>
        Active = 1,

        /// <summary>
        /// Tenant erişimi geçici olarak askıya alınmış (fatura, ihlal, vs.).
        /// </summary>
        Suspended = 2,

        /// <summary>
        /// Tenant kendi isteğiyle veya admin tarafından kapatılmış.
        /// </summary>
        Inactive = 3,

        /// <summary>
        /// Sistemden tamamen silinmeden önce arşivlenmiş (sadece salt okunur erişim olabilir).
        /// </summary>
        Archived = 4,

        /// <summary>
        /// Kalıcı olarak silinmiş (veya silinme kuyruğunda olan) tenant.
        /// </summary>
        Deleted = 5
    }

}

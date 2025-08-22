using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : BaseEntitiy<Guid>, IEntity
    {
        public string AdresName { get; set; }
        public string UserId { get; set; }
        public string UserAddress { get; set; }
        public bool IsDefault { get; set; }
        public string? Phone { get; set; }
        
    }
}

using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Addres : BaseEntitiy, IEntity
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
        public string? Phone { get; set; }
        
    }
}

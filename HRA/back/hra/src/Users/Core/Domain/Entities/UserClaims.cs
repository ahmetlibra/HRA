using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole : IEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; } // Navigation property

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; } // Navigation property
    }
}

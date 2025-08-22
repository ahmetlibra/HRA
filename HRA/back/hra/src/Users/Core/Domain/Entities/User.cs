using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntitiy<Guid>, IEntity
    {


        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDay { get; set; } // value of DateTime.Ticks

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? IdentityNumber { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();


        //and another entity types

    }
}

using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntitiy, IEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public long BirthDay { get; set; } // value of DateTime.Ticks

        public string Email { get; set; }

        public short PhoneNumber { get; set; }

        public Int16? IdentityNumber { get; set; }

        //and another entity types

    }
}

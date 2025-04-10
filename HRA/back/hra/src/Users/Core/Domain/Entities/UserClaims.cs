using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserClaims : BaseEntitiy, IEntity
    {
        public Guid UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}

using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetAll
{
    public record GetAllUserQuery() : IRequest<ServiceResponse<GetAllUserResponse>>;

}

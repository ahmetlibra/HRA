using Application.Dtos.Users;
using Application.Queries.Users.GetAll;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetById
{
    public record GetByIdUserQuery(string id) : IRequest<ServiceResponse<UserDto>>;

}

using Application.Dtos.Users;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.Add
{
    public record AddUserCommand(UserDto User) : IRequest<ServiceResponse<AddUserResponse>>;

}

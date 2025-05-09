using Application.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.Add
{
    public record AddUserResponse(bool IsSuccess = false);
}

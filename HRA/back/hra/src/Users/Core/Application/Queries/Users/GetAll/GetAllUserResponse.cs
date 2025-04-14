using Application.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetAll
{
    public record GetAllUserResponse(IEnumerable<UserResponseDto> rows);
}

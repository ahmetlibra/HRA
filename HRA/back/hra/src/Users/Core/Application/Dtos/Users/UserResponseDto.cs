using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Users
{
    public record UserResponseDto(
         string Name,
         string Surname,
         long BirthDay,
        string Email,
        short PhoneNumber,
        UserRuleDto? UserRule

        );
}

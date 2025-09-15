using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Users
{
    public record UserDto(
         string? Name = null,
         string? Surname = null,
         string? Password = null,
         DateTime? BirthDay = null,
        string? Email = null,
        string? PhoneNumber = null,
        string? UserRule = null);
}

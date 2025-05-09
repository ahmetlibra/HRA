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
         long? BirthDay = 0,
        string? Email = null,
        short? PhoneNumber = 0,
        string? UserRule = null);
}

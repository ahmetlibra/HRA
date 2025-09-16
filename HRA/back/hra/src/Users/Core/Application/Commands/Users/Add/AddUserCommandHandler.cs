using Application.Dtos.Users;
using Core.CryptoHelpers.PasswordHasher;
using Core.Data.Abstract;
using Core.Entities.Concrete.Wrappers;
using Core.Enums;
using Core.Utilities.Mediator.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.Add
{
    public class AddUserCommandHandler(
         IPgRepository<User> userRepository
        ) : IRequestHandler<AddUserCommand, ServiceResponse<AddUserResponse>>
    {
        public async Task<ServiceResponse<AddUserResponse>> Handle(AddUserCommand request)
        {

            User user = new User()
            {
                TenantId = Guid.Parse("0199526a-bf86-71a2-94e3-f91da5aeeaf0"),
                BirthDay = request.User.BirthDay ?? DateTime.MinValue,
                Email = request.User.Email,
                Name = request.User.Name,
                Surname = request.User.Surname,
                PhoneNumber = request.User.PhoneNumber ?? string.Empty,
                Password = PasswordHasher.HashPassword(request.User.Password ?? "123456"),
                EntityStatus = EntityStatus.Pending,
            };


             await userRepository.Add(user);



            return await Task.FromResult(new ServiceResponse<AddUserResponse>
            {
                Data = new AddUserResponse()
                {
                    IsSuccess = true,
                },
                Success = true,
                Message = "User added successfully"
            });

        }
    }
}

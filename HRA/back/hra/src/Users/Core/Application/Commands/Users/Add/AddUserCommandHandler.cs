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
                BirthDay = request.User.BirthDay ?? DateTime.MinValue.Ticks,
                Email = request.User.Email,
                Name = request.User.Name,
                Surname = request.User.Surname,
                PhoneNumber = request.User.PhoneNumber ?? 0,
                Password = PasswordHasher.HashPassword(request.User.Password ?? "123456"),
                UserStatus = UserStatus.Waiting
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

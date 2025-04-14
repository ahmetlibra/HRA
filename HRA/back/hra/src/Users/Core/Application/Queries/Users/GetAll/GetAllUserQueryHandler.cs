using Application.Dtos.Users;
using Core.Data.Abstract;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetAll
{
    public class GetAllUserQueryHandler(
        IPgRepository<User> userRepository
        ) : IRequestHandler<GetAllUserQuery, ServiceResponse<GetAllUserResponse>>
    {
        public async Task<ServiceResponse<GetAllUserResponse>> Handle(GetAllUserQuery request)
        {
            return await GetAllUsers(request);
        }

        private async Task<ServiceResponse<GetAllUserResponse>> GetAllUsers(GetAllUserQuery request)
        {
            var users = await userRepository.GetAll();
            if (users == null)
                return new ServiceResponse<GetAllUserResponse>
                {
                    Success = false,
                    Message = "No users found"
                };
            var userList = users.Select(user => new UserResponseDto(
                Name: user.Name,
                Surname: user.Surname,
                BirthDay: user.BirthDay,
                Email: user.Email,
                PhoneNumber: user.PhoneNumber
                )).ToList();

            return new ServiceResponse<GetAllUserResponse>
            {
                Success = true,
                Message = "Users retrieved successfully",
                Data = new GetAllUserResponse(userList)
            };
        }
    }
}

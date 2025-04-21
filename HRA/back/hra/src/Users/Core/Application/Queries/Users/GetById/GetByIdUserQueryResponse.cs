using Application.Dtos.Users;
using Application.Queries.Users.GetAll;
using Core.Data.Abstract;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetById
{
    public class GetByIdUserQueryResponse(
        IPgRepository<User> userRepository
        ) : IRequestHandler<GetByIdUserQuery, ServiceResponse<UserResponseDto>>
    {
        public async Task<ServiceResponse<UserResponseDto>> Handle(GetByIdUserQuery request)
        {
            return await GetById(request);
        }

        private async Task<ServiceResponse<UserResponseDto>> GetById(GetByIdUserQuery request)
        {
            try
            {

                var user = await userRepository.GetById(Guid.Parse(request.id));
                if (user == null)
                    return new ServiceResponse<UserResponseDto>
                    {
                        Success = false,
                        Message = "No users found"
                    };
                var returnUser = new UserResponseDto(user.Name, user.Surname, user.BirthDay, user.Email, user.PhoneNumber, null);
                return new ServiceResponse<UserResponseDto>
                {
                    Success = true,
                    Message = "Users retrieved successfully",
                    Data = returnUser
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UserResponseDto>
                {
                    Success = false,
                    Message = ex.Message
                };


            }
        }
    }
}

using Application.Commands.Users.Add;
using Application.Dtos.Users;
using Application.Queries.Users.GetAll;
using Application.Queries.Users.GetById;
using Core.Data.Abstract;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using Core.Utilities.Mediator.Concrete;
using Domain.Entities;
using Persistence.Data.HrsDbContext;
using Persistence.Data.Repositories.Ef;

namespace WebApi.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // Diğer servis kayıtları
            services.AddScoped<IMediator, CustomMediator>();
            services.AddScoped(typeof(IPgRepository<>), typeof(EfEntityRepostoryBase<>));

            services.AddScoped<IRequestHandler<GetAllUserQuery, ServiceResponse<GetAllUserResponse>>, GetAllUserQueryHandler>();
            services.AddScoped<IRequestHandler<AddUserCommand, ServiceResponse<AddUserResponse>>, AddUserCommandHandler>();
            services.AddScoped<IRequestHandler<GetByIdUserQuery, ServiceResponse<UserDto>>, GetByIdUserQueryHandler>();



            return services;
        }
    }
}

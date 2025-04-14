using Application.Queries.Users.GetAll;
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



            return services;
        }
    }
}

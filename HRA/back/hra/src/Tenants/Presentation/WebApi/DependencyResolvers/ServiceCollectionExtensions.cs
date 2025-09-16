using Application.Command.Tenant.Add;
using Core.Data.Abstract;
using Core.Entities.Concrete.Wrappers;
using Core.Utilities.Mediator.Abstract;
using Core.Utilities.Mediator.Concrete;
using Persistence.Data.Repositories.Ef;

namespace WebApi.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {

            services.AddScoped<IMediator, CustomMediator>();
            services.AddScoped(typeof(IPgRepository<>), typeof(EfEntityRepostoryBase<>));

            services.AddScoped<IRequestHandler<AddTenantCommand, ServiceResponse<AddTenantResponse>>, AddTenantCommandHandler>();



            return services;
        }

    }
}

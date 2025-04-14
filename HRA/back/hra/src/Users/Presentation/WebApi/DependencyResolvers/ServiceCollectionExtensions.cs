using Core.Data.Abstract;
using Core.Data.Concrete.Ef;
using Core.Utilities.Mediator.Abstract;
using Core.Utilities.Mediator.Concrete;

namespace WebApi.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // Diğer servis kayıtları
            // services.AddScoped<IMyService, MyService>();
            services.AddScoped<IMediator, CustomMediator>();
            services.AddScoped(typeof(IPgRepository<>), typeof(EfEntityRepostoryBase<,>));

            return services;
        }
    }
}

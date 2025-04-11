using Core.Utilities.Mediator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mediator.Concrete
{
    public class CustomMediator : IMediator
    {

        private readonly IServiceProvider _serviceProvider;

        public CustomMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            // Handler tipini oluşturuyoruz
            var handlerType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            // IoC container’dan handler’ı çözümle
            dynamic handler = _serviceProvider.GetService(handlerType);
            if (handler == null)
                throw new Exception($"Handler not found for request {request.GetType().Name}");

            // Handler’ın Handle metodunu çağırıyoruz
            return await handler.Handle((dynamic)request);
        }
    }
}

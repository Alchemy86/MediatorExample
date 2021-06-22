using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatorFromScratch
{
    public class Mediator : IMediator
    {
        private readonly Func<Type, object> _serviceResolver;
        private readonly IDictionary<Type, Type> _handlerDetails;

        public Mediator(Func<Type, object> serviceResolver, IDictionary<Type, Type> handlerDetails)
        {
            _serviceResolver = serviceResolver;
            _handlerDetails = handlerDetails;
        }
        
        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var requestType = request.GetType();
            if (!_handlerDetails.ContainsKey(requestType))
            {
                throw new Exception($"No handler for type: {requestType.Name}");
            }

            var requestHandlerType = _handlerDetails[requestType];
            var handler = _serviceResolver(requestHandlerType);

            return await (Task<TResponse>) handler
                .GetType()
                .GetMethod("HandleAsync")!
                .Invoke(handler, new[] {request});
        }
    }
}
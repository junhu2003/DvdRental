using System;
using System.Linq;
using System.Collections.Generic;

namespace DvdRental.Library.Handlers
{
    public class HandlerFactory : IHandlerFactory
    {        
        private readonly IEnumerable<IHandler> _handlers;

        public HandlerFactory(IEnumerable<IHandler> handlers)
        {
            _handlers = handlers;
        }

        public IHandler CreateHandler(HandlerType handlerType)
        {
            return _handlers.FirstOrDefault(handler => handler.HandlerType == handlerType)
                ?? throw new NotImplementedException($"Handler {nameof(handlerType)} not implemented");


        }
    }
}

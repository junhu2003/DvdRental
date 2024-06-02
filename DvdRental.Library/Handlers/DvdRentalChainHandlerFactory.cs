using System;
using System.Linq;

namespace DvdRental.Library.Handlers
{
    public class DvdRentalChainHandlerFactory : IHandlerChainFactory
    {
        IHandlerFactory _handlerFactory;

        public DvdRentalChainHandlerFactory(IHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }
        public IHandler CreateChain(HandlerType[] handlerTypes)
        {
            if (handlerTypes.Length == 0)
            {
                throw new Exception($"Handler types not found.");
            }

            var handlers = handlerTypes.Select(x => _handlerFactory.CreateHandler(x)).ToList();

            for (var i = 0; i < handlers.Count(); i++)
            {
                if (i < handlers.Count() - 1)
                {
                    handlers[i].SetNextHandler(handlers[i + 1]);
                }
            }

            return handlers[0];
        }


    }
}

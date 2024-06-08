using FluentValidation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;

namespace DvdRental.Library
{
    public class DvdRental : IDvdRental
    {
        private DvdRentalContext _context;
        private IHandlerChainFactory _handlerChainFactory;
        private ILogger _logger;
        private readonly IValidator<DvdRentalInputs> _validator;

        public DvdRental(IHandlerChainFactory handlerChainFactory, ILogger<DvdRental> logger, IValidator<DvdRentalInputs> validator)
        {
            _handlerChainFactory = handlerChainFactory;
            _logger = logger;
            _validator = validator;
        }

        public async Task<DvdRentalContext> Execute(DvdRentalContext context, HandlerType[] handlerTypes)
        {
            _context = context;
            _validator.ValidateAndThrow(_context.Inputs);

            var handler = _handlerChainFactory.CreateChain(handlerTypes);

            var result = await handler.Handle(_context);

            _logger.LogInformation($"Handlers executed: {JsonConvert.SerializeObject(_context.HandlersExecuted.Select(x => x.ToString()))}");

            return result;

        }

        public void SetContext(DvdRentalContext context)
        {
            _context = context;
        }
    }
}

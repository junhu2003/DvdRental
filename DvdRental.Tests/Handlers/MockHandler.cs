using Moq;
using FluentValidation;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Handlers;
using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Tests
{
    public class MockHandler : HandlerBase
    {
        private HandlerType _handlerType;

        public MockHandler(HandlerType handlerType, IValidator<DvdRentalContext> contextValidator, ILogger<MockHandler> logger, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
            _handlerType = handlerType;
        }

        public override HandlerType HandlerType => _handlerType;

        public override string[] RuleSets => new string[] { };

        protected override Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {

            return Task.FromResult(context);

        }
    }
}

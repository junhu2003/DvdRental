using FluentValidation;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Handlers
{
    public class FinalDvdRentalHandler : HandlerBase
    {
        public FinalDvdRentalHandler(ILogger<FinalDvdRentalHandler> logger, IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
        }

        public override HandlerType HandlerType => HandlerType.FinalDvdRentalHandler;

        public override string[] RuleSets => new string[] { HandlerType.ToString() };

        protected override Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {
            context.Outputs.Customer = context.Customer;
            context.Outputs.Customers = context.Customers;
            context.Outputs.Rental = context.Rental;

            return Task.FromResult(context);
        }
    }
}

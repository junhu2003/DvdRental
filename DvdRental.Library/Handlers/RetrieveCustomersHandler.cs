using FluentValidation;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using DvdRental.Library.Repositories;

namespace DvdRental.Library.Handlers
{
    public class RetrieveCustomersHandler : HandlerBase
    {
        private readonly IConfiguration _configuration;

        private readonly ICustomerRepository _customerRepository;

        public RetrieveCustomersHandler(ILogger<InitDvdRentalHandler> logger, IConfiguration configuration,
            ICustomerRepository customerRepository,
            IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        public override HandlerType HandlerType => HandlerType.RetrieveCustomersHandler;

        public override string[] RuleSets => new string[] { HandlerType.ToString() };

        protected override async Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {     
            _logger.LogInformation($"{HandlerType} - Date processing: {context.DateAccept.ToString("yyyy-MM-dd hh:mm:ss")}");

            context.Customers = _customerRepository.GetCustomers(context.Inputs.CustomerFirstName, context.Inputs.CustomerLastName, context.Inputs.CustomerEmail);            

            _logger.LogInformation($"{HandlerType} - Finish processing ...");
            return context;
        }

    }
}

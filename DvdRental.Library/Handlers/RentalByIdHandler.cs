using FluentValidation;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using DvdRental.Library.Repositories;

namespace DvdRental.Library.Handlers
{
    public class RentalByIdHandler : HandlerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IRentalRepository _rentalRepository;        

        public RentalByIdHandler(ILogger<InitDvdRentalHandler> logger, IConfiguration configuration, 
            IRentalRepository rentalRepository,             
        IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
            _configuration = configuration;

            _rentalRepository = rentalRepository;            
        }

        public override HandlerType HandlerType => HandlerType.RentalByIdHandler;

        public override string[] RuleSets => new string[] { HandlerType.ToString() };

        protected override async Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {     
            _logger.LogInformation($"{HandlerType} - Date processing: {context.DateAccept.ToString("yyyy-MM-dd hh:mm:ss")}");

            context.Rental = _rentalRepository.GetById(context.Inputs.RentalId);            

            _logger.LogInformation($"{HandlerType} - Finish processing ...");
            return context;
        }
        
    }
}

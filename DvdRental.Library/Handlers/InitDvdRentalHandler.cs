﻿using FluentValidation;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Services;
using DvdRental.Library.Repositories;

namespace DvdRental.Library.Handlers
{
    public class InitDvdRentalHandler : HandlerBase
    {
        private readonly IConfiguration _configuration;

        public InitDvdRentalHandler(ILogger<InitDvdRentalHandler> logger, IConfiguration configuration,            
            IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService) : base(logger, contextValidator, contextStatusService)
        {
            _configuration = configuration;              
        }

        public override HandlerType HandlerType => HandlerType.InitDvdRentalHandler;

        public override string[] RuleSets => new string[] { HandlerType.ToString() };

        protected override async Task<DvdRentalContext> HandleImpl(DvdRentalContext context)
        {     

            //initialize calculator context (i.e. load employee, employer data etc.)            
            _logger.LogInformation($"{HandlerType} - Date processing: {context.DateAccept.ToString("yyyy-MM-dd hh:mm:ss")}");

            // set date accept
            context.DateAccept = DateTime.Now;

            _logger.LogInformation($"{HandlerType} - Finish processing ...");
            return context;
        }

    }
}

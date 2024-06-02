using System;
using Newtonsoft.Json;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        protected ILogger _logger;
        private readonly IValidator<DvdRentalContext> _contextValidator;
        private readonly IContextStatusService _contextStatusService;
        public HandlerBase(ILogger<HandlerBase> logger, IValidator<DvdRentalContext> contextValidator, IContextStatusService contextStatusService)
        {
            _logger = logger;
            _contextValidator = contextValidator;
            _contextStatusService = contextStatusService;
        }

        protected IHandler _next;
        private ILogger<HandlerBase> logger;
        private IValidator<DvdRentalContext> contextValidator;

        public abstract HandlerType HandlerType { get; }

        public abstract string[] RuleSets { get; }

        public async Task<DvdRentalContext> Handle(DvdRentalContext context)
        {
            try
            {
                _logger.LogInformation($"{HandlerType} - Start processing ...");

                _contextStatusService.StartContext(HandlerType, context);

                context = await HandleImpl(context);

                _contextStatusService.EndContext(context);

                _logger.LogInformation($"{HandlerType} - Finished processing.");

                context.HandlersExecuted.Add(this.HandlerType);

                var validationResult = _contextValidator.Validate(context, options => options.IncludeRuleSets(RuleSets));

                if (validationResult != null && !validationResult.IsValid)
                {
                    _logger.LogInformation($"{HandlerType} - Errors found.");
                    _logger.LogInformation(JsonConvert.SerializeObject(validationResult.Errors));
                    context.Outputs.Errors.AddRange(validationResult.Errors);
                    return context;
                }

                if (_next != null)
                {
                    _logger.LogInformation($"Next handler: {_next.HandlerType}");
                    context = await _next.Handle(context);
                }


                return context;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Handler error.");
                context.Outputs.Errors.Add(new FluentValidation.Results.ValidationFailure() { ErrorMessage = ex.Message, CustomState = ex, Severity = Severity.Error });
                return context;
            }
        }

        protected abstract Task<DvdRentalContext> HandleImpl(DvdRentalContext context);

        public void SetNextHandler(IHandler next)
        {
            _next = next;
        }

    }
}

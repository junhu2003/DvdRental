using System.Linq;
using FluentValidation;
using System.Collections.Generic;
using DvdRental.Library.Models;
using DvdRental.Library.CustomTypes;

namespace DvdRental.Library.Validators
{
    //https://docs.fluentvalidation.net/
    public class DvdRentalContextValidator : AbstractValidator<DvdRentalContext>
    {
        private readonly IValidator<Actor> _actorValidator;        

        public DvdRentalContextValidator(IValidator<Actor> actorValidator)
        {
            _actorValidator = actorValidator;            

            //validate init handler
            RuleSet(Handlers.HandlerType.InitDvdRentalHandler.ToString(), () =>
            {
                //validate context
                RuleFor(context => context.Inputs).NotNull().WithSeverity(Severity.Error);
                RuleFor(context => context.DateAccept).GreaterThan(DateTime.MinValue).WithSeverity(Severity.Error);

                //validate Actor
                RuleFor(context => context.Actor).SetValidator(_actorValidator);
            });

            //validate Retrieve Customers handler
            RuleSet(Handlers.HandlerType.RetrieveCustomersHandler.ToString(), () =>
            {
                // validate context
                RuleFor(context => context.Customers).NotNull().WithSeverity(Severity.Error);
            });

            //validate final handler
            RuleSet(Handlers.HandlerType.FinalDvdRentalHandler.ToString(), () =>
            {

            });
        }


    }
}

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
                RuleFor(context => context.Actor).NotNull().WithSeverity(Severity.Error);                

                //validate ControlParemeter
                RuleFor(context => context.Actor).SetValidator(_actorValidator);
            });

            //validate final handler
            RuleSet(Handlers.HandlerType.FinalCalcHandler.ToString(), () =>
            {

            });
        }


    }
}

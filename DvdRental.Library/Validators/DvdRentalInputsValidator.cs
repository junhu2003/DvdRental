using FluentValidation;
using DvdRental.Library.Models;

namespace DvdRental.Library.Validators
{
    public class DvdRentalInputsValidator : AbstractValidator<DvdRentalInputs>
    {
        public DvdRentalInputsValidator()
        {
            RuleFor(x => x).NotNull().WithSeverity(Severity.Error);
            //RuleFor(x => x.ActorId).GreaterThan(0).WithSeverity(Severity.Error);            
        }
    }
}

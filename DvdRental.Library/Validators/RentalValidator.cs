using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator() { }
    }
}

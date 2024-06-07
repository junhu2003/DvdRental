using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator() { }
    }
}

using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator() { }
    }
}

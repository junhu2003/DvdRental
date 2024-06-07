using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator() { }
    }
}

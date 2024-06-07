using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() { }
    }
}

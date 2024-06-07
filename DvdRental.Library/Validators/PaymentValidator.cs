using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator() { }
    }
}

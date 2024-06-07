using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator() { }
    }
}

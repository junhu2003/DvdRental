using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() { }
    }
}

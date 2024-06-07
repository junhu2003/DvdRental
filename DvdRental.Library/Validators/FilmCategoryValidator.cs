using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class FilmCategoryValidator : AbstractValidator<FilmCategory>
    {
        public FilmCategoryValidator() { }
    }
}

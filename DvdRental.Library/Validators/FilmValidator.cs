using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator() { }    
    }
}

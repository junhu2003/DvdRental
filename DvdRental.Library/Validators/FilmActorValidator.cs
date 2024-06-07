using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class FilmActorValidator : AbstractValidator<FilmActor>
    {
        public FilmActorValidator() { }
    }
}

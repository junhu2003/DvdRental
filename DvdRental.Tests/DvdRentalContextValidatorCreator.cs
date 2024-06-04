using FluentValidation;
using Moq;
using DvdRental.Library.Models;
using DvdRental.Library.Validators;

namespace DvdRental.Tests
{
    public class DvdRentalContextValidatorCreator
    {
        public static DvdRentalContextValidator Create()
        {

            return new DvdRentalContextValidator(
                            Mock.Of<IValidator<Actor>>());

        }
    }
}

using System.Collections.Generic;
using FluentValidation.Resources;
using FluentValidation.Results;

namespace DvdRental.Library.Models
{
    public class DvdRentalOutputs
    {
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();

        public Actor? Actor { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}

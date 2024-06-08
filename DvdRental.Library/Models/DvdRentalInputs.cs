using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdRental.Library.Models
{
    public class DvdRentalInputs
    {
        public string? User { get; set; }
        public string Id { get; } = Guid.NewGuid().ToString();

        public int CustomerId { get; set; }
        public string? CustomerFirstName { get; set; } = string.Empty;
        public string? CustomerLastName { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; } = string.Empty;

        public int RentalId { get; set; }        
    }
}

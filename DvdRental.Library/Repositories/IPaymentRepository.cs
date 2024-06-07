using DvdRental.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdRental.Library.Repositories
{
    public interface IPaymentRepository
    {
        List<Payment>? GetByRentalId(int rentalId);
        List<Payment>? GetByCustomerId(int custId);
    }
}

using DvdRental.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdRental.Library.Repositories
{
    public interface IRentalRepository
    {
        Rental? GetById(int id);
        List<Rental>? GetRentalByCustomer(int custId);
    }
}

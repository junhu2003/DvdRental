using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public interface IStaffRepository
    {
        Staff? GetById(int id);
    }
}

using DvdRental.Library.Models;
using DvdRental.Library.Repositories;

namespace DvdRental.Tests.Repositories
{
    public class MockStaffRepository : IStaffRepository
    {
        public Staff? GetById(int id)
        {
            var data = TestUtils.JsonFileToObject<Staff>(@"TestData\\Staff.json");

            return data;
        }
    }
}

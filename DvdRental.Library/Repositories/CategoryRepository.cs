using DvdRental.Library.Models;
using DvdRental.Library.Services;

namespace DvdRental.Library.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public Category? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Categories.Where(a => a.CategoryId == id).FirstOrDefault();
            }
        }
    }
}

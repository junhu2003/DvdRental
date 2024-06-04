using DvdRental.Library.Services;
using DvdRental.Library.Models;

namespace DvdRental.Library.Repositories
{
    public class ActorRepository : RepositoryBase, IActorRepository
    {
        public ActorRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public List<Actor>? GetAll()
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Actors.ToList();
            }
        }

        public Actor? GetById(int id)
        {
            using (var _dbContext = (DvdRentalDbContext)_dbContextFactory.CreateDbContext(DatabaseType.Postgres))
            {
                return _dbContext.Actors.Where(a => a.ActorId == id).FirstOrDefault();
            }
        }
    }
}

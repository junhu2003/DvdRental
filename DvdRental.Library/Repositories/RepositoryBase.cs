using DvdRental.Library.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DvdRental.Library.Repositories
{
    public class RepositoryBase
    {
        protected readonly IDbContextFactory _dbContextFactory;
        
        public RepositoryBase(IDbContextFactory dbContextFactory) 
        { 
            _dbContextFactory = dbContextFactory;
        }
    }
}

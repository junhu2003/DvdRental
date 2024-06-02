using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DvdRental.Library.Models;

namespace DvdRental.Library.Services
{
    public class DbContextFactory : IDbContextFactory
    {
        private IConfiguration _configuration;
        public DbContextFactory(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public DbContext CreateDbContext(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.Postgres: return CreatePostgresDbContext();
                default: throw new NotImplementedException($"{dbType} is not supported.");
            }            
        }

        private DvdRentalDbContext CreatePostgresDbContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<DvdRentalDbContext>()
                .UseNpgsql(_configuration["DB_CONN"]);

            return new DvdRentalDbContext(optionBuilder.Options);
        }
    }
}

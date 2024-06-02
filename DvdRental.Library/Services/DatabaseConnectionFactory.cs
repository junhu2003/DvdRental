using System.Data;
using System.Data.Odbc;
using DvdRental.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DvdRental.Library.Services
{
    public class DatabaseConnectionFactory : IDbConnectionFactory
    {
        private IConfiguration _configuration;
        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.DB2: return CreateDb2Connection();
                default: throw new NotImplementedException($"{dbType} is not supported.");
            }
        }
       
        private IDbConnection CreateDb2Connection()
        {
            var conn = new OdbcConnection(_configuration["DB_CONN"]);
            conn.Open();
            return conn;
        }
    }
}

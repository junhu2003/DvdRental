using System.Data;

namespace DvdRental.Library.Services
{
    public interface IDbConnectionFactory
    {        
        IDbConnection CreateConnection(DatabaseType dbType);
    }

    public enum DatabaseType { DB2, Postgres };
}

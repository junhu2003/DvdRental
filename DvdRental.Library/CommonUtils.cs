using Dapper;
using DvdRental.Library.Mappers;

namespace DvdRental.Library
{
    public class CommonUtils
    {
        public static void InitializeDbHandlers()
        {
            TypeMapper.Initialize("DvdRental.Library.Models");

            SqlMapper.AddTypeHandler(new StringTypeHandler());            
            SqlMapper.AddTypeHandler(new ProvinceTypeHandler());            
        }
    }
}

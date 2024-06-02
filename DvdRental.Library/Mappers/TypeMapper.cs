using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DvdRental.Library.Mappers
{
    public static class TypeMapper
    {
        public static void Initialize(string @namespace)
        {
            var types = from assem in AppDomain.CurrentDomain.GetAssemblies().ToList()
                        from type in assem.GetTypes()
                        where type.IsClass && type.Namespace == @namespace
                        select type;

            types.ToList().ForEach(type =>
            {
                var mapper = (SqlMapper.ITypeMap)Activator
                    .CreateInstance(typeof(ColumnAttributeTypeMapper<>)
                                    .MakeGenericType(type));
                SqlMapper.SetTypeMap(type, mapper);
            });
        }
    }
}

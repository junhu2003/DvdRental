using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DvdRental.Library.Mappers
{
    public class StringTypeHandler : SqlMapper.TypeHandler<string>
    {
        public override string Parse(object value)
        {
            return value?.ToString().Trim();
        }

        public override void SetValue(IDbDataParameter parameter, string value)
        {
            parameter.Value = value;
        }
    }
}

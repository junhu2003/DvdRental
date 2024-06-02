using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DvdRental.Library.CustomTypes;

namespace DvdRental.Library.Mappers
{
    public class ProvinceTypeHandler : SqlMapper.TypeHandler<Province>
    {
        public override Province Parse(object value)
        {
            var provStr = value.ToString()?.Trim();

            if (string.IsNullOrEmpty(provStr))
            {
                return new Province()
                {
                    Value = ProvinceEnum.NONE
                };
            }

            ProvinceEnum province;

            if (Enum.TryParse(provStr, true, out province))
            {
                return new Province()
                {
                    Value = province
                };
            }
            else
            {
                return new Province()
                {
                    Value = ProvinceEnum.NONE
                };
            }

        }

        public override void SetValue(IDbDataParameter parameter, Province value)
        {
            if (value.Value == ProvinceEnum.NONE)
            {
                parameter.Value = string.Empty;
            }
            else
            {
                parameter.Value = Enum.GetName(typeof(ProvinceEnum), value.Value);
            }


        }
    }
}

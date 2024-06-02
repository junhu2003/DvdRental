using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DvdRental.Library.CustomTypes;
using DvdRental.Library.Extensions;

namespace Victor.Calculator.Library.Mappers
{
    public class EmployeeStatusTypeHandler : SqlMapper.TypeHandler<EmployeeStatus>
    {
        public override EmployeeStatus Parse(object value)
        {
            var employeeStatusStr = value.ToString()?.Trim().ToUpper();

            if (EmployeeStatusEnum.NEW.GetDescription().Equals(employeeStatusStr))
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.NEW };
            }
            else if (EmployeeStatusEnum.CHANGE.GetDescription().Equals(employeeStatusStr))
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.CHANGE };
            }
            else if (EmployeeStatusEnum.DELETE_D.GetDescription().Equals(employeeStatusStr))
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.DELETE_D };
            }
            else if (EmployeeStatusEnum.DELETE_R.GetDescription().Equals(employeeStatusStr))
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.DELETE_R };
            }
            else if (EmployeeStatusEnum.DELETED.GetDescription().Equals(employeeStatusStr))
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.DELETED };
            }
            else if (EmployeeStatusEnum.NONE.GetDescription().Equals(employeeStatusStr))
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.NONE };
            }
            else
            {
                return new EmployeeStatus() { Value = EmployeeStatusEnum.NONE };
            }
        }

        public override void SetValue(IDbDataParameter parameter, EmployeeStatus value)
        {
            parameter.Value = value.Value.GetDescription();
        }
    }
}

using System.ComponentModel;

namespace DvdRental.Library.CustomTypes
{
    public enum EmployeeStatusEnum
    {
        [Description("")]
        NONE,
        [Description("N")]
        NEW,
        [Description("C")]
        CHANGE,
        [Description("D")]
        DELETE_D,
        [Description("R")]
        DELETE_R,
        [Description("*")]
        DELETED
    }

    public class EmployeeStatus
    {
        public EmployeeStatusEnum Value { get; set; }
    }
}

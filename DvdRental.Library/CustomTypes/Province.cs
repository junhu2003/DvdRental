using System;
using System.Collections.Generic;
using System.Text;

namespace DvdRental.Library.CustomTypes
{
    public enum ProvinceEnum { NONE, AB, BC, MB, NB, NL, NS, NT, NU, ON, PE, QC, SK, YT }

    public class Province
    {
        public ProvinceEnum Value { get; set; }
    }
}

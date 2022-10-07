using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class EmpCountryTbl
    {
        public EmpCountryTbl()
        {
            Addresses = new HashSet<Address>();
            EmpStateTbls = new HashSet<EmpStateTbl>();
        }

        public long CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EmpStateTbl> EmpStateTbls { get; set; }
    }
}

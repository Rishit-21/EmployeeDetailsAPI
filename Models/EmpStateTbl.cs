using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class EmpStateTbl
    {
        public EmpStateTbl()
        {
            Addresses = new HashSet<Address>();
            EmpCityTbls = new HashSet<EmpCityTbl>();
        }

        public long StateId { get; set; }
        public long? CountryId { get; set; }
        public string StateName { get; set; }

        public virtual EmpCountryTbl Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EmpCityTbl> EmpCityTbls { get; set; }
    }
}

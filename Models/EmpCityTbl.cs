using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class EmpCityTbl
    {
        public EmpCityTbl()
        {
            Addresses = new HashSet<Address>();
        }

        public long CityId { get; set; }
        public long? StateId { get; set; }
        public string CityName { get; set; }

        public virtual EmpStateTbl State { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}

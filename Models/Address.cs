using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class Address
    {
        public long CurrAddressId { get; set; }
        public long? EmpId { get; set; }
        public string CurrAddressDetails { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string AddType { get; set; }
        public int? PinCode { get; set; }

        public virtual EmpCityTbl City { get; set; }
        public virtual EmpCountryTbl Country { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual EmpStateTbl State { get; set; }
    }
}

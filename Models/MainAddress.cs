using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Models
{
    [Keyless]
    public class MainAddress
    {
   

        public long CurrAddressId { get; set; }
      
        public string CurrAddressDetails { get; set; }
     
        public string CountryName { get; set; }
       
        public string StateName { get; set; }
      
        public string CityName { get; set; }
        public string AddType { get; set; }
        public int? PinCode { get; set; }
        //public virtual EmpCityTbl City { get; set; }
        //public virtual EmpCountryTbl Country { get; set; }
        //public virtual Employee Emp { get; set; }
        //public virtual EmpStateTbl State { get; set; }
    }
}

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
       
    }
}

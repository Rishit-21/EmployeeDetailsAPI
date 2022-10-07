using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Models
{
    public class GetEmployeeWithAdress
    {
        //em.*,ca.CurrAddressDetails,empCty.CityName,empstat.StateName,empCnty.CountryName,ca.AddType
     
        public long EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string CurrAddressDetails { get; set; }
        public string CityName { get; set; }

        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string AddType { get; set; }

    }
}

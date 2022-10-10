using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Models
{
    public class AddAddresscs
    {
      
        public string CurrAddressDetails { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string AddType { get; set; }
        public int? PinCode { get; set; }
    }
}

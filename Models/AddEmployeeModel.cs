using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Models
{
    public class AddEmployeeModel
    {

      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

       
        public AddEmployeeModel()
        {
            AddAddresses = new HashSet<AddAddresscs>();
           // Addressess = new HashSet<MainAddress>();
        }
        [NotMapped]
        public virtual ICollection<AddAddresscs> AddAddresses { get; set; }
        //[NotMapped]
        //public virtual ICollection<MainAddress> Addressess { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class Employee
    {
      

        public long EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public string status { get; set; }

        public Employee()
        {
            Addresses = new HashSet<Address>();
            Addressess = new HashSet<MainAddress>();
        }
        public virtual ICollection<Address> Addresses { get; set; }
        [NotMapped]
        public virtual ICollection<MainAddress> Addressess { get; set; }
    }
}

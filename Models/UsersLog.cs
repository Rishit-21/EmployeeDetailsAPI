using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class UsersLog
    {
        public long LogId { get; set; }
        public string UserId { get; set; }
      
        public string UserRole { get; set; }
        public string Actions { get; set; }
        public long ActionEmpId { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Models
{
    public class UserDBContext:IdentityDbContext<ApplicationUser>
    {
        public UserDBContext()
        {
                
        }
        public UserDBContext(DbContextOptions<UserDBContext> options):base(options)
        {

        }

    }
}

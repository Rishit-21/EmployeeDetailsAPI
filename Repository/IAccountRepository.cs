using EmployeeDetailsAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> signUpAsync(SignUpModel signUpModel, bool RoleAssignFlag);
        Task<string> signInAsync(LoginModel loginModel);
        Task Userlogs(string action,long id);           
        //Task<string> signUpAdminAsync(LoginModel loginModel);
    }
}

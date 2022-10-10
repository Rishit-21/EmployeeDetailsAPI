
using EmployeeDetailsAPI.Models;
using EmployeeDetailsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
  
        private readonly IUserService _userService;
      
        
        private readonly EmployeeDetailsContext _context;
      

        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
           
            IUserService userService,
            EmployeeDetailsContext context
         
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
           
           _userService = userService;
        
            _context = context;
       
        }
      
        public async Task<IdentityResult> signUpAsync(SignUpModel signUpModel,bool RoleAssignFlag)
        {
            var user = new ApplicationUser()
            {

                FirstName = signUpModel.FirstName,
                LastName = signUpModel.Lastname,
                Email = signUpModel.Email,
                UserName = signUpModel.Email

            };
            var result = await _userManager.CreateAsync(user, signUpModel.Password);
            var UserCalled = await _userManager.FindByNameAsync(signUpModel.Email);
            if (RoleAssignFlag)
            {
                await _userManager.AddToRoleAsync(UserCalled, "ADMIN");
            }
            else
            {
            await _userManager.AddToRoleAsync(UserCalled, "STAFF");

            }
            return result;
        }

        

        public async Task<string> signInAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);
            var UserCalled = await _userManager.FindByNameAsync(loginModel.Email);
            var role = await _userManager.GetRolesAsync(UserCalled);
          


            if (!result.Succeeded)
            {
                return null;
            }
            
                var authClaims = new List<Claim>
            {

                 new Claim(ClaimTypes.NameIdentifier,UserCalled.Id),
                new Claim(ClaimTypes.Name, loginModel.Email),
                 new Claim(ClaimTypes.Role, role.FirstOrDefault()),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                );

           
           

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Userlogs (string action,long id)
        {

            var userid = _userService.GetUserId();
            var UserCalled = await _userManager.FindByIdAsync(userid);
            var role = await _userManager.GetRolesAsync(UserCalled);

            var userlogs = new UsersLog()
            {
                UserId = userid,
                UserRole = role.FirstOrDefault(),
                ActionEmpId=id,
                Actions= action,


            };
            _context.UsersLogs.Add(userlogs);
            _context.SaveChanges();
        }

    }
}

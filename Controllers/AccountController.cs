using EmployeeDetailsAPI.Models;
using EmployeeDetailsAPI.Repository;
using EmployeeDetailsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserService _userService;

        public AccountController(IAccountRepository accountRepository, IUserService userService)
        {
            _accountRepository = accountRepository;
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signUp([FromBody] SignUpModel signUpModel, bool RoleAssignFlg)
        {
            var result = await _accountRepository.signUpAsync(signUpModel, RoleAssignFlg);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
    
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {

            var result = await _accountRepository.signInAsync(loginModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        //[HttpGet("id")]
        //public async Task<IActionResult> userId()
        //{
        //    var userid =   _userService.GetUserId();
        //    return Ok(userid);

        //}
    }
}

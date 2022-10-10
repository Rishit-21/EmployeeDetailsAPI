using EmployeeDetailsAPI.Models;
using EmployeeDetailsAPI.Repository;
using EmployeeDetailsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;


        public EmployeeDetailsController(IEmployeeRepository employee)
        {
            _employee = employee;

        }

        [HttpGet("{Id}/{AddressFlag}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployeeByID([FromRoute] int Id, [FromRoute] bool AddressFlag)
        {


            var employee = await _employee.GetEmployeeById(Id, AddressFlag);
            if (AddressFlag)
            {
                var emp = new
                {
                    EmpId = employee.EmpId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    JobTitle = employee.JobTitle,
                    status = employee.status,
                    Addressess=employee.Addressess
                    

                };
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            else
            {
                var emp = new 
                {
                    EmpId = employee.EmpId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    JobTitle = employee.JobTitle,
                    status = employee.status

                };
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);

            }
        
        }
        [HttpPost("")]

        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            long empId;

            empId = await _employee.AddEmployee(employee);


            return Ok(empId);

        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] long Id, [FromBody] JsonPatchDocument employee)
        {
            await _employee.EditEmployee(Id, employee);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmp([FromRoute] long Id)
        {
            long id = await _employee.DeleteEmp(Id);
            return Ok(id);
        }


    }

}

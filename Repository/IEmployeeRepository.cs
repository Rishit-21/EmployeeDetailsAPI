using EmployeeDetailsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int Id, bool AddressFlag);
        Task<long> AddEmployee(Employee employee);
        Task EditEmployee(long Id, JsonPatchDocument employee);
        Task DeleteEmp( long Id);
        //Task EditEmployee(long id, Employee employee);
    }
}

using EmployeeDetailsAPI.Models;
using EmployeeDetailsAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDetailsContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountRepository _accountRepository;

        public EmployeeRepository(EmployeeDetailsContext context,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IAccountRepository accountRepository
            
            )
        {

            _context = context;
            _configuration = configuration;
            _userManager = userManager;
         _accountRepository = accountRepository;
        }



        public async Task<Employee> GetEmployeeById(int Id, bool AddressFlag)
        {

            if (!AddressFlag)
            {
                var employee = _context.Employees.FromSqlRaw<Employee>("SelectEmployeeById {0}", Id).ToList().FirstOrDefault();

                return employee;
            }
            else
            {
                //var empdetils =  _context.Employees.FromSqlRaw<Employee>("selectemployeebyId {0}", Id).ToList().FirstOrDefault();
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                //SqlConnection con =
                SqlCommand scm1 = new SqlCommand("SelectEmployeeByIdWithAdress", con);
                con.Open();
                //scm1.CommandType = System.Data.CommandType.StoredProcedure; 
                scm1.CommandType = CommandType.StoredProcedure;
                scm1.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                SqlDataReader sdr = scm1.ExecuteReader();
                //DataTable dt = new DataTable();


                List<Employee> EmpWithAdd = new List<Employee>();
                Employee em = new Employee();
                while (sdr.Read())
                {

                    em.EmpId = (long)sdr["EmpId"];
                    em.FirstName = sdr["FirstName"].ToString();
                    em.LastName = sdr["LastName"].ToString();
                    em.JobTitle = sdr["JobTitle"].ToString();
                    em.status = sdr["status"].ToString();

                    EmpWithAdd.Add(em);
                    
                }
                var NextResult = sdr.NextResult();
                while (NextResult)
                {
                    while (sdr.Read())
                    {
                        MainAddress emp = new MainAddress();

                        emp.CurrAddressDetails = sdr["CurrAddressDetails"].ToString();
                        emp.CityName = sdr["CityName"].ToString();
                        emp.StateName = sdr["StateName"].ToString();
                        emp.CountryName = sdr["CountryName"].ToString();
                        emp.PinCode = (int)sdr["PinCode"];
                        emp.AddType = sdr["AddType"].ToString();

                        em.Addressess.Add(emp);


                    }
                    NextResult = sdr.NextResult();

                  
                }



                con.Close();


                return EmpWithAdd.FirstOrDefault();

            }




        }

        public async Task<long> AddEmployee(Employee employee)
        {
            var emp = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JobTitle = employee.JobTitle,
                status=  "1"
            };
            emp.Addresses = new List<Address>();
            foreach (var addDetails in employee.Addresses)
            {
                emp.Addresses.Add(new Address()
                {
                    EmpId = emp.EmpId,
                    CurrAddressDetails = addDetails.CurrAddressDetails,
                    CountryId = addDetails.CountryId,
                    StateId = addDetails.StateId,
                    CityId = addDetails.CityId,
                    PinCode = addDetails.PinCode,
                    AddType = addDetails.AddType,

                });
            
            }

            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            await _accountRepository.Userlogs("Employee Added",emp.EmpId);
            return emp.EmpId;


        }

        public async Task EditEmployee(long Id, JsonPatchDocument employee)
        {
            var emp = await _context.Employees.FindAsync(Id);
            if (emp != null)
            {
                await _accountRepository.Userlogs("Employee Edited",Id);
                employee.ApplyTo(emp);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<long> DeleteEmp( long Id)
        {
           
            var emp = await _context.Employees.FindAsync(Id);
           
            if (emp != null)
            {
                if (emp.status != "0")
                {

                emp.status = "0";

               
                _context.Entry(emp).State = EntityState.Modified;
              
              
                await _context.SaveChangesAsync();
                await _accountRepository.Userlogs("Employee Deleted",Id);
                    return emp.EmpId;
                }
                return 0;
               

               
               
            }
            return 0;

        }


    }
}

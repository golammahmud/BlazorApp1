using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Data;
using Data.BlazoorApp.DataModels;
using Data.BlazoorApp.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.BlazoorApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

       

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var employee = await context.Employee.Include(d => d.Department).FirstOrDefaultAsync(dept=> dept.EmployeeId == employeeId);
            return employee;
        }

        //public async Task<IEnumerable<Employee>> GetEmployees()
        //{
        //    return await context.Employee.ToListAsync();
        //}


        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employee.Include(dept=>dept.Department).ToList();// as IEnumerable<Employee>;
        }





        public async Task<Employee> UpdateEmployee( Employee employee)
        {
            var result = await context.Employee
                 .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.EmployeeId = employee.EmployeeId;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
              

                await context.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await context.Employee.AddAsync(employee);

            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee>  DeleteEmployee(int employeeId)
        {
            var result = await context.Employee
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                var delete=context.Employee.Remove(result);
                await context.SaveChangesAsync();
                return (result);
            }
            return null;
        }

        public async Task<Employee> GetEmployeeByEmail(string Email)
        {
            var emp = await context.Employee.Where(x => x.Email == Email).FirstOrDefaultAsync();
            return emp;
        }





        //public Task<IEnumerable<Employee>> Search(Employee? employee, Gender? gender)
        public async Task<IEnumerable<Employee>> Search(string? name, int? gender)
        {
            IQueryable<Employee> query = context.Employee;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name) || e.Email.Contains(name) ||
                e.DateOfBirth == Convert.ToDateTime(name).Date || e.DepartmentId.Equals(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            //if (!string.IsNullOrEmpty(employee.FirstName ))
            //{
            //    query = query.Where(e => e.FirstName.Contains(employee.FirstName)
            //                || e.LastName.Contains(employee.LastName));
            //}


            //if (!string.IsNullOrEmpty(employee.Email))
            //{
            //    query = query.Where(e => e.Email.Contains(employee.Email));
            //}


            //if (gender != null)
            //{
            //    query = query.Where(e => e.Gender == gender);
            //}


            //if (employee.DateOfBirth!=null)
            //{

            //    query.Where(c => c.DateOfBirth.Date == Convert.ToDateTime(employee.DateOfBirth).Date);
            //}

            return await query.ToListAsync();
        }

      
    }
}

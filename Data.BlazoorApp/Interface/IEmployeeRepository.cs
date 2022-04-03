using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlazoorApp.DataModels;

namespace Data.BlazoorApp.Interface
{
    public interface IEmployeeRepository
    {
 

        IEnumerable<Employee> GetAllEmployees();
        //IEnumerable<Employee> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<IEnumerable<Employee>> Search(string? name, int? gender);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlazoorApp.DataModels;

namespace Data.BlazoorApp.Interface
{
    public interface IDepartmentsRepository
    {
       IEnumerable<Department> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);



    }
}

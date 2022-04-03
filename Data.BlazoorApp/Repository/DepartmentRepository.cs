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
    public class DepartmentRepository : IDepartmentsRepository
    {

        private readonly ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }


       

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await context.Department.Include(d => d.Employees).FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return  context.Department.Include(d=>d.Employees).ToList();
        }

        public  async Task<Department> UpdateDepartment(Department department)
        {
            var result = await context.Department
                .FirstOrDefaultAsync(e => e.DepartmentId == department.DepartmentId);

            if (result != null)
            {
              
                result.Name = department.Name;
                result.Created_at = department.Created_at;
                
               

                await context.SaveChangesAsync();

                return result;
            }

            return null;
        }



        public async Task<Department> AddDepartment(Department department)
        {
            var model = await context.Department.AddAsync(department);

            await context.SaveChangesAsync();

            return model.Entity;
        }

        public async void DeleteDepartment(int departmentId)
        {
            var department = await context.Department.FindAsync(departmentId);
            if (department != null)
            {
                context.Department.Remove(department);
                await context.SaveChangesAsync();

            }
        }
    }
}

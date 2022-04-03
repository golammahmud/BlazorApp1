using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BlazoorApp.DataModels
{
    public class Department
    {
        
        [Key]
        public int DepartmentId { get; set; }

        public string Name { get; set; }
        public DateTime? Created_at { get; set; }

        public ICollection<Employee>? Employees { get; set; }

    }
}

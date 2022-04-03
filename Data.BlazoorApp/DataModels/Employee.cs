using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BlazoorApp.DataModels
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }

        //public string? PhotoPath { get; set; }
        public DateTime? DateOfBirth { get; set; }


        public int Gender { get; set; }

        public DateTime? Created_at { get; set; }

        //Navigation Property


        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        // public ICollection<Department> Departments { get; set; }



    }
}

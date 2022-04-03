using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlazoorApp.DataModels;

namespace ViewModel.App.ViewModels
{
    public class DepartmentsViewModel
    {
        public int DepartmentId { get; set; }


        [Required]
        public string Name { get; set; }
        public DateTime? Created_at { get; set; }

        public ICollection<EmployeeViewModel> Employees { get; set; }
    }
}

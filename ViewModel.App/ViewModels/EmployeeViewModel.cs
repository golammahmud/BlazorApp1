using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlazoorApp.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModel.App.CustomValidation;

namespace ViewModel.App.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "FirstName is mandatory")]
        [MinLength(2)]
        public string? FirstName { get; set; }


        [Required]
        public string? LastName { get; set; }



        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        [EmailAddress]
        [CustomEmailValidation(AllowedEmail = "web.com",ErrorMessage ="gmail must be web.com")]
        public string? Email { get; set; }



        [CompareProperty("Email",ErrorMessage = "Email and Confirm Email must match")]
        public string? ConfirmEmail { get; set; }




        [Required]
        public DateTime? DateOfBirth { get; set; }


        [Required ]
        public Gender Gender { get; set; }

        public DateTime? Created_at { get; set; }




        //Navigation Property
        public int? DepartmentId { get; set; }



        [ValidateComplexType]
        public Department Department { get; set; } = new Department();

        public List<SelectListItem> Departments { get; set;}


    }
}

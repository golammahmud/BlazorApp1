using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.App.CustomValidation
{
    public class CustomEmailValidation: ValidationAttribute
    {
        public string AllowedEmail { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {

                string[] strings = value.ToString().Split('@');
                if (strings.Length > 1 && strings[1].ToUpper() == AllowedEmail.ToUpper())
                {
                    return null;
                }


                return new ValidationResult(ErrorMessage /*$"Domain must be {AllowedEmail}"*/,
                    new[] { validationContext.MemberName });
            }
            return null;
            
        }
    }
}

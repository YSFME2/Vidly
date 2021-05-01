using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Validations
{
    public class Mini18YearsIfaMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("BirthDate required");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return age >= 18 ? ValidationResult.Success : new ValidationResult("You should be at least 18 years old to go on a membership");
        }
    }
}
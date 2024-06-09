using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class ValidEmailPatternAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;
            if (String.IsNullOrEmpty(email))
            {
                return new ValidationResult("Email is required.");
            }

            if (!Regex.IsMatch(email, @"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$"))
            {
                return new ValidationResult("Email format not recognized.");
            }

            return ValidationResult.Success;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class PasswordComplexityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;
           
            if (password.Length < 12 ||
                !Regex.IsMatch(password, @"[A-Z].*[A-Z]") || // At least two uppercase letters
                !Regex.IsMatch(password, @"[a-z].*[a-z]") || // At least two lowercase letters
                !Regex.IsMatch(password, @"\d.*\d") || // At least two digits
                !Regex.IsMatch(password, @"[\W_].*[\W_]")) // At least two special characters
            {
                return new ValidationResult("Password must be at least 12 characters long and include at least two uppercase letters, two lowercase letters, two numbers, and two special characters.");
            }

            return ValidationResult.Success;
        }
    }
}

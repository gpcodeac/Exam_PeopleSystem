using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class LithuanianPhoneNumberAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = value as string;
            if (phoneNumber == null)
            {
                return ValidationResult.Success;
            }

            if (phoneNumber.Length != 12)
            {
                return new ValidationResult("Phone number must be 12 characters long.");
            }

            if (!phoneNumber.StartsWith("+370"))
            {
                return new ValidationResult("Phone number must start with +370.");
            }

            if (!phoneNumber.Skip(4).All(char.IsDigit))
            {
                return new ValidationResult("Phone number must contain only digits after +370.");
            }

            return ValidationResult.Success;
        }
    }
}

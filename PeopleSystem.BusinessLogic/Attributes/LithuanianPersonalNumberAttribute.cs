using PeopleSystem.Database.Enums;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class LithuanianPersonalNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string nationalIdNumber = value as string;

            var personalInfo = (PersonalInformationDto)validationContext.ObjectInstance;
            Gender gender = personalInfo.Gender;
            DateOnly dateOfBirth = personalInfo.DateOfBirth;

            if (nationalIdNumber.Length != 11)
            {
                return new ValidationResult("Personal number must be 11 characters long.");
            }

            if (!nationalIdNumber.All(char.IsDigit))
            {
                return new ValidationResult("Personal number must contain only digits.");
            }

            int[] nationalIdNumberArray = nationalIdNumber.Select(c => (int)char.GetNumericValue(c)).ToArray();
            int firstDigit = nationalIdNumberArray[0];

            if (firstDigit == 9)
            {
                return ValidationResult.Success;
            }

            if (gender == Gender.Male && (firstDigit % 2) == 0)
            {
                return new ValidationResult("Personal number format does not match specified Gender.");
            }

            if ((gender == Gender.Female && (firstDigit % 2) != 0))
            {
                return new ValidationResult("Personal number format does not match specified Gender.");
            }

            int hundredYears = 0;

            if (firstDigit == 1 || firstDigit == 2)
            {
                hundredYears = 18;
            }
            else if (firstDigit == 3 || firstDigit == 4)
            {
                hundredYears = 19;
            }
            else if (firstDigit == 5 || firstDigit == 6)
            {
                hundredYears = 20;
            }
            else
            {
                return new ValidationResult("Invalid first digit in personal number.");
            }

            string dateOfBirthString = dateOfBirth.ToString("yyyyMMdd");
            string dateOfBirthStringFromPersonalNumber = hundredYears + nationalIdNumber.Substring(1, 6);

            if (dateOfBirthString != dateOfBirthStringFromPersonalNumber)
            {
                return new ValidationResult("Date of birth does not match personal number.");
            }

            if (!CheckSumValidation(nationalIdNumberArray))
            {
                return new ValidationResult("Personal number checksum is invalid.");
            }

            return ValidationResult.Success;
        }

        private bool CheckSumValidation(int[] nationalIdNumberArray)
        {
            int[] multipliers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            int[] reserveMultipliers = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            int sum = 0;
            int remainder = 0;
            int lastDigit = nationalIdNumberArray[10];

            for (int i = 0; i < 10; i++)
            {
                sum += nationalIdNumberArray[i] * multipliers[i];
            }

            remainder = sum % 11;

            if (remainder != 10)
            {
                if (remainder == lastDigit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += nationalIdNumberArray[i] * reserveMultipliers[i];
                }

                remainder = sum % 11;

                if (remainder != 10 && remainder == lastDigit)
                {
                    return true;
                }
                else if (remainder == 10 && lastDigit == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

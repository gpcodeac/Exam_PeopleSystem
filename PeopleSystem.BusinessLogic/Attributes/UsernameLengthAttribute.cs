using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class UNUSEDUsernameLengthAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public UNUSEDUsernameLengthAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var username = value as string;
            if (username == null || username.Length < _min || username.Length > _max)
            {
                return new ValidationResult($"Username must be between {_min} and {_max} characters.");
            }

            return ValidationResult.Success;
        }
    }
}

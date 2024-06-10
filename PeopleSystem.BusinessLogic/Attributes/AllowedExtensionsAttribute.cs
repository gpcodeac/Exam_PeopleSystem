using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class UNUSEDAllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public UNUSEDAllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult($"This file extension is not allowed! Allowed extensions are: {string.Join(", ", _extensions)}");
                }
            }

            //var file = value as IFormFile;
            //var extension = Path.GetExtension(file.FileName);

            //if (!_extensions.Contains(extension.ToLower()))
            //{
            //    return new ValidationResult($"This file extension is not allowed! Allowed extensions are: {string.Join(", ", _extensions)}");
            //}

            return ValidationResult.Success;
        }
    }
}

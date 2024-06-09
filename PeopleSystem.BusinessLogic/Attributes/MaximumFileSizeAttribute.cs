using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSystem.BusinessLogic.Attributes
{
    public class MaximumFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaximumFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is Microsoft.AspNetCore.Http.IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"File size should not exceed {_maxFileSize} bytes.");
                }
            }

            return ValidationResult.Success;
        }

    }
}

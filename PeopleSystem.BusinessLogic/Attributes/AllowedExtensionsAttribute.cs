using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PeopleSystem.BusinessLogic.Attributes
{
    internal class AllowedExtensionsAttribute : ValidationAttribute
    {

        private string? _extensions;

        public string Extensions
        {
            // Default file extensions match those from jquery validate.
            get => string.IsNullOrWhiteSpace(_extensions) ? "png,jpg,jpeg,gif" : _extensions;
            set => _extensions = value;
        }

        private string ExtensionsFormatted => ExtensionsParsed.Aggregate((left, right) => left + ", " + right);

        private string ExtensionsNormalized =>
            Extensions.Replace(" ", string.Empty).Replace(".", string.Empty).ToLowerInvariant();

        private IEnumerable<string> ExtensionsParsed
        {
            get { return ExtensionsNormalized.Split(',').Select(e => "." + e); }
        }


        public AllowedExtensionsAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is IFormFile file)
            {
                var fileExtension = Path.GetExtension(file.FileName);

                if (!ExtensionsParsed.Contains(fileExtension.ToLower()))
                {
                    return new ValidationResult($"This file extension is not allowed! Allowed extensions are: {string.Join(", ", _extensions)}");
                }
            }

            return ValidationResult.Success;
        }


    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using PeopleSystem.BusinessLogic.Attributes;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class ProfilePhotoDto
    {
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "This file extension is not allowed! Allowed extensions are: jpg,jpeg,png.")]
        [MaximumFileSize(2 * 1024 * 1024)]
        public IFormFile Image { get; set; }
    }
}

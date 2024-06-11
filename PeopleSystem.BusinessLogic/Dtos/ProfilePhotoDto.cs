using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using PeopleSystem.BusinessLogic.Attributes;
using System.Net.NetworkInformation;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class ProfilePhotoDto
    {
        [AllowedExtensions(Extensions = "png,jpg,jpeg,gif")]
        [MaximumFileSize(2 * 1024 * 1024)]
        public IFormFile Image { get; set; }
    }
}

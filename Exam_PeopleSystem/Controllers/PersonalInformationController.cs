using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using PeopleSystem.BusinessLogic.Dtos;

namespace Exam_PeopleSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {

        private readonly IPersonalInformationService _personalInformationService;

        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            _personalInformationService = personalInformationService;
        }

        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "User")]
        public IActionResult GetPersonalInformationRecords()
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                var personalInformationRecords = _personalInformationService.GetAllPersonalInformationRecords(userId);
                if (personalInformationRecords.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(personalInformationRecords);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "User")]
        public IActionResult CreatePersonalInformationRecord([FromBody] PersonalInformationDto personalInformationDto)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                personalInformationDto.UserId = userId;
                _personalInformationService.CreatePersonalInformationRecord(personalInformationDto);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }







        //[HttpPut]
        //public IActionResult UpdatePersonalInformation(List<PersonalInformationDto> updatedInfo) //make it only work on one item
        //{
        //    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
        //    if (userIdClaim == null)
        //    {
        //        return Unauthorized();
        //    }
        //    int userId = int.Parse(userIdClaim.Value);
        //    _personalInformationService.UpdatePersonalInformation(userId, updatedInfo);
        //    return Ok();
        //}


        //Create a new record, validate the data

        //Delete a record by ID

        //Picture thumbnail

        //Update place of residence on a personal info record


    }
}

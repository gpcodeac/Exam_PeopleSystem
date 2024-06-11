using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.BusinessLogic.Services.Interfaces;

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
                _personalInformationService.CreatePersonalInformationRecord(userId, personalInformationDto);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message == "This Personal Identification Number already exists")
                {
                    return Conflict(e.Message);
                }
                else
                {
                    return StatusCode(500, e.Message);
                }
            }
        }


        [HttpPut]
        [Authorize(Roles = "User")]
        public IActionResult UpdatePersonalInformation([FromBody] PersonalInformationDto personalInformationDto)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                _personalInformationService.UpdatePersonalInformation(userId, personalInformationDto);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        [Authorize(Roles = "User")]
        public IActionResult DeletePersonalInformationRecord([FromBody] string personalIdentificationNumber)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                _personalInformationService.DeletePersonalInformationRecord(userId, personalIdentificationNumber);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message == "Record not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return StatusCode(500, e.Message);
                }
            }
        }


        [HttpPost]
        [Route("{pesonalIdentificationNumber}/photo/add")]
        [Authorize(Roles = "User")]
        public IActionResult AddPhotoToPersonalInformationRecord(string pesonalIdentificationNumber, [FromForm] ProfilePhotoDto photo)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                _personalInformationService.AddPhotoToPersonalInformationRecord(userId, pesonalIdentificationNumber, photo);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        [Route("{pesonalIdentificationNumber}/photo")]
        [Authorize(Roles = "User")]
        public IActionResult GetPhotoFromPersonalInformationRecord(string pesonalIdentificationNumber)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                byte[] imageData = _personalInformationService.GetPhotoFromPersonalInformationRecord(userId, pesonalIdentificationNumber);

                return File(imageData, "image/jpeg");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        [Route("{pesonalIdentificationNumber}/photo")]
        [Authorize(Roles = "User")]
        public IActionResult DeletePhotoFromPersonalInformationRecord(string pesonalIdentificationNumber)
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
                if (userIdClaim == null)
                {
                    return Unauthorized();
                }
                int userId = int.Parse(userIdClaim.Value);
                _personalInformationService.DeletePhotoFromPersonalInformationRecord(userId, pesonalIdentificationNumber);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_PeopleSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("new")]
        [AllowAnonymous]
        public IActionResult SignUp([FromBody] UserRequestDto user) //validations inline or via separate extension method?
        {
            try
            {
                _userService.CreateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserRequestDto user)
        {
            try
            {
                string jwt = _userService.Login(user);
                return Ok(new { jwt });
            }
            catch (Exception e)
            {
                if (e.Message == "User not found" || e.Message == "Invalid password")
                {
                    return Unauthorized(e.Message); //Forbid has some weirder logic, explore to add it when JWT does not match.
                }
                else
                {
                    return BadRequest(e.Message);
                }
            }
        }



        [HttpGet]
        [Route("all")]
        [Authorize(Roles = "Admin")]
        public IEnumerable<string> GetAllUsers()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public UserResponseDto GetUserById(int id)
        {

            var userClaims = User.Claims;
            var userId = userClaims.FirstOrDefault(c => c.Type == "Id").Value;

            if (userId is null)
            {
                throw new Exception("User not found");
            }

            if (userId != id.ToString())
            {
                throw new Exception("Unauthorized");
            }
            return _userService.ReadUserById(id);
        }

     


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

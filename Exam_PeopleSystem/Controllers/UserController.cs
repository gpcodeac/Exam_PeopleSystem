using Microsoft.AspNetCore.Mvc;
using PeopleSystem.BusinessLogic.Services.Interfaces;
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
        public IActionResult SignUp([FromBody] UserSignupRequestDto user) //validations inline or via separate extension method?
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
        public IActionResult Login([FromBody] UserLoginRequestDto user)
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
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userService.GetUser(id));
            }
            catch (Exception e)
            {
                if (e.Message == "User not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return StatusCode(500, e.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message == "User not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return StatusCode(500, e.Message);
                }
            }
        }

        [HttpPut]
        [Route("{id}/password")]
        public IActionResult Put(int id, [FromBody] string password)
        {
            try
            {
                var userClaims = User.Claims;
                var jwtUserRole = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                var jwtUserId = userClaims.FirstOrDefault(c => c.Type == "Id").Value;
                if (jwtUserRole == "Admin" || jwtUserId == id.ToString())
                {
                    _userService.UpdateUserPassword(id, password);
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                if (e.Message == "User not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    return StatusCode(500, e.Message);
                }
            }
        }


    }
}

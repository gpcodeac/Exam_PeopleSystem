using Microsoft.AspNetCore.Mvc;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult SignUp([FromBody] UserDto user) //validations inline or via separate extension method?
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
        public IActionResult Login([FromBody] UserDto user)
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("userAdm")]
        [Authorize(Roles = "Admin")]
        public User GetAdm(int id)
        {
            return _userService.ReadUserById(id);
        }

        [HttpGet]
        [Route("userUs")]
        [Authorize(Roles = "User")]
        public User GetUs(int id)
        {
            return _userService.ReadUserById(id);
        }

        [HttpGet]
        [Route("userAnon")]
        [AllowAnonymous]
        public User GetAnon(int id)
        {
            return _userService.ReadUserById(id);
        }

        [HttpGet]
        [Route("userNone")]
        public User GetNon(int id)
        {
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

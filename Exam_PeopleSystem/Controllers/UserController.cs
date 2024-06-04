using Microsoft.AspNetCore.Mvc;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_PeopleSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.ReadUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("new")]
        public void SignUp([FromBody] UserDto user) //validations inline or via separate extension method?
        {
            _userService.CreateUser(user);
        }

        [HttpPost]
        [Route("login")]
        public void Login([FromBody] UserDto user)
        {
            _userService.Login(user);
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

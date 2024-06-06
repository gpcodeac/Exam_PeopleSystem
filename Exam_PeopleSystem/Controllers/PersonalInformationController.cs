using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam_PeopleSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {

        //public void Placeholder(int id)
        //{
        //    var userClaims = User.Claims;
        //    var userId = userClaims.FirstOrDefault(c => c.Type == "Id").Value;

        //    if (userId is null)
        //    {
        //        throw new Exception("User not found");
        //    }

        //    if (userId != id.ToString())
        //    {
        //        throw new Exception("Unauthorized");
        //    }
        //}

    }
}

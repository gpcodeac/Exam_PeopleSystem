using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<PersonalInformationInUserDto>? PersonalInformation { get; set; }
    }
}

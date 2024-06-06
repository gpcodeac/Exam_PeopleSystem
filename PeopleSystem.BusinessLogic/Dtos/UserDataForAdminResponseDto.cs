using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class UserDataForAdminResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<PersonalInformationForAdminDto>? PersonalInformation { get; set; }
    }
}

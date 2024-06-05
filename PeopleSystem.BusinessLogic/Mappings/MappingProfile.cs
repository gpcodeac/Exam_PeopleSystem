using AutoMapper;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.Database.Models;

namespace PeopleSystem.BusinessLogic.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}

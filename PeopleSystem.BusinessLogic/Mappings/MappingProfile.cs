using AutoMapper;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.Database.Models;

namespace PeopleSystem.BusinessLogic.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserLoginRequestDto, User>();
            CreateMap<UserSignupRequestDto, User>();
            CreateMap<User, UserDataForAdminResponseDto>();
            CreateMap<PersonalInformation, PersonalInformationForAdminDto>();
            CreateMap<PersonalInformation, PersonalInformationDto>().ReverseMap();
            CreateMap<PlaceOfResidence, PlaceOfResidenceDto>().ReverseMap();
        }
    }
}

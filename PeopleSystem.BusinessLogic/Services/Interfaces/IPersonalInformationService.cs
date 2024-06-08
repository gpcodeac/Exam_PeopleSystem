using PeopleSystem.BusinessLogic.Dtos;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    public interface IPersonalInformationService
    {
        List<PersonalInformationDto> GetAllPersonalInformationRecords(int userId);
        void CreatePersonalInformationRecord(PersonalInformationDto personalInformationDto);
        void UpdatePersonalInformation(int userId, List<PersonalInformationDto> updatedInfo);
    }
}

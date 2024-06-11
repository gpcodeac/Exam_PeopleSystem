using PeopleSystem.BusinessLogic.Dtos;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    public interface IPersonalInformationService
    {
        List<PersonalInformationDto> GetAllPersonalInformationRecords(int userId);
        void CreatePersonalInformationRecord(int userId, PersonalInformationDto personalInformationDto);
        void UpdatePersonalInformation(int userId, PersonalInformationDto updatedInfo);
        void DeletePersonalInformationRecord(int userId, string personalIdentificationNumber);
        void AddPhotoToPersonalInformationRecord(int userId, string personalIdentificationNumber, ProfilePhotoDto photo);
        byte[] GetPhotoFromPersonalInformationRecord(int userId, string personalIdentificationNumber);
        void DeletePhotoFromPersonalInformationRecord(int userId, string personalIdentificationNumber);
    }
}

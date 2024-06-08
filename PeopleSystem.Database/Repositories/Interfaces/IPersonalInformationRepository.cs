using PeopleSystem.Database.Models;

namespace PeopleSystem.Database.Repositories.Interfaces
{
    public interface IPersonalInformationRepository
    {
        void CreatePersonalInformation(PersonalInformation personalInformation);
        PersonalInformation ReadPersonalInformationById(int id);
        List<PersonalInformation> ReadAllPersonalInformationOnUser(int userId);
        void UpdatePersonalInformation(PersonalInformation personalInformation);
        void DeletePersonalInformation(PersonalInformation personalInformation);
    }
}
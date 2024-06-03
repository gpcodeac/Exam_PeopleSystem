using PeopleSystem.Database.Models;

namespace PeopleSystem.Database.Repositories.Interfaces
{
    public interface IPersonalInformationRepository
    {
        void CreatePersonalInformation(PersonalInformation personalInformation);
        PersonalInformation ReadPersonalInformationById(int id);
        void UpdatePersonalInformation(PersonalInformation personalInformation);
        void DeletePersonalInformation(PersonalInformation personalInformation);
    }
}
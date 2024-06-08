using PeopleSystem.Database.Models;
using PeopleSystem.Database.Repositories.Interfaces;

namespace PeopleSystem.Database.Repositories
{
    internal class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly AppDBContext _context;

        public PersonalInformationRepository(AppDBContext context)
        {
            _context = context;
        }

        public void CreatePersonalInformation(PersonalInformation personalInformation)
        {
            _context.PersonalInformations.Add(personalInformation);
            _context.SaveChanges();
        }

        public PersonalInformation ReadPersonalInformationById(int id)
        {
            return _context.PersonalInformations.FirstOrDefault(pi => pi.Id == id);
        }

        public List<PersonalInformation> ReadAllPersonalInformationOnUser(int userId)
        {
            return _context.PersonalInformations.Where(pi => pi.UserId == userId).ToList();
        }

        public void UpdatePersonalInformation(PersonalInformation personalInformation)
        {
            _context.PersonalInformations.Update(personalInformation);
            _context.SaveChanges();
        }

        public void DeletePersonalInformation(PersonalInformation personalInformation)
        {
            _context.PersonalInformations.Remove(personalInformation);
            _context.SaveChanges();
        }
    }
}

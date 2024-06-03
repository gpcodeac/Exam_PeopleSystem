using PeopleSystem.Database.Models;
using PeopleSystem.Database.Repositories.Interfaces;

namespace PeopleSystem.Database.Repositories
{
    internal class PlaceOfResidenceRepository : IPlaceOfResidenceRepository
    {
        private readonly AppDBContext _context;

        public PlaceOfResidenceRepository(AppDBContext context)
        {
            _context = context;
        }

        public void CreatePlaceOfResidence(PlaceOfResidence placeOfResidence)
        {
            _context.PlacesOfResidence.Add(placeOfResidence);
            _context.SaveChanges();
        }

        public PlaceOfResidence ReadPlaceOfResidenceById(int id)
        {
            return _context.PlacesOfResidence.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePlaceOfResidence(PlaceOfResidence placeOfResidence)
        {
            _context.PlacesOfResidence.Update(placeOfResidence);
            _context.SaveChanges();
        }

        public void DeletePlaceOfResidence(PlaceOfResidence placeOfResidence)
        {
            _context.PlacesOfResidence.Remove(placeOfResidence);
            _context.SaveChanges();
        }
    }
}

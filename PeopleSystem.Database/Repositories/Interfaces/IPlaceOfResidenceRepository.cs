using PeopleSystem.Database.Models;

namespace PeopleSystem.Database.Repositories.Interfaces
{
    internal interface IPlaceOfResidenceRepository
    {
        void CreatePlaceOfResidence(PlaceOfResidence placeOfResidence);
        PlaceOfResidence ReadPlaceOfResidenceById(int id);
        void UpdatePlaceOfResidence(PlaceOfResidence placeOfResidence);
        void DeletePlaceOfResidence(PlaceOfResidence placeOfResidence);
    }
}
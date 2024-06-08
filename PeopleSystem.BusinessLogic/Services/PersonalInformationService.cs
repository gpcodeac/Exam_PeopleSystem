using AutoMapper;
using PeopleSystem.Database.Repositories.Interfaces;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.Database.Models;

namespace PeopleSystem.BusinessLogic.Services
{
    internal class PersonalInformationService
    {
        private readonly IPersonalInformationRepository _personalInformationRepository;
        private readonly IMapper _mapper;

        public PersonalInformationService(IPersonalInformationRepository personalInformationRepository, IMapper mapper)
        {
            _personalInformationRepository = personalInformationRepository;
            _mapper = mapper;
        }

        public List<PersonalInformationDto> GetAllPersonalInformationRecords(int userId)
        {
            var recordsList = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId);
            return _mapper.Map<List<PersonalInformation>, List<PersonalInformationDto>>(recordsList);
        }

        public void CreatePersonalInformationRecord(PersonalInformationDto personalInformationDto)
        {
            var personalInformation = _mapper.Map<PersonalInformationDto, PersonalInformation>(personalInformationDto);
            _personalInformationRepository.CreatePersonalInformation(personalInformation);
        }





        public void UpdatePersonalInformation(int userId, List<PersonalInformation> updatedInfo)
        {
            var recordsList = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId);
            foreach (var record in recordsList)
            {
                var updatedRecord = updatedInfo.FirstOrDefault(ui => ui.Id == record.Id);
                if (updatedRecord != null)
                {
                    //record.FirstName = updatedRecord.FirstName;
                    //record.LastName = updatedRecord.LastName;
                    //record.Email = updatedRecord.Email;
                    //record.PhoneNumber = updatedRecord.PhoneNumber;
                    //record.Address = updatedRecord.Address;
                    //record.City = updatedRecord.City;
                    //record.Country = updatedRecord.Country;
                    //record.PostalCode = updatedRecord.PostalCode;
                    //record.BirthDate = updatedRecord.BirthDate;
                }
            }
        }


    }
}

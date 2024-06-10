using AutoMapper;
using PeopleSystem.Database.Repositories.Interfaces;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Services.Interfaces;

namespace PeopleSystem.BusinessLogic.Services
{
    internal class PersonalInformationService : IPersonalInformationService
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

        public void CreatePersonalInformationRecord(int userId, PersonalInformationDto personalInformationDto)
        {
            var personalInformation = _mapper.Map<PersonalInformationDto, PersonalInformation>(personalInformationDto);
            personalInformation.UserId = userId;
            if (_personalInformationRepository.ReadAllPersonalInformationOnUser(userId)
                .FirstOrDefault(pi => pi.PersonalIdentificationNumber == personalInformation.PersonalIdentificationNumber) is not null)
            {
                throw new Exception("This Personal Identification Number already exists");
            }
            _personalInformationRepository.CreatePersonalInformation(personalInformation);
        }

        public void UpdatePersonalInformation(int userId, PersonalInformationDto personalInformationDto)
        {
            var recordToUpdate = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId)
                                    .FirstOrDefault(pi => pi.PersonalIdentificationNumber == personalInformationDto.PersonalIdentificationNumber);
            if (recordToUpdate is null)
            {
                CreatePersonalInformationRecord(userId, personalInformationDto);
            }
            else
            {
                var updatedRecord = _mapper.Map<PersonalInformationDto, PersonalInformation>(personalInformationDto);
                updatedRecord.UserId = userId;
                updatedRecord.Id = recordToUpdate.Id;
                _personalInformationRepository.UpdatePersonalInformation(updatedRecord);
            }
        }

        public void DeletePersonalInformationRecord(int userId, string personalIdentificationNumber)
        {
            var recordToDelete = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId)
                                    .FirstOrDefault(pi => pi.PersonalIdentificationNumber == personalIdentificationNumber);
            if (recordToDelete is not null)
            {
                _personalInformationRepository.DeletePersonalInformation(recordToDelete);
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}

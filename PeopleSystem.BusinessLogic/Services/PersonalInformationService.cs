using AutoMapper;
using PeopleSystem.Database.Repositories.Interfaces;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http.HttpResults;

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
                _mapper.Map(personalInformationDto, recordToUpdate);
                _personalInformationRepository.UpdatePersonalInformation(recordToUpdate);
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

        public void AddPhotoToPersonalInformationRecord(int userId, string personalIdentificationNumber, ProfilePhotoDto photo)
        {
            var recordToUpdate = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId)
                                    .FirstOrDefault(pi => pi.PersonalIdentificationNumber == personalIdentificationNumber);
            if (recordToUpdate is null)
            {
                throw new Exception("Record not found");
            }

            if (recordToUpdate.ProfilePhoto is null)
            {
                recordToUpdate.ProfilePhoto = new ProfilePhoto();
            }
            else
            {
                throw new Exception("Photo already exists");
            }
            
            CreateFolders(out string photoFolder, out string thumbnailFolder);

            string photoPath = $"{photoFolder}/{photo.Image.Name}_{DateTime.Now.ToString("yyyy_MM_dd_H_m_s")}{Path.GetExtension(photo.Image.FileName)}";
            recordToUpdate.ProfilePhoto.PhotoPath = photoPath;
            using (FileStream file = new FileStream(photoPath, FileMode.Create))
            {
                photo.Image.CopyTo(file);
            }

            string thumbnailPath = $"{thumbnailFolder}/{photo.Image.Name}_{DateTime.Now.ToString("yyyy_MM_dd_H_m_s")}_th{Path.GetExtension(photo.Image.FileName)}";
            recordToUpdate.ProfilePhoto.ThumbnailPath = thumbnailPath;
            Bitmap myBitMap = new Bitmap(photo.Image.OpenReadStream());
            Image thumb = myBitMap.GetThumbnailImage(200, 200, () => false, IntPtr.Zero);
            using (FileStream file = new FileStream(thumbnailPath, FileMode.Create))
            {
                thumb.Save(file, ImageFormat.Png);
            }

            _personalInformationRepository.UpdatePersonalInformation(recordToUpdate); //should create photo object in the beginning? Should update foreign key?
        }

        private void CreateFolders(out string photoFolder, out string thumbnailFolder)
        {
            string folder = "Photos";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string thumbnail = "Photos/Thumbnails";
            if (!Directory.Exists(thumbnail))
            {
                Directory.CreateDirectory(thumbnail);
            }
            photoFolder = folder;
            thumbnailFolder = thumbnail;
        }

        public byte[] GetPhotoFromPersonalInformationRecord(int userId, string personalIdentificationNumber)
        {
            var record = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId)
                            .FirstOrDefault(pi => pi.PersonalIdentificationNumber == personalIdentificationNumber);
            if (record is null)
            {
                throw new Exception("Record not found");
            }
            if (record.ProfilePhoto is null)
            {
                throw new Exception("Photo not found");
            }
            if (!File.Exists(record.ProfilePhoto.PhotoPath))
            {
                throw new Exception("Photo not found");
            }

            return File.ReadAllBytes(record.ProfilePhoto.PhotoPath);
        }


        public void DeletePhotoFromPersonalInformationRecord(int userId, string personalIdentificationNumber)
        {
            var record = _personalInformationRepository.ReadAllPersonalInformationOnUser(userId)
                            .FirstOrDefault(pi => pi.PersonalIdentificationNumber == personalIdentificationNumber);
            if (record is null)
            {
                throw new Exception("Record not found");
            }
            if (record.ProfilePhoto is null)
            {
                throw new Exception("Photo not found");
            }
            if (!File.Exists(record.ProfilePhoto.PhotoPath) || !File.Exists(record.ProfilePhoto.ThumbnailPath))
            {
                throw new Exception("Photo not found");
            }

            File.Delete(record.ProfilePhoto.PhotoPath);
            File.Delete(record.ProfilePhoto.ThumbnailPath);
            record.ProfilePhoto = null;
            _personalInformationRepository.UpdatePersonalInformation(record);
        }

    }
}

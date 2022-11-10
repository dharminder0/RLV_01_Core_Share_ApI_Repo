using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using Core.Data.Repositories.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Concrete
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMediaFileRepository _mediaRepository;
        public DoctorService(IDoctorRepository doctorRepository, IMediaFileRepository mediaRepository)
        {
            _doctorRepository = doctorRepository; 
            _mediaRepository = mediaRepository;
        }
       
        public List<Doctor> GetDoctors()
        {
            return _doctorRepository.GetDoctors().ToList();

        }
        public DoctorDetails DoctorDetails(int id)
        {
            DoctorDetails doctorDetails = new DoctorDetails();

            var doctor =  _doctorRepository.GetDoctorById(id);
            if (doctor != null)
            {
                doctorDetails.Doctor = _doctorRepository.GetDoctorById(id);
                var files = _mediaRepository.GetEntityMediaFile(doctor.UserId, Entites.EntityType.User);
              if (files != null && files.Any())
                {
                    doctorDetails.Images = new List<MediaFileDto>();
                    foreach (var item in files)
                    {
                        doctorDetails.Images = new List<MediaFileDto> {
                        new MediaFileDto {
                        FileName  = item.FileName,
                        FileUrl= item.BlobLink ,
                        FileType = Enum.GetName(typeof(MediaType),item.MediaTypeId)
                        }
                        };
                    }
                }
            }
            return doctorDetails;

            
        }
        public object GetDoctor(DoctorRequest doctorRequest)
        {

            return _doctorRepository.GetDoctor(doctorRequest).ToList();

        }
    }
}

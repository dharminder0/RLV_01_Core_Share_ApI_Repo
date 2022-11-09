using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using Newtonsoft.Json;
using static Slapper.AutoMapper;

namespace Core.Data.Repositories.Concrete
{

    public class HospitalService : IHospitalsService {

        private readonly IHospitalRepository _hospitalRepository;
        public HospitalService(IHospitalRepository hospitalRepository) {
            _hospitalRepository = hospitalRepository;
        }
        public List<Hospital> GetHospitals() {

            return _hospitalRepository.GetHospitals().ToList();
        }

        public object GetHospitals(HospitalRequest hospitalRequest) {

            return _hospitalRepository.GetHospitals(hospitalRequest).ToList();

        }

        public object GetHospitalsById(int id) {
            if (id > 0) {
                var response = _hospitalRepository.GetHospitalById(id).ToList();
                return response;
            }
            else
                return null;

        }

        //public HospitalDetails HospitalDetails(int id) {
        //    HospitalDetails HospitalDetails = new HospitalDetails();

        //    var Hospital = _hospitalRepository.GetHospitals(id);
        //    if (Hospital != null) {
        //        HospitalDetails.Hospital = _hospitalRepository.GetAllHospitalMediaDetails(id);
        //        var files = _mediaRepository.GetEntityMediaFile(Hospital.UserId, Entites.EntityType.User);
        //        if (files != null && files.Any()) {
        //            HospitalDetails.Images = new List<MediaFileDto>();
        //            foreach (var item in files) {
        //                HospitalDetails.Image = new List<MediaFileDto> {
        //                new MediaFileDto {
        //                FileName  = item.FileName,
        //                FileUrl= item.BlobLink ,
        //                FileType = Enum.GetName(typeof(MediaType),item.MediaTypeId)
        //                }
        //                };
        //            }
        //        }
        //    }
        //    return HospitalDetails;
        //}
    }
}
     
    




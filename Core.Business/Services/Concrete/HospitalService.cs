using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using Core.Data.Repositories.Concrete;


namespace Core.Business.Services.Concrete {
    public class HospitalService : IHospitalService {

        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMediaFileRepository _mediaRepository;
        public HospitalService(IHospitalRepository hospitalRepository, IMediaFileRepository mediaFileRepository) {
            _hospitalRepository = hospitalRepository;
            _mediaRepository = mediaFileRepository;
        }        

        public object GetHospital(HospitalRequest hospitalRequest) {

            return _hospitalRepository.GetHospitals(hospitalRequest).ToList();

        }

        public HospitalDetails HospitalDetails(int id) {
            HospitalDetails hospitalDetails = new HospitalDetails();

            var hospital = _hospitalRepository.GetHospitalById(id);
            if (hospital != null) {
                hospitalDetails.Hospital = _hospitalRepository.GetHospitalById(id);
                var files = _mediaRepository.GetEntityMediaFile(hospital.Id, Entites.EntityType.Hospital);
 
                if (files != null && files.Any()) {
                    hospitalDetails.Images = new List<MediaFileDto>();
                    foreach (var item in files) {
                        hospitalDetails.Images = new List<MediaFileDto> {
                        new MediaFileDto {
                        FileName  = item.FileName,
                        FileUrl= item.BlobLink ,
                        FileType = Enum.GetName(typeof(MediaType),item.MediaTypeId)
                        }
                        };
                    }
                }
            }
            return hospitalDetails;
        }

        public bool CreateHospital(RequestHospital requestHospital) {
            try {
                var response = _hospitalRepository.InsertUser(requestHospital);
                if (response == true) {
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //public List<Hospital> GetHospital() {

            //return _hospitalRepository.GetHospitals().ToList();
    }

}







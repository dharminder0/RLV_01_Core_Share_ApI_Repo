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

            return _hospitalRepository.GetHospitals().ToList();

        }
        
        public List<HospitalDetails> GetDoctorDetailsById(int id) {
            List<HospitalDetails> details = null;
            var hospitals = _hospitalRepository.GetHospitalById(id);
            if (hospitals != null && hospitals.Any()) {
                var hospitalDetails = _hospitalRepository.GetAllHospitalDetails(id);
                if(hospitalDetails != null && hospitalDetails.Any()) {
                     details = JsonConvert.DeserializeObject<List<HospitalDetails>>(hospitalDetails.ToString());
                }
            }
            return details;
        }
    }
}
     
    




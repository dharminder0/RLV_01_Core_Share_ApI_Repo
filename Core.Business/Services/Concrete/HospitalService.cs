using Core.Business.Entites.DataModels;
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

            return _hospitalRepository.GetHospitals(hospitalRequest.CountryId).ToList();

        }
        //public void GetHospitalDetailsById(int id) {
        //    //           //DoctorDetails doctorDetails = null;
        //    //           var doctor = _hospitalRepository.GetDoctorById(id)
        //    //;
        //    //           if (doctor != null) {
        //    //               var doctorDetails = _hospitalRepository.GetAllHospitalsDoctorsMedaiDetails(id);
  
         public List<Hospital> GetHospitalsById(int id) {
           return _hospitalRepository.GetHospitalById(id).ToList();
         }

        //    //           }
        //}
    }

}


using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete
{

    public class HospitalService : IHospitalsService
    {

        private readonly IHospitalRepository _hospitalRepository;
        public HospitalService(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
        public List<Hospital> GetHospitals()
        {

            return _hospitalRepository.GetHospitals().ToList();
        } 
        
        public object GetHospitals(HospitalRequest hospitalRequest)
        {

                return _hospitalRepository.GetHospitals(hospitalRequest).ToList(); 
            
        }
  
         public List<Hospital> GetHospitalsById(int id) {
           return _hospitalRepository.GetHospitalById(id).ToList();
         }

        
    }

}


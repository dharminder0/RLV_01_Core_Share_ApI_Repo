using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Common.Caching;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {


   

    public class HospitalService : IHospitalService {

        private readonly IHospitalRepository _hospitalRepository;
        public HospitalService(IHospitalRepository hospitalRepository) {
            _hospitalRepository = hospitalRepository;
        }
        public List<Hospital> GetHospitals() {

            return _hospitalRepository.GetHospitals().ToList();
        }
        }
    
}


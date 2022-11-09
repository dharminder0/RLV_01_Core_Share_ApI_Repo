using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Common.Data;

namespace Core.Data.Repositories.Abstract {
    public interface IHospitalRepository : IDataRepository<Hospital> {
        IEnumerable<Hospital> GetHospitals();
        //IEnumerable<Hospital> GetHospitals(int countryId);
        //IEnumerable<Hospital> GetHospitalById(int id);
        //IEnumerable<Hospital> GetHospital (HospitalRequest hospitalRequest);
        IEnumerable<Hospital> GetAllHospitalDetails(int id);
        IEnumerable<Hospital> GetHospitalById(int id);
        IEnumerable<Hospital> GetHospitals(HospitalRequest hospitalRequest);
    }
}

using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Common.Data;

namespace Core.Data.Repositories.Abstract {
    public interface IHospitalRepository : IDataRepository<Hospital> {
        IEnumerable<Hospital> GetHospitals();
        IEnumerable<Hospital> GetHospitals(HospitalRequest hospitalRequest);
        IEnumerable<Hospital> GetHospitalById(int id);
    }
}

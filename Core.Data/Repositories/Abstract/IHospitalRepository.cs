using Core.Business.Entites.DataModels;
using Core.Common.Data;

namespace Core.Data.Repositories.Abstract {
    public interface IHospitalRepository : IDataRepository<Hospital> {
        IEnumerable<Hospital> GetHospitals();
        IEnumerable<Hospital> GetHospitals(int countryId);
    }
}

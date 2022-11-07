using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Common.Caching;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {


   

    public class HospitalRepository : DataRepository<Hospital>, IHospitalRepository {
        public IEnumerable<Hospital> GetHospitals() {
            var sql = $@"SELECT * FROM Hospital ";
            return Query<Hospital>(sql);
        }

        public IEnumerable<Hospital> GetHospitals(HospitalRequest hospitalRequest)
        {
            var sql = $@"SELECT * FROM Hospital WHERE CountryId = @CountryId";
            return Query<Hospital>(sql);
        }
    } 
}


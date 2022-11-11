using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class CountryRepository : DataRepository<Country>, ICountryRepository {
        public IEnumerable<Country> GetAllCountry() {
            var sql = $@"SELECT * FROM Country  ";
            return Query<Country>(sql);
        }

    }
}

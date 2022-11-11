using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class CityRepository : DataRepository<City>, ICityRepository {
        public IEnumerable<City> GetCity() {
            var sql = $@"SELECT * FROM City  ";
            return Query<City>(sql);
        }
        public IEnumerable<City> GetCityByCountryid(int id) {
            var sql = $@"SELECT * FROM  City where CountryId=@id";
            return Query<City>(sql, new { id });
        }
        public IEnumerable<City> GetCityByCountryCode(string countrycode) {
            var sql = $@"select CT.Id,CT.CountryId,CT.CityName from CITY CT join COUNTRY C on CT.countryid=C.id  where C.Code=@countrycode ";
            return Query<City>(sql, new { countrycode });
        }




    }
}
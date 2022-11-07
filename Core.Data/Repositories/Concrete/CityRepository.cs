using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Concrete
{
    public class CityRepository:DataRepository<City>, ICityRepository
    {
        public IEnumerable<City> GetCity()
        {
            var sql = $@"SELECT * FROM City ";
            return Query<City>(sql);
        }
        public IEnumerable<City> GetCityByCountryid(int id)
        {
            var sql= $@"SELECT * FROM  City where CountryId=@id";
            return Query<City>(sql);
        }

    }
}

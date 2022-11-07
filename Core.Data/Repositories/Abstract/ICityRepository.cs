using Core.Business.Entites.DataModels;
using Core.Common.Contracts;

namespace Core.Data.Repositories.Abstract
{
    public interface ICityRepository : IDataRepository<City>
    {
        IEnumerable<City> GetCity();
        IEnumerable<City> GetCityByCountryid( int id);
    }
}

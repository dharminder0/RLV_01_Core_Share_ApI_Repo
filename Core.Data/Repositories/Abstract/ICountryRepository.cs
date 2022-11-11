using Core.Business.Entites.DataModels;
using Core.Common.Data;

namespace Core.Data.Repositories.Abstract {
    public interface ICountryRepository : IDataRepository<Country> {
        public IEnumerable<Country> GetAllCountry();



    }
}

using Core.Business.Entites.DataModels;

namespace Core.Business.Services.Abstract {
    public interface ICountryService {
        List<Country> GetCountriesList();
    }
}

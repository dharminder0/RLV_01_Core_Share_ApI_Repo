using Core.Business.Entites.DataModels;

namespace Core.Business.Services.Abstract {
    public interface ICityService {
        List<City> GetCity();
        List<City> GetCityByCountryid(int id);
        List<City> getCityByCountryCode(string countrycode);

    }
}

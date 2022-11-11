using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Business.Services.Concrete {
    public class CityService : ICityService {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository) {
            _cityRepository = cityRepository;
        }

        public List<City> GetCity() {
            return _cityRepository.GetCity().ToList();
        }


        public List<City> GetCityByCountryid(int id) {
            return _cityRepository.GetCityByCountryid(id).ToList();
        }


        public List<City> getCityByCountryCode(string countrycode) {
            return _cityRepository.GetCityByCountryCode(countrycode).ToList();
        }
    }
}

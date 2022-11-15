using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Business.Services.Concrete {
    public class CountryService : ICountryService {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository) {
            _countryRepository = countryRepository;

        }
        public List<Country> GetCountriesList() {
            return _countryRepository.GetAllCountry().ToList();
        }


    }
}

using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Concrete
{
    public class CountryService:ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;

        }
        public List<Country> GetCountries()
        {
            return _countryRepository.GetAllCountry().ToList();
        }

         
    }
}

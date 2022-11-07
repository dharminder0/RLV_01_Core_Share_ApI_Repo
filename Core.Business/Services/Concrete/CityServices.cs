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
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _cityRepository;
        public CityServices(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<City> GetCity()
        {
            return _cityRepository.GetCity().ToList();
        }

    }
}

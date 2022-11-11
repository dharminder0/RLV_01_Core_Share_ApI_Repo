using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Abstract
{
    public interface ICityService
    {
        List<City> GetCity();
        List<City> GetCityByCountryid(int id);
        List<City> getCityByCountryCode(string countrycode);

    }
}

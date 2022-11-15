using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseApiController {
        private readonly ICityService _CityService;


        public CityController(ICityService CityService) {
            _CityService = CityService;

        }



        [HttpGet]
        [Route("{countryId}/list")]
        [RequireAuthorization]
        public List<City> GetCityByCountryId(int countryId) {
            return _CityService.GetCityByCountryid(countryId);
        }


        [HttpGet]
        [Route("list")]
        [RequireAuthorization]
        public List<City> City() {
            return _CityService.GetCity();
        }

        [HttpGet]
        [Route("listbyCountryCode")]
        [RequireAuthorization]
        public List<City> getCityByCountryCode(string countryCode) {
            return _CityService.getCityByCountryCode(countryCode);
        }
    }
}

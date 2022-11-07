using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers
{
    [ApiController]
    public class CityController : BaseApiController
    {
        private readonly ICityService _CityService;
     

        public CityController(ICityService CityService)
        {
            _CityService = CityService;
          
        }

        

        [HttpGet]
        [Route("GetCitylistbyCountryId")]
        [RequireAuthorization]
        public List<City> GetCityByCountryid(int id)
        {
            return _CityService.GetCityByCountryid(id);
        }


        [HttpGet]
        [Route("api/City/GetCitylist")]
        [RequireAuthorization]
        public List<City> City()
        {
            return _CityService.GetCity();
        }
    }
}

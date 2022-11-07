using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseApiController
    {
        private readonly ICityServices _CityService;

        public CityController(ICityServices CityService)
        {
            _CityService = CityService;
        }

        [HttpGet]
        [Route("GetCitylist")]
        [RequireAuthorization]
        public List<City> City()
        {
            return _CityService.GetCity();
        }
    }
}

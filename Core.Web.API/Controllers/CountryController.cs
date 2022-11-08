using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseApiController
    {
       private readonly ICountryService _services;
        private readonly ICityService _CityService;
        public CountryController(ICountryService services, ICityService cityService)
        {
            _services = services;
            _CityService = cityService;
        }


        [HttpGet]
        [Route("GetCountrylist")]
        public IActionResult GetCountries()
        {
            var response = _services.GetCountries();
            return JsonExt(response);
        }

    }
}
  
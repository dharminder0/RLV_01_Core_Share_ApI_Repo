using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseApiController {
        private readonly ICountryService _services;
        private readonly ICityService _CityService;
        public CountryController(ICountryService services, ICityService cityService) {
            _services = services;
            _CityService = cityService;
        }


        [HttpGet]
        [Route("list")]
        [RequireAuthorization]
        public IActionResult GetCountriesList() {
            var response = _services.GetCountriesList();
            return JsonExt(response);
        }

    }
}

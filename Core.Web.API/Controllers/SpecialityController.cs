using Autofac.Core;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Speciality")]
    [ApiController]
    public class SpecialityController : BaseApiController {
        private readonly ISpecialityService _specialityService;
        public SpecialityController(ISpecialityService specialityService) {
            _specialityService = specialityService;
        }


        /// <summary>
        /// used to get Speciality details by countryCode .
        /// </summary>
        /// <param name="countryCode"></param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("{countryCode}/specialityList")]  
        [RequireAuthorization]
        public IActionResult SpecialityList(string countryCode) {
            var response = _specialityService.SpecialityList(countryCode);
            return JsonExt(response);
        }


    }
}

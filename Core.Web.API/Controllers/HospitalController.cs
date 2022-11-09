using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using Core.Data.Repositories.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Hospital")]
    [ApiController]
    public class HospitalController : BaseApiController {

        private readonly IHospitalsService _hospitalService;
        private readonly ICityService _CityService;
        public HospitalController(IHospitalsService hospitalService, ICityService CityService) {
            _hospitalService = hospitalService;
            _CityService = CityService;
        }

        /// <summary>
        /// get list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [RequireAuthorization]
        public List<Hospital> Hospitals() {

            return _hospitalService.GetHospitals();
        }

        /// <summary>
        /// Get Hospitals
        /// <param name="requestModel"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        [RequireAuthorization]
        public IActionResult Hospitals(HospitalRequest requestModel) {
            var response = _hospitalService.GetHospitals(requestModel);
            return JsonExt(response);
        }
        [HttpGet]
        [Route("id")]
        [RequireAuthorization]
        public List<HospitalDetails> GetHospitalById(int id) {
            return _hospitalService.GetDoctorDetailsById(id);
            
        }
    }
}

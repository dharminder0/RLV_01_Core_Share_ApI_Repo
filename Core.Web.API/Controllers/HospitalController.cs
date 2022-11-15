using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Hospital")]
    [ApiController]
    public class HospitalController : BaseApiController {

        private readonly IHospitalService _hospitalService;
        private readonly ICityService _CityService;

        public HospitalController(IHospitalService hospitalService, ICityService CityService) {
            _hospitalService = hospitalService;
            _CityService = CityService;
        }

        /// <summary>
        /// Insert/update for Hospital  
        /// </summary>
        /// <param name="requestHospital"></param>  
        /// <returns></returns>
        [HttpPost]
        [Route("AddHospital")]
        [RequireAuthorization]
        public IActionResult CreateHospital(RequestHospital requestHospital) {
            var response = _hospitalService.CreateHospital(requestHospital);
            return JsonExt(response);
        }

        /// <summary>
        /// Get Hospital by details 
        /// <param name="requestModel"></param>       
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("list")]
        [RequireAuthorization]
        public IActionResult Hospitals(HospitalRequest requestModel) {
            var response = _hospitalService.GetHospital(requestModel);
            return JsonExt(response);
        }


        /// <summary>
        /// Get Hospitals by Id
        /// <param name="id"></param> 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("id")]
        [RequireAuthorization]
        public HospitalDetails GetHospitalById(int id) {
            return _hospitalService.HospitalDetails(id);
        }

        /// <summary>
        /// Add Hospitals Treatment
        /// <param name="id"></param> 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddHospital")]
        [RequireAuthorization]
        public IActionResult CreateHospitalTreatment(RequestHospitalTreatment requestHospitalTreatment) {
            var response = _hospitalService.AddHospitalTreatment(requestHospitalTreatment);
            return JsonExt(response);

        }
    }
}

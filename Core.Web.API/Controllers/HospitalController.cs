using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers
{
    [Route("api/Hospital")]
    [ApiController]
    public class HospitalController : BaseApiController {

        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService) {
            _hospitalService = hospitalService;
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
        [Route("GetHospitals")]
        [RequireAuthorization]
        public IActionResult Hospitals(HospitalRequest requestModel) {
            var response = _hospitalService.GetHospitals(requestModel);
            return JsonExt(response);
        }
    }
}

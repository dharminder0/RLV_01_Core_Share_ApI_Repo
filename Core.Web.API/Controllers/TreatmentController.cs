using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Treatment")]
    [ApiController]
    public class TreatmentController : BaseApiController {
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService) {
            _treatmentService = treatmentService;

        }

        /// <summary>
        /// used to get Treatment details by countryCode .
        /// </summary>
        /// <param name="countryCode"></param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("{countryCode}/list")]
        [RequireAuthorization]
        public IActionResult UsersInfoById(string countryCode) {
            var response = _treatmentService.TreatmentInfoById(countryCode);
            return JsonExt(response);
        }

        [HttpPost]
        [Route("listbySpecialityId")]
        [RequireAuthorization]
        public IActionResult TreatmentInfoBySpecialityId(TreatmentRequest treatmentRequest) {
            var response = _treatmentService.TreatmentInfoBySpecialityId(treatmentRequest);
            return JsonExt(response);

        }
    }
}
